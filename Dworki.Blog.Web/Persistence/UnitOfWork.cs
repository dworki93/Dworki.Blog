using Dworki.Blog.Web.Core;
using Dworki.Blog.Web.Core.Repositories;
using Dworki.Blog.Web.Persistence.Repositories;

namespace Dworki.Blog.Web.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        public IPostRepository Posts { get; private set; }

        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Posts = new PostRepository(_context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}