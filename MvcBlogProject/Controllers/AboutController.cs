using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlogProject.Controllers
{
    public class AboutController : Controller
    {
        // GET: About

        AboutManager aboutManager = new AboutManager(new EfAboutDal());
        public ActionResult Index()
        {
            var aboutValues = aboutManager.GetList();
            return View(aboutValues);
        }

        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAbout(About about)
        {
            aboutManager.AboutAdd(about);
            return RedirectToAction("Index");
        }

        public ActionResult AboutStatus(int id)
        {
            var aboutStatuValue = aboutManager.GetById(id);
            if (aboutStatuValue.AboutStatus == true)
            {
                aboutStatuValue.AboutStatus = false;
                aboutManager.AboutUpdate(aboutStatuValue);
            }
            else
            {
                aboutStatuValue.AboutStatus = true;
                aboutManager.AboutUpdate(aboutStatuValue);
            }
            return RedirectToAction("Index");
        }

        public PartialViewResult AboutPartial()
        {
            return PartialView();
        }
    }
}