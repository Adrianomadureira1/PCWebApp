using AutoMapper;
using PCWebApp.Repository.Entity;
using static PCWebApp.Utils.Utils;

namespace PCWebApp.Services.Profiles
{
    public class ModelProfile: Profile
    {
        public ModelProfile(){
            CreateMap<ColaboradorDTO, Colaborador>()
            .BeforeMap((cDto, c) => c.PRS = SerializarString(cDto.PRS));

            CreateMap<Colaborador, ColaboradorDTO>()
            .BeforeMap((c,cDto) => cDto.PRS = DesserializarString(c.PRS));

            CreateMap<DepartamentoDTO, Departamento>().ForMember(x => x.Colaboradores, opt => opt.Ignore());
            CreateMap<Departamento, DepartamentoDTO>();

            CreateMap<GrupoDTO, Grupo>().ForMember(x => x.Colaboradores, opt => opt.Ignore());
            CreateMap<Grupo, GrupoDTO>();
        }
    }
}