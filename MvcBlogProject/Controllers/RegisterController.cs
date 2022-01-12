using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
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

namespace MvcBlogProject.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        IAuthService authService = new AuthManager(new AdminManager(new EfAdminDal()), new WriterManager(new EfWriterDal()));
        // GET: Register
        [HttpGet]
        public ActionResult AdminRegister()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AdminRegister(AdminLoginDto adminLoginDto)
        {
            authService.AdminRegister(adminLoginDto.AdminUserName, adminLoginDto.AdminMail, adminLoginDto.AdminPassword);
            return RedirectToAction("Index", "AdminCategory");
            
        }

        [HttpGet]
        public ActionResult WriterRegister()
        {
            return View();
        }

        [HttpPost]
        public ActionResult WriterRegister(WriterLoginDto writerLoginDto)
        {
            authService.WriterRegister(
                    writerLoginDto.WriterName,
                    writerLoginDto.WriterSurname,
                    writerLoginDto.WriterImage,
                    writerLoginDto.WriterAbout,
                    writerLoginDto.WriterTitle,
                    writerLoginDto.WriterStatus = true,
                    writerLoginDto.WriterMail,
                    writerLoginDto.WriterPassword,
                    writerLoginDto.WriterUserName
                     
                );

            return RedirectToAction("MyHeading", "WriterHeading");

        }

    }
}