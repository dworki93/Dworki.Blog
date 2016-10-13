using System;
using System.ComponentModel.DataAnnotations;

namespace Dworki.Blog.Web.Core.Models
{
    public class Page
    {
        public int Id { get; set; }

        public string ApplicationUserId { get; set; }

        public ApplicationUser Author { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        [Required]
        [MaxLength(20)]
        public string Title { get; set; }

        public string Contents { get; set; }

        [Required]
        public Visibility Visibility { get; set; }
    }
}