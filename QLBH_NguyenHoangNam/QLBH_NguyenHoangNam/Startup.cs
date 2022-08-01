using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(QLBH_NguyenHoangNam.Startup))]
namespace QLBH_NguyenHoangNam
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
