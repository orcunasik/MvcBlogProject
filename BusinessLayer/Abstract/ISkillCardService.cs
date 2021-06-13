using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ISkillCardService
    {
        List<SkillCard> GetList();
        void SkillCardAdd(SkillCard skillCard);
        void SkillCardUpdate(SkillCard skillCard);
        void SkillCardDelete(SkillCard skillCard);
        SkillCard GetById(int id);
    }
}
