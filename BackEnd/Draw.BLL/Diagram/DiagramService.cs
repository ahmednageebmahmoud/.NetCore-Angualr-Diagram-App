using AutoMapper;
using Draw.BLL.Helpers.Reponse;
using Draw.Core.Helpers.Consts;
using Draw.Core.Model;
using Draw.Core.Repositories;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw.BLL.Helpers.Diagram
{
    public class DiagramService : IService
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
                    return Reponse<DiagramModel>.Error("Can no create");

                model.Id = newModel.Id;
                return Reponse<DiagramModel>.Success("Created Successfully", model);
            }
            catch (Exception ex)
            {
                return Reponse<DiagramModel>.Error(ex);
            }
        }



    }
}
