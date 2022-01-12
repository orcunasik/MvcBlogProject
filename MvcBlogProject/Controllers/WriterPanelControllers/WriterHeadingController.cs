using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace MvcBlogProject.Controllers.WriterPanelControllers
{
    public class WriterHeadingController : Controller
    {
        // GET: WriterPanel
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        Context context = new Context();
        public ActionResult MyHeading(string session)
        {
            session = (string)Session["WriterMail"];
            var writerId = context.Writers.Where(x =>x.WriterMail == session )
                .Select(y => y.WriterId)
                .FirstOrDefault();
            var myHeadingValues = headingManager.GetListByWriter(writerId);
            return View(myHeadingValues);
        }

        public ActionResult AllHeading(int? page) //sayfalama
        {
            var headings = headingManager.GetList().ToPagedList(page ?? 1,2);
            return View(headings);
        }

        [HttpGet]
        public ActionResult NewHeading()
        {
            List<SelectListItem> valueCategory = (from x in categoryManager.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()
                                                  }).ToList();
            ViewBag.ValueCategory = valueCategory;

            return View();
        }
        [HttpPost]
        public ActionResult NewHeading(Heading heading)
        {
            string session = (string)Session["WriterMail"];
            var writerId = context.Writers.Where(x => x.WriterMail == session)
                .Select(y => y.WriterId)
                .FirstOrDefault();
            
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            heading.WriterId = writerId;
            heading.HeadingStatus = true;
            headingManager.HeadingAdd(heading);
            return RedirectToAction("MyHeading");
        }

        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            List<SelectListItem> valueCategory = (from x in categoryManager.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()
                                                  }).ToList();
            ViewBag.ValueCategory = valueCategory;

            var headingValue = headingManager.GetById(id);
            return View(headingValue);
        }
        [HttpPost]
        public ActionResult EditHeading(Heading heading)
        {
            headingManager.HeadingUpdate(heading);
            return RedirectToAction("MyHeading");
        }

        public ActionResult DeleteHeading(int id)
        {
            var headingValue = headingManager.GetById(id);

            if (headingValue.HeadingStatus == true)
            {
                headingValue.HeadingStatus = false;
                headingManager.HeadingDelete(headingValue);
            }

            else
            {
                headingValue.HeadingStatus = true;
                headingManager.HeadingDelete(headingValue);
            }

            return RedirectToAction("MyHeading");
        }
    }
}