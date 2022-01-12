using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.Validation.FluentValidation;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using EntityLayer.Dtos;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcBlogProject.Controllers.WriterPanelControllers
{
    public class WriterProfileController : Controller
    {
        // GET: WriterProfile
        IAuthService authService = new AuthManager(new WriterManager(new EfWriterDal()));
        WriterManager writerManager = new WriterManager(new EfWriterDal());
        WriterDtoValidator writerDtoValidator = new WriterDtoValidator();
        Context context = new Context();
        [HttpGet]
        public ActionResult WriterProfile(int id = 0)
        {
            
            string email = (string)Session["WriterMail"];
            id = context.Writers.Where(x => x.WriterMail == email)
                .Select(y => y.WriterId)
                .FirstOrDefault();
            var writerValue = writerManager.GetById(id);
            return View(writerValue);
        }
        [HttpPost]
        public ActionResult WriterProfile(WriterLoginDto writerLoginDto)
        {
            
            ValidationResult result = writerDtoValidator.Validate(writerLoginDto);
            if (result.IsValid)
            {

                authService.WriterUpdate(
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
                //writerManager.WriterUpdate(writerLoginDto);
                return RedirectToAction("WriterProfile");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
            }
            return View();
        }
    }
}