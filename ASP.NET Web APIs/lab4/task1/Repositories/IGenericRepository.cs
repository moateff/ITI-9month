namespace task1.Repositories;

public interface IGenericRepository<T> where T : class
{
    List<T> GetAll();
    T GetById(int id);
    void Update(T entity);
    void Add(T entity);
    void Delete(T entity);
    void SaveChanges();
}
