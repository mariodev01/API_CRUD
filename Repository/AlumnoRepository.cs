using WebApi_Alumnos.Models;
using WebApi_Alumnos.Repository.IRepository;

namespace WebApi_Alumnos.Repository
{
    public class AlumnoRepository : Repository<Alumno>,IAlumno
    {
        private readonly ApplicationDbContext context;

        public AlumnoRepository(ApplicationDbContext context):base(context)
        {
            this.context = context;
        }
        public async Task<Alumno> Actualizar(Alumno alumno)
        {
            //alumno.Id = id;
            context.Alumnos.Update(alumno);
            await context.SaveChangesAsync();
            return alumno;
        }
    }
}
