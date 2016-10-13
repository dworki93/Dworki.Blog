using Dworki.Blog.Web.Core.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace Dworki.Blog.Web.Core.ViewModels
{
    public class PostsListViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        [Display(Name = "Date added")]
        public DateTime DateTime { get; set; }

        public string Author { get; set; }

        public Visibility Visibility { get; set; }

    }
}