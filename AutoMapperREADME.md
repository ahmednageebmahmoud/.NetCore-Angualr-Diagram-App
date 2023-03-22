## AutoMapper in Web API with .NET 6


# # Install ?
```
	NuGet\Install-Package AutoMapper -Version 12.0.1
	AutoMapper.Extensions.Microsoft.DependencyInjection
```

# #Include the following line to inject the AutoMapper into the .NET dependency injection.
```
	builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
```

# #Create Map
```
    public class DiagramMapper : Profile
    {
        public DiagramMapper()
        {
            //CreateMap<From, TO>()
            CreateMap<DiagramModel, Diagram>()
                .ForMember(dest => dest.Id, op => op.MapFrom(o => o.Id))
                .ForMember(dest => dest.Name, op => op.MapFrom(o => o.Name))
                .ForMember(dest => dest.Tag, op => op.MapFrom(o => o.Tag));
        }
    }
```

# #Use With Return New Object Of Target Type
```
        private readonly IMapper _mapper;
        public DiagramService(IMapper mapper)
        {
            this._mapper=mapper;    
        }

       void Create(DiagramModel model)
        {                //this._mapper.Map<To>(From);
            var newModel = this._mapper.Map<Diagram>(model);
        }
```

# #Use With Return Ovrride On Your Object, This Cate Use When You Need Update Values In Entity Already Tracked From EF Becuse In Next Step You Will Need To Save Change
```
        private readonly IMapper _mapper;
        public DiagramService(IMapper mapper)
        {
            this._mapper=mapper;    
        }

       void Create(DiagramModel model)
        {   
                             //this._mapper.Map<From,To>(From,To);
            var updatedModel = _mapper.Map<DiagramModel, Diagram>(model, diagram);
        }
```
