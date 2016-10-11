using System.ComponentModel.DataAnnotations;

namespace Dworki.Blog.Web.Core.ViewModels.Account
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}