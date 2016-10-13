using Dworki.Blog.Web.Core;
using Dworki.Blog.Web.Core.Models;
using Dworki.Blog.Web.Core.ViewModels;
using Microsoft.AspNet.Identity;
using PagedList;
using System;
using System.Linq;
using System.Linq.Expressions;
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
        public ActionResult Index(string sortingOrder, string search, string currentSearch, int? page)
        {
            ViewBag.CurrentSort = sortingOrder;
            ViewBag.DateSort = String.IsNullOrEmpty(sortingOrder) ? "DateDESC" : "";
            ViewBag.TitleSort = sortingOrder == "TitleASC" ? "TitleDESC" : "TitleASC";
            ViewBag.AuthorSort = sortingOrder == "AuthorASC" ? "AuthorDESC" : "AuthorASC";
            ViewBag.VisibilitySort = sortingOrder == "VisibilityASC" ? "VisibilityDESC" : "VisibilityASC";

            IQueryable<Post> posts = null;

            if (search != null)
                page = 1;
            else
                ViewBag.CurrentSearch = search;

            bool applyFilter = !string.IsNullOrEmpty(search);

            switch (sortingOrder)
            {
                case "TitleASC":
                    posts = _unitOfWork.Posts.GetAll(
                        filter: applyFilter ? p => p.Title.Contains(search) : (Expression<Func<Post, bool>>)null,
                        orderBy: p => p.OrderBy(x => x.Title),
                        includes: p => p.Author);
                    break;
                case "TitleDESC":
                    posts = _unitOfWork.Posts.GetAll(
                        filter: applyFilter ? p => p.Title.Contains(search) : (Expression<Func<Post, bool>>)null,
                        orderBy: p => p.OrderByDescending(x => x.Title),
                        includes: p => p.Author);
                    break;
                case "AuthorASC":
                    posts = _unitOfWork.Posts.GetAll(
                        filter: applyFilter ? p => p.Title.Contains(search) : (Expression<Func<Post, bool>>)null,
                        orderBy: p => p.OrderBy(x => x.Author.FullName),
                        includes: p => p.Author);
                    break;
                case "AuthorDESC":
                    posts = _unitOfWork.Posts.GetAll(
                        filter: applyFilter ? p => p.Title.Contains(search) : (Expression<Func<Post, bool>>)null,
                        orderBy: p => p.OrderByDescending(x => x.Author.FullName),
                        includes: p => p.Author);
                    break;
                case "VisibilityASC":
                    posts = _unitOfWork.Posts.GetAll(
                        filter: applyFilter ? p => p.Title.Contains(search) : (Expression<Func<Post, bool>>)null,
                        orderBy: p => p.OrderBy(x => x.Visibility),
                        includes: p => p.Author);
                    break;
                case "VisibilityDESC":
                    posts = _unitOfWork.Posts.GetAll(
                        filter: applyFilter ? p => p.Title.Contains(search) : (Expression<Func<Post, bool>>)null,
                        orderBy: p => p.OrderByDescending(x => x.Visibility),
                        includes: p => p.Author);
                    break;
                case "DateDESC":
                    posts = _unitOfWork.Posts.GetAll(
                        filter: applyFilter ? p => p.Title.Contains(search) : (Expression<Func<Post, bool>>)null,
                        orderBy: p => p.OrderByDescending(x => x.DateTime),
                        includes: p => p.Author);
                    break;
                default:
                    posts = _unitOfWork.Posts.GetAll(
                        filter: applyFilter ? p => p.Title.Contains(search) : (Expression<Func<Post, bool>>)null,
                        orderBy: p => p.OrderBy(x => x.DateTime),
                        includes: p => p.Author);
                    break;
            }

            int pageSize = 10;
            int pageNumber = (page ?? 1);

            return View(posts.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult Create()
        {
            var viewModel = new PostFormViewModel()
            {
                Heading = "Add new post"
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Create(PostFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var post = new Post()
            {
                ApplicationUserId = User.Identity.GetUserId(),
                Contents = viewModel.Contents,
                DateTime = DateTime.Now,
                Title = viewModel.Title
            };

            _unitOfWork.Posts.Add(post);
            _unitOfWork.Complete();

            return RedirectToAction("Index");
        }
    }
}