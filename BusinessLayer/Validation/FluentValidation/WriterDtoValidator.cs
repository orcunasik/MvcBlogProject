using EntityLayer.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Validation.FluentValidation
{
    public class WriterDtoValidator : AbstractValidator<WriterLoginDto>
    {
        public WriterDtoValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar Adını Boş Geçemezsiniz");
            RuleFor(x => x.WriterSurname).NotEmpty().WithMessage("Yazar Soyadını Boş Geçemezsiniz");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Yazar Eposta Alanını Boş Geçemezsiniz");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Yazar Hakkında Alanını Boş Geçemezsiniz");
            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Parola Alanını Boş Geçemezsiniz");
            RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("Yazar Ünvanı Alanını Boş Geçemezsiniz");

            RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("En Fazla 50 Karakter Girişi Yapılabilir!");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Lütfen En Az 2 Karakter Giriniz!");

            RuleFor(x => x.WriterSurname).MaximumLength(50).WithMessage("En Fazla 50 Karakter Girişi Yapılabilir!");
            RuleFor(x => x.WriterSurname).MinimumLength(2).WithMessage("Lütfen En Az 2 Karakter Giriniz!");
        }
    }
}
