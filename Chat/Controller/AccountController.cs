using Chat.Help;
using Chat.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Chat.Controller
{
    public class AccountController : System.Web.Mvc.Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return Content("ok");
        }

        [HttpPost]
        public ActionResult CreateToken(UserInfo userInfo)
        {
            if (userInfo.UserName == "admin" && userInfo.Pwd == "123")
            {

                var payload = new Dictionary<string, object>
                {
                    { "username",userInfo.UserName },
                    { "pwd", userInfo.Pwd }
                };

                return Json(new { Token = JwtHelp.SetJwtEncode(payload) });
            }
            return Json(new { });
        }
    }
}