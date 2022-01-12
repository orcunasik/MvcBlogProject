using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using EntityLayer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlogProject.Controllers
{
    public class AuthorizationController : Controller
    {
        IAuthService authService = new AuthManager(new AdminManager(new EfAdminDal()));
        AdminManager adminManager = new AdminManager(new EfAdminDal());
        public ActionResult Index()
        {
            var adminValues = adminManager.GetList();
            return View(adminValues);
        }

        [HttpGet]
        public ActionResult AddAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAdmin(AdminLoginDto adminLoginDto)
        {
            authService.AdminRegister(adminLoginDto.AdminUserName, adminLoginDto.AdminMail, adminLoginDto.AdminPassword);
            return RedirectToAction("Index", "Authorization");
        }
        [HttpGet]
        public ActionResult EditAdmin(int id)
        {
            var adminValue = adminManager.GetById(id);
            return View(adminValue);
        }

        [HttpPost]
        public ActionResult EditAdmin(Admin admin)
        {
            
                adminManager.AdminUpdate(admin);
                return RedirectToAction("Index");
        }
    }
}