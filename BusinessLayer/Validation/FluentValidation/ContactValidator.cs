using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validation.FluentValidation
{
    public class ContactValidator : AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x=>x.UserMail).NotEmpty().WithMessage("Mail Adresini Boş Geçemezsiniz");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu Adını Boş Geçemezsiniz");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı Adını Boş Geçemezsiniz");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("En Az 3 Karakter Yazı Giriniz");
            RuleFor(x => x.UserName).MinimumLength(3).WithMessage("En Az 3 Karakter Yazı Giriniz");
            RuleFor(x => x.Subject).MinimumLength(50).WithMessage("En Fazla 50 Karakter Girebilirsiniz");
        }
    }
}
