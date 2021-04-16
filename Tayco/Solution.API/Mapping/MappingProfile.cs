using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using data = Solution.DO.Objects;

namespace Solution.API.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<data.Administrador, DataModels.Administrador>().ReverseMap();
            //CreateMap<data.Auditoria, DataModels.Auditoria>().ReverseMap();
            CreateMap<data.Cliente, DataModels.Cliente>().ReverseMap();
            CreateMap<data.Equipo, DataModels.Equipo>().ReverseMap();
            //CreateMap<data.Observaciones, DataModels.Observaciones>().ReverseMap();
            CreateMap<data.Reserva, DataModels.Reserva>().ReverseMap();
            //CreateMap<data.Roles, DataModels.Roles>().ReverseMap();
            CreateMap<data.TipoCancha, DataModels.TipoCancha>().ReverseMap();
            CreateMap<data.TipoEquipo, DataModels.TipoEquipo>().ReverseMap();
            CreateMap<data.Users, DataModels.Users>().ReverseMap();
            //CreateMap<data.UsersInRoles, DataModels.UsersInRoles>().ReverseMap();

        }

    }
}
