using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace BDS.Common.DAL
{ 
    public class GenericRep<C, T> : IGenericRep<T> where T : class where C : DbContext, new()
    {
        private C _context;

        public C Context
        {
            get { return _context; }
            set { _context = value; }
        }

        public GenericRep()
        {
            _context = new C();
        }

        public IQueryable<T> GetAll { get { return _context.Set<T>(); } }

        public void Create(T m)
        {
            _context.Set<T>().Add(m);
            _context.SaveChanges();
        }

        public void CreateList(List<T> l)
        {
            _context.Set<T>().AddRange(l);
            _context.SaveChanges();
        }

        public void Delete(T m)
        {
            _context.Set<T>().Remove(m);
            _context.SaveChanges();

        }

        public void DeleteList(List<T> l)
        {
            _context.Set<T>().RemoveRange(l);

        }

        public IQueryable<T> Read(Expression<Func<T, bool>> p)
        {
            return _context.Set<T>().Where(p);
        }

        public virtual T ReadById(int id)
        { return null; 
        }

        protected object Update(T old, T @new)
        {
            _context.Entry(old).State = EntityState.Modified;
            _context.SaveChanges();
            return old;
        }

        public void Update(T m)
        {
        _context.Set<T>().Update(m);
            _context.SaveChanges(); 
        }

        public void UpdateList(List<T> l)
        {
        _context.Set<T>().UpdateRange(l);
            _context.SaveChanges(); 
        }
    }
}
