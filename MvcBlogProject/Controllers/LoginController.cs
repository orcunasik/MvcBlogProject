using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using EntityLayer.Dtos;
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
        IAuthService authService = new AuthManager(new AdminManager(new EfAdminDal()), new WriterManager(new EfWriterDal()));

        Context context = new Context();

        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminLogin(AdminLoginDto adminLoginDto)
        {
            if (authService.AdminLogin(adminLoginDto))
            {
                FormsAuthentication.SetAuthCookie(adminLoginDto.AdminMail, false);
                Session["AdminMail"] = adminLoginDto.AdminMail;
                return RedirectToAction("Index", "Chart");
            }
            else
            {
                ViewData["ErrorMessage"] = "Kullanıcı Adı veya parola yanlış";
                return View();
            }
        }

        public ActionResult AdminLogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("AdminLogin", "Login");
        }

        [HttpGet]
        public ActionResult WriterLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult WriterLogin(WriterLoginDto writerLoginDto)
        {
            if (authService.WriterLogin(writerLoginDto))
            {
                FormsAuthentication.SetAuthCookie(writerLoginDto.WriterMail, false);
                Session["WriterMail"] = writerLoginDto.WriterMail;
                return RedirectToAction("MyHeading", "WriterHeading");
            }

            else
            {
                ViewData["ErrorMessage"] = "Kullanıcı Adı veya Parola Yanlış";
                return RedirectToAction("WriterLogin", "Login");
            }
        }

        public ActionResult WriterLogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Headings", "Default");
        }
    }
}