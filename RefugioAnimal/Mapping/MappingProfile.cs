using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RefugioAnimal.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DO.Objects.Adopcion, DataModels.Adopcion>();
            CreateMap<DataModels.Adopcion, DO.Objects.Adopcion>();

            CreateMap<DataModels.Adoptantes, DO.Objects.Adoptantes>();
            CreateMap<DO.Objects.Adoptantes, DataModels.Adoptantes>();

            CreateMap<DataModels.Donacion, DO.Objects.Donacion>();
            CreateMap<DO.Objects.Donacion, DataModels.Donacion>();

            CreateMap<DataModels.Donantes, DO.Objects.Donantes>();
            CreateMap<DO.Objects.Donantes, DataModels.Donantes>();
        }
    }
}
