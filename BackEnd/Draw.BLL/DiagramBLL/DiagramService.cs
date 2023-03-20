using AutoMapper;
using Draw.BLL.ReponseBLL;
using Draw.Core.Helpers.Consts;
using Draw.Core.Model;
using Draw.Core.Repositories;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw.BLL.DiagramBLL
{
    public class DiagramService 
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public DiagramService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        /// <summary>
        /// Create A New Diagram
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public IResponse<DiagramModel> Create(DiagramModel model, string userId)
        {
            try
            {
                var newModel = _mapper.Map<Diagram>(model);
                newModel.FKUser_Id = userId;
                _unitOfWork.Diagrams.Add(newModel);
                if (!_unitOfWork.Complate().Result)
                    return Reponse<DiagramModel>.Error("Can no create");

                model.Id = newModel.Id;
                return Reponse<DiagramModel>.Success("Created Successfully", model);
            }
            catch (Exception ex)
            {
                return Reponse<DiagramModel>.Error(ex);
            }
        }

        /// <summary>
        /// Update Diagram
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public IResponse<DiagramModel> Update(DiagramModel model, string userId)
        {
            try
            {
                var Diagram = _unitOfWork.Diagrams.FindById(model.Id.Value);
                if (Diagram.FKUser_Id != userId)
                {
                    return Reponse<DiagramModel>.Error("You have not authorize");
                }

                var newModel = _mapper.Map<Diagram>(model);
                newModel.FKUser_Id = userId;

                _unitOfWork.Diagrams.Update(newModel);
                if (!_unitOfWork.Complate().Result)
                    return Reponse<DiagramModel>.Error("Can not update");

                model.Id = newModel.Id;
                return Reponse<DiagramModel>.Success("Created Successfully", model);
            }
            catch (Exception ex)
            {
                return Reponse<DiagramModel>.Error(ex);
            }
        }


        /// <summary>
        /// Remove Diagram
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public IResponse<DiagramModel> Remove(int id, string userId)
        {
            try
            {
                var Diagram = _unitOfWork.Diagrams.FindById(id);
                if (Diagram is null)
                {
                    return Reponse<DiagramModel>.Error("Item is not found");
                }
                if (Diagram.FKUser_Id != userId )
                {
                    return Reponse<DiagramModel>.Error("You have not authorize");
                }

                _unitOfWork.Diagrams.Remove(Diagram);
                if (!_unitOfWork.Complate().Result)
                    return Reponse<DiagramModel>.Error("Can not delete");

                return Reponse<DiagramModel>.Success("Deleted Successfully");
            }
            catch (Exception ex)
            {
                return Reponse<DiagramModel>.Error(ex);
            }
        }

        /// <summary>
        /// Select All Diagrams Created By User
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task< IResponse<IEnumerable<DiagramDTO>>> SelectByUser(string userId)
        {
            try
            {
                var list=await
                this._unitOfWork.Diagrams.GetAll(c => c.FKUser_Id == userId,o=> o.Id);
                var listMapper=this._mapper.Map<IEnumerable<DiagramDTO>>(list);
                return Reponse<IEnumerable<DiagramDTO>>.Success(listMapper);
            }
            catch (Exception ex)
            {
                return Reponse<IEnumerable<DiagramDTO>>.Error(ex);
            }
        }

    }
}
