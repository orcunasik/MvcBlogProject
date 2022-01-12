using BusinessLayer.Abstract;
using EntityLayer.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using BusinessLayer.Utilities;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class AuthManager : IAuthService
    {
        IAdminService _adminService;
        IWriterService _writerService;
        public AuthManager(IAdminService adminService, IWriterService writerService)
        {
            _adminService = adminService;
            _writerService = writerService;
        }
        public AuthManager(IWriterService writerService)
        {
            _writerService = writerService;
        }
        public AuthManager(IAdminService adminService)
        {
            _adminService = adminService;
        }

        public bool AdminLogin(AdminLoginDto adminLoginDto)
        {
            using (var crypto = new HMACSHA512() )
            {
                var mailHash = crypto.ComputeHash(Encoding.UTF8.GetBytes(adminLoginDto.AdminMail));
                var admin = _adminService.GetList();

                foreach (var adminItem in admin)
                {
                    if (HashingHelper.VerifyPasswordAndMailHash(adminLoginDto.AdminMail, adminLoginDto.AdminPassword,
                        adminItem.AdminMail,adminItem.AdminPasswordHash,adminItem.AdminPasswordSalt))
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        public void AdminRegister(string adminUserName, string adminMail, string password)
        {
            byte[] mailHash, passwordHash, passwordSalt;
            HashingHelper.CreatePasswordAndMailHash(adminMail,password,out mailHash, out passwordHash, out passwordSalt);

            var admin = new Admin
            {
                AdminUserName = adminUserName,
                AdminMail = mailHash,
                AdminPasswordHash = passwordHash,
                AdminPasswordSalt = passwordSalt,
                AdminRole = "b"
            };

            _adminService.AdminAdd(admin);
        }

        public bool WriterLogin(WriterLoginDto writerLoginDto)
        {
            using (var crypto = new HMACSHA512())
            {
                var writer = _writerService.GetList();

                foreach (var writerItem in writer)
                {
                    if (HashingHelper.VerifyPasswordHash(writerLoginDto.WriterPassword,
                        writerItem.WriterPasswordHash,writerItem.WriterPasswordSalt))
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        public void WriterRegister(string writerName, string writerSurname, string writerImage, string writerAbout,
            string writerTitle, bool writerStatus, string writerMail, string writerPassword, string writerUserName)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(writerPassword,out passwordHash,out passwordSalt);
            var writer = new Writer
            {
                WriterName = writerName,
                WriterSurname = writerSurname,
                WriterImage = writerImage,
                WriterAbout = writerAbout,
                WriterTitle = writerTitle,
                WriterStatus = writerStatus,
                WriterMail = writerMail,
                WriterPasswordHash = passwordHash,
                WriterPasswordSalt = passwordSalt,
                WriterUserName = writerUserName

            };
            _writerService.WriterAdd(writer);
        }

        public void WriterUpdate(string writerName, string writerSurname, string writerImage, string writerAbout, string writerTitle, bool writerStatus, string writerMail, string writerPassword, string writerUserName)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(writerPassword, out passwordHash, out passwordSalt);
            var writer = new Writer
            {
                WriterName = writerName,
                WriterSurname = writerSurname,
                WriterImage = writerImage,
                WriterAbout = writerAbout,
                WriterTitle = writerTitle,
                WriterStatus = writerStatus,
                WriterMail = writerMail,
                WriterPasswordHash = passwordHash,
                WriterPasswordSalt = passwordSalt,
                WriterUserName = writerUserName

            };
            _writerService.WriterUpdate(writer);
        }
    }
}
