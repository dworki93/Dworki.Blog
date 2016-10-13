using Dworki.Blog.Web.Core.Models;
using System.Collections.Generic;

namespace Dworki.Blog.Web.Core.Repositories
{
    public interface IPostRepository : IRepository<Post>
    {
        IEnumerable<Post> GetPostsWithTags(int pageIndex, int pageSize);
    }
}