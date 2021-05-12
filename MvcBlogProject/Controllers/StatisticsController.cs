using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlogProject.Controllers
{
    public class StatisticsController : Controller
    {
        // GET: Statistics

        Context context = new Context();

        public ActionResult Index()
        {
            ViewBag.TotalCategory = context.Categories.Count().ToString();

            ViewBag.HeadingsInSoftwareCategory = context.Headings.Count(x => x.Category.CategoryName == "yazılım").ToString();

            ViewBag.NumberOfWritersContainingTheLetterA = context.Writers.Count(x=>x.WriterName.Contains("a")).ToString();

            ViewBag.CategoryWithTheMostTitles = context.Headings.GroupBy(x => x.Category.CategoryName)
                .OrderByDescending(z => z.Count())
                .Select(y => y.Key).FirstOrDefault();

            var statusTrue = context.Categories.Count(x=>x.CategoryStatus==true);
            var statusFalse = context.Categories.Count(x => x.CategoryStatus == false);
            ViewBag.NumericalDifferinceInCategory = (statusTrue - statusFalse).ToString();
            return View();
        }
    }
}