using System.Web.Mvc;

namespace Ray.EssayNotes.AutoFac.NetFrameworkApi
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}