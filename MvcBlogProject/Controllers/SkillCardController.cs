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
    public class SkillCardController : Controller
    {
        // GET: SkillCard

        SkillCardManager skillCardManager = new SkillCardManager(new EfSkillCardDal());

        public ActionResult Index()
        {
            Context context = new Context();
            var skillCardValues = skillCardManager.GetList();

            ViewBag.skill1 = context.SkillCards.Sum(x => x.SkillPoint1) * 250 / 100;

            ViewBag.skill2 = context.SkillCards.Sum(x => x.SkillPoint2) * 250 / 100;

            ViewBag.skill3 = context.SkillCards.Sum(x => x.SkillPoint3) * 250 / 100;

            ViewBag.skill4 = context.SkillCards.Sum(x => x.SkillPoint4) * 250 / 100;

            ViewBag.skill5 = context.SkillCards.Sum(x => x.SkillPoint5) * 250 / 100;

            ViewBag.skill6 = context.SkillCards.Sum(x => x.SkillPoint6) * 250 / 100;

            ViewBag.skill7 = context.SkillCards.Sum(x => x.SkillPoint7) * 250 / 100;

            ViewBag.skill8 = context.SkillCards.Sum(x => x.SkillPoint8) * 250 / 100;

            return View(skillCardValues);
        }
    }
}