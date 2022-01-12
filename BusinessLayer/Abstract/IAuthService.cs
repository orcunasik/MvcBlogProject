using EntityLayer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAuthService
    {
        bool AdminLogin(AdminLoginDto adminLoginDto);
        void AdminRegister(string adminUserName, string adminMail, string password);

        bool WriterLogin(WriterLoginDto writerLoginDto);
        void WriterRegister(string writerName, string writerSurname, string writerImage, string writerAbout, 
            string writerTitle, bool writerStatus, string writerMail, string writerPassword,  string writerUserName);
        void WriterUpdate(string writerName, string writerSurname, string writerImage, string writerAbout,
            string writerTitle, bool writerStatus, string writerMail, string writerPassword, string writerUserName);
    }
}
