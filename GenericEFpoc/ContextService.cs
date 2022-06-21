using GenericEFpoc.Model;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace GenericEFpoc
{
    public class ContextService : IContextService
    {
        private SchoolContext _context { get; }
        public ContextService(SchoolContext context)
        {
            _context = context;
        }


        public bool Add<T>(T entity) where T : class
        {
            _context.Set<T>().Remove(entity);
            return true;
        }

        public bool Delete<T>(T entity) where T : class
        {
            _context.Set<T>().Remove(entity);
            return true;
        }


        public bool Update<T>(T entity) where T : class
        {
            _context.Set<T>().Update(entity);
            return true;
        }

        public object Get<T>(int id) where T : class, ISharedEntityInterface
        {
            return _context.Set<T>().First(e => e.ID == id);
        }



    }
}
