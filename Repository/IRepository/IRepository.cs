namespace WebApi_Alumnos.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<T> GetById(int id);
        Task Crear(T entity);
        Task Actualizar(T entity);
        Task Borrar(int id);
    }
}
