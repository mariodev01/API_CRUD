using Microsoft.EntityFrameworkCore;
using WebApi_Alumnos.Repository.IRepository;

namespace WebApi_Alumnos.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext context;

        public Repository(ApplicationDbContext context) {
            this.context = context;
        }
        public async Task Actualizar(T entity)
        {
            context.Set<T>().Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task Borrar(int id)
        {
            var modelo = await context.Set<T>().FindAsync(id);
            if (modelo != null)
            {
                context.Set<T>().Remove(modelo);
                await context.SaveChangesAsync();
            }
        }
                                                          
        public async Task Crear(T entity)
        {
            await context.Set<T>().AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAll()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }
    }
}
