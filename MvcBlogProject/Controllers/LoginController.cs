using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcBlogProject.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin admin)
        {
            SHA1 sha1 = new SHA1CryptoServiceProvider();
            string password = admin.AdminPassword;
            string userName = admin.AdminUserName;
            string passwordHash = Convert.ToBase64String(sha1.ComputeHash(Encoding.UTF8.GetBytes(password)));
            string userNameHash = Convert.ToBase64String(sha1.ComputeHash(Encoding.UTF8.GetBytes(userName)));
            admin.AdminPassword = passwordHash;
            admin.AdminUserName = userNameHash;

            Context context = new Context();
            var adminUserInfo = context.Admins.FirstOrDefault
                (x=>x.AdminUserName == userNameHash && x.AdminPassword == passwordHash);

            if (adminUserInfo != null)
            {
                FormsAuthentication.SetAuthCookie(adminUserInfo.AdminUserName,false);
                Session["AdminUserName"] = adminUserInfo.AdminUserName;
                return RedirectToAction("Index","Heading");
            }

            ViewBag.ErrorMessage = "Kullanıcı Adı veya Parolanız Hatalı";
            return View();
        }
    }
}