using EntityLayer.Abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class SkillCard : IEntity
    {
        [Key]
        public int SkillId { get; set; }

        [StringLength(30)]
        public string FirstName { get; set; }

        [StringLength(40)]
        public string LastName { get; set; }

        [StringLength(50)]
        public string Description { get; set; }

        [StringLength(25)]
        public string Skill1 { get; set; }
        public int SkillPoint1 { get; set; }

        [StringLength(25)]
        public string Skill2 { get; set; }
        public int SkillPoint2 { get; set; }

        [StringLength(25)]
        public string Skill3 { get; set; }
        public int SkillPoint3 { get; set; }

        [StringLength(25)]
        public string Skill4 { get; set; }
        public int SkillPoint4 { get; set; }

        [StringLength(25)]
        public string Skill5 { get; set; }
        public int SkillPoint5 { get; set; }

        [StringLength(25)]
        public string Skill6 { get; set; }
        public int SkillPoint6 { get; set; }

        [StringLength(25)]
        public string Skill7 { get; set; }
        public int SkillPoint7 { get; set; }

        [StringLength(25)]
        public string Skill8 { get; set; }
        public int SkillPoint8 { get; set; }
    }
}
