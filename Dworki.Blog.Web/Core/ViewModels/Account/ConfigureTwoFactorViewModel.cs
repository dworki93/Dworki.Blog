using System.Collections.Generic;

namespace Dworki.Blog.Web.Core.ViewModels.Account
{
    public class ConfigureTwoFactorViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
    }
}