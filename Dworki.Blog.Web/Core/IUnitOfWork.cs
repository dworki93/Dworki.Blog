using Dworki.Blog.Web.Core.Repositories;

namespace Dworki.Blog.Web.Core
{
    public interface IUnitOfWork
    {
        IPostRepository Posts { get; }

        int Complete();
    }
}