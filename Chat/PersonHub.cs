using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Newtonsoft.Json;

namespace WebApplication1
{

    [HubName("MyPersonHub")]
    public class PersonHub : Hub
    {
        public void Hello(string msg)
        {
            //欢迎方法
            Clients.All.Welcome("very good");
        }

        [HubMethodName("MyHello")]
        public void Hello(int msg)
        {
            Clients.All.Welecome("我是字符串");
        }

        public async Task GetDate()
        {
           await Clients.All.GetDate(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        }
        public async Task SenMsg(string message)
        {
            var data = new { Name = Context.ConnectionId, msg = message, date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") };
            string msgBody = JsonConvert.SerializeObject(data);
            await Clients.All.GetMsg(data);
        }
        /*  在下面的三个方法中，我们可以用来维护 connectionID 列表  */
        public override Task OnConnected()
        {
            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {
            return base.OnDisconnected(stopCalled);
        }

        public override Task OnReconnected()
        {
            return base.OnReconnected();
        }
    }
}