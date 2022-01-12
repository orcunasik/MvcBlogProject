using EntityLayer.Abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Admin : IEntity
    {
        [Key]
        public int AdminId { get; set; }

        [StringLength(50)]
        public string AdminUserName { get; set; }
        public byte[] AdminMail { get; set; }
        public byte[] AdminPasswordSalt { get; set; }
        public byte[] AdminPasswordHash { get; set; }

        [StringLength(1)]
        public string AdminRole { get; set; }
    }
}
