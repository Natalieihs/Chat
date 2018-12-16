using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
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
        private static int OnlineCount = 0;
        public static ConcurrentDictionary<string, User> valuePairs = new ConcurrentDictionary<string, User>();
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
            //连接成功后写入cookie
            Interlocked.Increment(ref OnlineCount);
            var user = new User
            {
                Active = true,
                Name = "user_" + OnlineCount,
                OnlineTime = DateTime.Now
            };
            valuePairs[Context.ConnectionId] = user;
            return base.OnConnected();
        }

        public override Task OnDisconnected(bool stopCalled)
        {

            return base.OnDisconnected(stopCalled);
        }

        public override Task OnReconnected()
        {
            Interlocked.Decrement(ref OnlineCount);
            User user;
            valuePairs.TryRemove(Context.ConnectionId, out user);
            return base.OnReconnected();
        }
    }

    public class User
    {
        public bool Active { get; set; }
        public DateTime OnlineTime { get; set; }
        public string Name { get; set; }
    }
}