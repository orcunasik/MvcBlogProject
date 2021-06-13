using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MvcBlogProject.Controllers
{
    public class RegisterController : Controller
    {
        AdminManager adminManager = new AdminManager(new EfAdminDal());
        // GET: Register
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
            admin.AdminRole = "a";
            adminManager.AdminAdd(admin);

            return RedirectToAction("Index", "Login");
            
        }
    }
}