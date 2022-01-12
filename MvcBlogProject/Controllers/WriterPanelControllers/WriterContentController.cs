using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlogProject.Controllers.WriterPanelControllers
{
    public class WriterContentController : Controller
    {
        ContentManager contentManager = new ContentManager(new EfContentDal());
        Context context = new Context();
        public ActionResult MyContent(string session)
        {
            session= (string)Session["WriterMail"];
            var writerId = context.Writers.Where(x=>x.WriterMail == session)
                .Select(y=>y.WriterId)
                .FirstOrDefault();
            var contentValues = contentManager.GetListByWriter(writerId);
            return View(contentValues);
        }

        [HttpGet]
        public ActionResult MyContentByHeading(int id)
        {
            var contentValue = contentManager.GetContentByWriterHeading(id);
            return View(contentValue);
        }

        [HttpGet]
        public ActionResult AddContent(int id)
        {
            ViewBag.value = id;
            return View();
        }

        [HttpPost]
        public ActionResult AddContent(Content content)
        {
            string mail = (string)Session["WriterMail"];
            var writerId = context.Writers.Where(x => x.WriterMail == mail)
                .Select(y => y.WriterId)
                .FirstOrDefault();
            content.ContentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            content.WriterId = writerId;
            content.ContentStatus = true;
            contentManager.ContentAdd(content);
            return RedirectToAction("MyContent");
        }

    }
}