using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Dworki.Blog.Web.Core.Models
{
    public class Tag
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        public virtual ICollection<PostTag> PostTags { get; set; }

        public Tag()
        {
            PostTags = new HashSet<PostTag>();
        }
    }
}