using BusinessLayer.Concrete;
using BusinessLayer.Validation.FluentValidation;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlogProject.Controllers.WriterPanelControllers
{
    public class WriterMessageController : Controller
    {
        Context context = new Context();
        MessageManager messageManager = new MessageManager(new EfMessageDal());
        MessageValidator messageValidator = new MessageValidator();

        public ActionResult Inbox()
        {
            string email = (string)Session["WriterMail"];
            var messageList = messageManager.GetListInbox(email);
            return View(messageList);
        }

        public ActionResult SendBox()
        {
            string email = (string)Session["WriterMail"];
            var messageListSend = messageManager.GetListSendInbox(email);
            return View(messageListSend);
        }

        public PartialViewResult MessageListMenu()
        {
            ViewBag.ReceivedMessages = context.Messages.Count(x => x.ReceiverMail == "aliyildiz@gmail.com" && x.IsRead == false);
            ViewBag.SentMessages = context.Messages.Count(x => x.SenderMail == "aliyildiz@gmail.com" && x.IsDraft == false);
            ViewBag.ReadMessages = context.Messages.Count(x => x.IsRead == true && x.ReceiverMail == "aliyildiz@gmail.com");
            ViewBag.UnReadMessages = context.Messages.Count(x => x.IsRead == false && x.ReceiverMail == "aliyildiz@gmail.com");
            ViewBag.Drafts = context.Messages.Count(x => x.IsDraft == true && x.SenderMail == "aliyildiz@gmail.com");

            return PartialView();
        }

        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewMessage(Message message, string menu)
        {
            string email = (string)Session["WriterMail"];
            ValidationResult result = messageValidator.Validate(message);

            if (menu == "send")
            {
                if (result.IsValid)
                {
                    message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                    message.SenderMail = email;
                    message.IsDraft = false;
                    messageManager.MessageAdd(message);
                    return RedirectToAction("SendBox");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                    }
                }
            }
            else if (menu == "draft")
            {
                if (result.IsValid)
                {
                    message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                    message.SenderMail = email;
                    message.IsDraft = true;
                    messageManager.MessageAdd(message);
                    return RedirectToAction("Draft");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                    }
                }
            }
            return View();

        }

        [HttpGet]
        public ActionResult EditNewMessage(int id)
        {
            var messageValue = messageManager.GetById(id);
            return View(messageValue);
        }

        [HttpPost]
        public ActionResult EditNewMessage(Message message, string menu)
        {
            string email = (string)Session["WriterMail"];
            ValidationResult result = messageValidator.Validate(message);

            if (menu == "send")
            {
                if (result.IsValid)
                {
                    message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                    message.SenderMail = email;
                    message.IsDraft = false;
                    messageManager.MessageUpdate(message);
                    return RedirectToAction("SendBox");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                    }
                }
            }
            else if (menu == "draft")
            {
                if (result.IsValid)
                {
                    message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                    message.SenderMail = email;
                    message.IsDraft = true;
                    messageManager.MessageUpdate(message);
                    return RedirectToAction("Draft");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                    }
                }
            }
            return View();
        }

        public ActionResult Draft()
        {
            var result = messageManager.IsDraft();
            return View(result);
        }

        public ActionResult IsRead(int id)
        {
            var result = messageManager.GetById(id);
            if (result.IsRead == false)
            {
                result.IsRead = true;
            }
            messageManager.MessageUpdate(result);
            return RedirectToAction("ReadMessage");
        }

        public ActionResult ReadMessage()
        {
            var readMessage = messageManager.GetListRead();
            return View(readMessage);
        }

        public ActionResult UnReadMessage()
        {
            var unReadMessage = messageManager.GetListUnRead();
            return View(unReadMessage);
        }

        [HttpGet]
        public ActionResult GetInboxDetails(int id)
        {
            var messageValue = messageManager.GetById(id);
            if (messageValue.IsRead == false)
            {
                messageValue.IsRead = true;
            }
            messageManager.MessageUpdate(messageValue);
            return View(messageValue);
        }

        public ActionResult GetSendboxDetails(int id)
        {
            var messageValues = messageManager.GetById(id);

            return View(messageValues);
        }
    }
}