using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dworki.Blog.Web.Core.Models
{
    public class Post
    {
        public int Id { get; set; }

        public string ApplicationUserId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        [Required]
        [MaxLength(20)]
        public string Title { get; set; }

        public string Contents { get; set; }

        [Required]
        public Visibility Visibility { get; set; }

        public virtual ICollection<PostTag> PostTags { get; set; }

        public Post()
        {
            PostTags = new HashSet<PostTag>();
        }
    }
}
