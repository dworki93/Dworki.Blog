using Dworki.Blog.Web.Core.Models;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Dworki.Blog.Web.Core.ViewModels
{
    public class PostFormViewModel
    {
        [Required]
        [MaxLength(20)]
        public string Title { get; set; }

        [AllowHtml]
        public string Contents { get; set; }

        [Required]
        public Visibility Visibility { get; set; }

        public string Heading { get; set; }
    }
}