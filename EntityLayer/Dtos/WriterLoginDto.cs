using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Dtos
{
    public class WriterLoginDto
    {
        public string WriterName { get; set; }
        public string WriterSurname { get; set; }
        public string WriterImage { get; set; }
        public string WriterAbout { get; set; }
        public string WriterTitle { get; set; }
        public bool WriterStatus { get; set; }
        public string WriterMail { get; set; }
        public string WriterPassword { get; set; }
        public string WriterUserName { get; set; }

    }
}
