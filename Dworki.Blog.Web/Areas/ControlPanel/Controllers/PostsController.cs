using Dworki.Blog.Web.Core;
using System.Web.Mvc;

namespace Dworki.Blog.Web.Areas.ControlPanel.Controllers
{
    [Authorize]
    public class PostsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public PostsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: ControlPanel/Posts
        public ActionResult Index()
        {
            var posts = _unitOfWork.Posts.GetAll();
            return View(posts);
        }
    }
}