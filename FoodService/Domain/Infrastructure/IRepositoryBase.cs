namespace FoodService.Domain.Repositories
{
    public interface IRepositoryBase<T>
    {
        void Add(T entity);
        T GetById(int id);
        IEnumerable<T> GetAll();
        void Update(T entity);
        void Delete(int id);

    }
}
