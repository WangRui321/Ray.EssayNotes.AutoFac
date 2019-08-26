using System.Web.Mvc;

namespace Ray.EssayNotes.AutoFac.NetFrameworkMvc
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}