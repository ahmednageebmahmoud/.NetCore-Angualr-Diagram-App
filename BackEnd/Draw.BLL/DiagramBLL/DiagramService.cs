using AutoMapper;
using Draw.BLL.ReponseBLL;

using Draw.Core.Model;
using Draw.Core.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
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
        public IResponse<DiagramDTO> Create(DiagramModel model, string userId)
        {
            try
            {
                var newModel = _mapper.Map<Diagram>(model);
                newModel.FKUser_Id = userId;
                _unitOfWork.Diagrams.Add(newModel);
                if (!_unitOfWork.Complate().Result)
                    return Reponse<DiagramDTO>.Error("Can no create");

                model.Id = newModel.Id;
                return Reponse<DiagramDTO>.Success("Created Successfully", this._mapper.Map<DiagramDTO>(newModel));
            }
            catch (Exception ex)
            {
                return Reponse<DiagramDTO>.Error(ex);
            }
        }

        /// <summary>
        /// Update Diagram.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public IResponse<DiagramDTO> Update(DiagramModel model, string userId)
        {
            try
            {
                var diagram = _unitOfWork.Diagrams.FindById(model.Id.Value);
                if (diagram is null)
                {
                    return Reponse<DiagramDTO>.Error("Item is not found");
                }
                if (diagram.FKUser_Id != userId)
                {
                    return Reponse<DiagramDTO>.Error("You have not authorize");
                }

                var updatedModel = _mapper.Map<DiagramModel, Diagram>(model, diagram);
                _unitOfWork.Diagrams.Update(updatedModel);
                if (!_unitOfWork.Complate().Result)
                    return Reponse<DiagramDTO>.Error("Can not update");

          return Reponse<DiagramDTO>.Success("Updated Successfully", this._mapper.Map<DiagramDTO>(updatedModel));
            }
            catch (Exception ex)
            {
                return Reponse<DiagramDTO>.Error(ex);
            }
        }


        /// <summary>
        /// Remove Diagram
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public IResponse<DiagramDTO> Remove(int id, string userId)
        {
            try
            {
                var diagram = _unitOfWork.Diagrams.FindById(id);
                if (diagram is null)
                {
                    return Reponse<DiagramDTO>.Error("Item is not found");
                }
                if (diagram.FKUser_Id != userId)
                {
                    return Reponse<DiagramDTO>.Error("You have not authorize");
                }

                _unitOfWork.Diagrams.Remove(diagram);
                if (!_unitOfWork.Complate().Result)
                    return Reponse<DiagramDTO>.Error("Can not delete");

                return Reponse<DiagramDTO>.Success("Deleted Successfully");
            }
            catch (Exception ex)
            {
                return Reponse<DiagramDTO>.Error(ex);
            }
        }

        /// <summary>
        /// Get Diagram
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public IResponse<DiagramDTO> Get(int id, string userId)
        {
            try
            {
                var diagram = _unitOfWork.Diagrams.FindById(id);
                if (diagram is null)
                {
                    return Reponse<DiagramDTO>.Error("Item is not found");
                }
                if (diagram.FKUser_Id != userId)
                {
                    return Reponse<DiagramDTO>.Error("You have not authorize");
                }

                return Reponse<DiagramDTO>.Success(this._mapper.Map<DiagramDTO>(diagram));
            }
            catch (Exception ex)
            {
                return Reponse<DiagramDTO>.Error(ex);
            }
        }


        /// <summary>
        /// Select All Diagrams Created By User
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public async Task<IResponse<IEnumerable<DiagramDTO>>> SelectByUser(string userId)
        {
            try
            {
                var list = await
                this._unitOfWork.Diagrams.GetAll(c => c.FKUser_Id == userId, o => o.Id);
                var listMapper = this._mapper.Map<IEnumerable<DiagramDTO>>(list);
                return Reponse<IEnumerable<DiagramDTO>>.Success(listMapper);
            }
            catch (Exception ex)
            {
                return Reponse<IEnumerable<DiagramDTO>>.Error(ex);
            }
        }

    }
}
