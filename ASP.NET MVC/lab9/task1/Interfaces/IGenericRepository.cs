public interface IGenericRepository<T> where T : class, new()
{
    IEnumerable<T> GetAll();
    T GetById(int id);
    void Add(T entity);
    void Update(T entity);
    void DeleteById(int id);
} 