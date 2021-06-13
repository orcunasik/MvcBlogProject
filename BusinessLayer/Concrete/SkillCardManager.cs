using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class SkillCardManager : ISkillCardService
    {
        ISkillCardDal _skillCardDal;

        public SkillCardManager(ISkillCardDal skillCardDal)
        {
            _skillCardDal = skillCardDal;
        }

        public SkillCard GetById(int id)
        {
            return _skillCardDal.Get(x => x.SkillId == id);
        }

        public List<SkillCard> GetList()
        {
            return _skillCardDal.List();
        }

        public void SkillCardAdd(SkillCard skillCard)
        {
            _skillCardDal.Insert(skillCard);
        }

        public void SkillCardDelete(SkillCard skillCard)
        {
            _skillCardDal.Delete(skillCard);
        }

        public void SkillCardUpdate(SkillCard skillCard)
        {
            _skillCardDal.Update(skillCard);
        }
    }
}
