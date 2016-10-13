using System.Web.Mvc;

namespace Dworki.Blog.Web.Areas.ControlPanel
{
    public class ControlPanelAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "ControlPanel";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "ControlPanel_default",
                "ControlPanel/{controller}/{action}/{id}",
                new { controller = "Posts", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}