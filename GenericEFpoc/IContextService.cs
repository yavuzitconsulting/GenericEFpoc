using GenericEFpoc.Model;

namespace GenericEFpoc
{
    public interface IContextService
    {
        bool Delete<T>(T entity) where T : class;
        bool Update<T>(T entity) where T : class;
        bool Add<T>(T entity) where T : class;
        object Get<T>(int id) where T : class, ISharedEntityInterface;
    }
}
