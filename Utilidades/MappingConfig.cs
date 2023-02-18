using AutoMapper;
using WebApi_Alumnos.Models;
using WebApi_Alumnos.Models.DTO;

namespace WebApi_Alumnos.Utilidades
{
    public class MappingConfig: Profile
    {
        public MappingConfig()
        {
            CreateMap<Alumno, AlumnoDTO>().ReverseMap();
            CreateMap<Alumno, AlumnoCreateDTO>().ReverseMap();
        }
    }
}
