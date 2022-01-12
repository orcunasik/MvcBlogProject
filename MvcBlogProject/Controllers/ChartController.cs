using MvcBlogProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlogProject.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CategoryCharts()
        {
            return Json(BlogList(), JsonRequestBehavior.AllowGet);
        }

        public List<CategoryChart> BlogList()
        {
            List<CategoryChart> categoryChart = new List<CategoryChart>();
            categoryChart.Add(new CategoryChart()
            {
                CategoryName = "Yazılım",
                CategoryCount = 10
            });
            categoryChart.Add(new CategoryChart()
            {
                CategoryName = "Seyahat",
                CategoryCount = 5
            });
            categoryChart.Add(new CategoryChart()
            {
                CategoryName = "Teknoloji",
                CategoryCount = 7
            });
            categoryChart.Add(new CategoryChart()
            {
                CategoryName = "Spor",
                CategoryCount = 8
            });

            return categoryChart;
        }
    }
}