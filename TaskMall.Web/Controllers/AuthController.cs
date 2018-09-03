using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TaskMall.Web.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth
        //登录页面
        public ActionResult Index()
        {
            return View();
        }
    }
}