using System;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(WebApplication1.Startup1))]

namespace WebApplication1
{
    public class Startup1
    {
        public void Configuration(IAppBuilder app)
        {
            //Data Source=.;Initial Catalog=brnmall;User ID=sa
            //GlobalHost.DependencyResolver.UseSqlServer("Data Source=.;Initial Catalog=RbCms;Persist Security Info=True;User ID=sa;Password=123456");
            GlobalHost.DependencyResolver.UseRedis("localhost", 6379, string.Empty, "mykey");
            // 有关如何配置应用程序的详细信息，请访问 http://go.microsoft.com/fwlink/?LinkID=316888
            app.MapSignalR("/myhub", new HubConfiguration()
            { EnableDetailedErrors=true});
        }
    }
}
