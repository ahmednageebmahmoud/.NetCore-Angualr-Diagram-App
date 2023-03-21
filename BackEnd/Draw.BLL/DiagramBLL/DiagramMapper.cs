using AutoMapper;
using Draw.BLL.DiagramBLL;

namespace Draw.BLL.DiagramBLL
{
    public class DiagramMapper : Profile
    {
        public DiagramMapper()
        {
            //Map From  , Map To
            CreateMap<DiagramModel,Draw.Core.Model.Diagram>()
                .ForMember(dest => dest.Id, op => op.MapFrom(o => o.Id))
                .ForMember(dest => dest.Name, op => op.MapFrom(o => o.Name))
                .ForMember(dest => dest.Tag, op => op.MapFrom(o => o.Tag))
                .ForMember(dest => dest.JsonDiagram, op => op.MapFrom(o => o.JsonDiagram));

            

            CreateMap<Draw.Core.Model.Diagram, DiagramDTO>()
                .ForMember(dest => dest.Id, op => op.MapFrom(o => o.Id))
                .ForMember(dest => dest.Name, op => op.MapFrom(o => o.Name))
                .ForMember(dest => dest.Tag, op => op.MapFrom(o => o.Tag))
                .ForMember(dest => dest.JsonDiagram, op => op.MapFrom(o => o.JsonDiagram));

        }
    }
}

