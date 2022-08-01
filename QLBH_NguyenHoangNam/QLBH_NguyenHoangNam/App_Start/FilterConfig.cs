using System.Web;
using System.Web.Mvc;

namespace QLBH_NguyenHoangNam
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
