using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TaskMall.Web.Controllers
{
    public class AuthController : BaseController
    {
        // GET: Auth
        //登录页面
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetVcode(string codeID)
        {
            if (!string.IsNullOrWhiteSpace(codeID))
            {
                //CacheHelper.Instance.Remove(codeID);
                Session.Remove(codeID);
            }
            codeID = Guid.NewGuid().ToString("N");
            var code = VCodeHelper.GetNumAndStr(4);
            var imgdata = VCodeHelper.CreateImage(code);
            Session[codeID] = code;
            //CacheHelper.Instance.Set(codeID, code);
            return Json(ResponseMessage.GetSucess(new
            {
                codeID,
                imgdata
            }));
        }
    }
}