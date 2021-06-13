using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.Validation.FluentValidation;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlogProject.Controllers
{
    public class MessageController : Controller
    {
        // GET: Message

        MessageManager messageManager = new MessageManager(new EfMessageDal());
        MessageValidator messageValidator = new MessageValidator();

        [Authorize]
        public ActionResult Inbox()
        {
            var messageList = messageManager.GetListInbox();
            return View(messageList);
        }

        public ActionResult SendBox()
        {
            var messageListSend = messageManager.GetListSendInbox();
            return View(messageListSend);
        }

        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewMessage(Message message, string menu)
        {
            ValidationResult result = messageValidator.Validate(message);

            if (menu == "send")
            {
                if (result.IsValid)
                {
                    message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                    message.SenderMail = "admin@gmail.com";
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
                    message.SenderMail = "admin@gmail.com";
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
            ValidationResult result = messageValidator.Validate(message);

            if (menu == "send")
            {
                if (result.IsValid)
                {
                    message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                    message.SenderMail = "admin@gmail.com";
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
                    message.SenderMail = "admin@gmail.com";
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
            var readMessage = messageManager.GetList().Where(x=>x.IsRead == true).ToList();
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