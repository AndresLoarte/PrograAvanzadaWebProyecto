using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using data = DO.Objects;
namespace API.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<data.Administrador, DataModels.Administrador>().ReverseMap();
            CreateMap<data.Equipo, DataModels.Equipo>().ReverseMap();
            CreateMap<data.Reserva, DataModels.Reserva>().ReverseMap();
            CreateMap<data.Roles, DataModels.Roles>().ReverseMap();
            CreateMap<data.TipoCancha, DataModels.TipoCancha>().ReverseMap();
            CreateMap<data.TipoEquipo, DataModels.TipoEquipo>().ReverseMap();
            CreateMap<data.Users, DataModels.Users>().ReverseMap();

        }
    }
}
