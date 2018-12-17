using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using Chat.Help;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Newtonsoft.Json;

namespace WebApplication1
{

    [HubName("MyPersonHub")]
    public class PersonHub : Hub
    {
        public static int OnlineCount = 0;
        public static ConcurrentDictionary<string, User> valuePairs = new ConcurrentDictionary<string, User>();
        public static ConcurrentDictionary<string, string> valuePairs1 = new ConcurrentDictionary<string, string>();
        private string UserName
        {
            get
            {
                var userName = Context.RequestCookies["USERNAME"];
                return userName == null ? "" : HttpUtility.UrlDecode(userName.Value);
            }
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
        public async override Task OnConnected()
        {
            ////连接成功后写入cookie
            //Interlocked.Increment(ref OnlineCount);
            //Cookie cookie;

            //if (!Context.RequestCookies.TryGetValue("aa", out cookie))
            //{
            //    var guid = Guid.NewGuid().ToString();
            //    System.Web.HttpContext.Current.Response.Cookies.Add(new HttpCookie("aa", guid));
            //    var user = new User
            //    {
            //        Active = true,
            //        Name = "user_" + OnlineCount,
            //        OnlineTime = DateTime.Now
            //    };
            //   valuePairs[guid] = user;
            //   await Clients.All.OnlineUser(valuePairs[guid]);
            //}
            //else
            //{
            //    User user;
            //    if (!valuePairs.TryGetValue(cookie.Value,out user))
            //    {
            //        valuePairs[cookie.Value] = new User
            //        {
            //            Active = true,
            //            Name = "user_" + OnlineCount,
            //            OnlineTime = DateTime.Now
            //        };
            //    }
            //    await Clients.All.OnlineUser(valuePairs[cookie.Value]);
            //}
            string  userName = WebHelper.GetCookie("USERNAME");
            if (string.IsNullOrEmpty(userName))
            {
                string sid = Sessions.GenerateSid();
                WebHelper.SetCookie("USERNAME", sid);
                User user = new User
                {
                    Name = userName,
                    Active = true,
                    OnlineTime = DateTime.Now
                };

                await Clients.All.OnlineUser(user);
            }
            else
            {
                User user=  new User
                {
                    Name = userName,
                    Active = true,
                    OnlineTime = DateTime.Now
                };

                await Clients.All.OnlineUser(user);
            }
            await  base.OnConnected();
        }

        public async override Task OnDisconnected(bool stopCalled)
        {
            string sid = WebHelper.GetCookie("USERNAME");
            User user = new User
            {
                Name = sid,
                Active = false,
                OnlineTime = DateTime.Now
            };
            await Clients.Others.OnlineUser(user);
        }

        public async override Task OnReconnected()
        {
           
          //  return base.OnReconnected();
        }
    }

    public class User
    {
        public bool Active { get; set; }
        public DateTime OnlineTime { get; set; }
        public string Name { get; set; }
    }
}