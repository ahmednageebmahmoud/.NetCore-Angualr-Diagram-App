using AutoMapper;
using Draw.BLL.Model;
using Draw.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw.BLL.Mapper
{
    public class DiagramMapper : Profile
    {
        public DiagramMapper()
        {
                    //Map From  , Map To
            CreateMap<DiagramModel, Diagram>()
                .ForMember(dest => dest.Id, op => op.MapFrom(o => o.Id))
                .ForMember(dest => dest.Name, op => op.MapFrom(o => o.Name))
                .ForMember(dest => dest.Tag, op => op.MapFrom(o => o.Tag));
        }
    }
}

