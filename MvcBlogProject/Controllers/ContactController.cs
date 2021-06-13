using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.Validation.FluentValidation;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlogProject.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        Context context = new Context();
        ContactManager contactManager = new ContactManager(new EfContactDal());

        ContactValidator contactValidator = new ContactValidator();

        public ActionResult Index()
        {
            var contactValues = contactManager.GetList();
            return View(contactValues);
        }

        public ActionResult GetContactDetails(int id)
        {
            var contactValues = contactManager.GetById(id);

            return View(contactValues);
        }

        public PartialViewResult ContactPartial()
        {
            ViewBag.ContactMessages = contactManager.GetList().Count();
            ViewBag.ReceivedMessages = context.Messages.Count(x=>x.ReceiverMail == "admin@gmail.com" && x.IsRead == false);
            ViewBag.SentMessages = context.Messages.Count(x => x.SenderMail == "admin@gmail.com" && x.IsDraft == false);
            ViewBag.ReadMessages = context.Messages.Count(x=>x.IsRead == true && x.SenderMail != "admin@gmail.com");
            ViewBag.UnReadMessages = context.Messages.Count(x => x.IsRead == false && x.SenderMail != "admin@gmail.com");
            ViewBag.Drafts = context.Messages.Count(x=>x.IsDraft == true);

            return PartialView();
        }


    }
}