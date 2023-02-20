using WebApi_Alumnos.Models;

namespace WebApi_Alumnos.Repository.IRepository
{
    public interface IAlumno: IRepository<Alumno>
    {
        Task<Alumno> Actualizar(Alumno alumno);
    }
}
