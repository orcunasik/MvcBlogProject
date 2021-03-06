using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        //public int Count(Expression<Func<Message, bool>> filter = null)
        //{
        //    return _messageDal.Count();
        //}

        public Message GetById(int id)
        {
            return _messageDal.Get(x => x.MessageId == id);
        }

        public List<Message> GetList()
        {
            return _messageDal.List();
        }

        public List<Message> GetListInbox(string email)
        {
            return _messageDal.List(x=>x.ReceiverMail == email);
        }

        public List<Message> GetListRead()
        {
            return _messageDal.List().Where(x => x.IsRead == true).ToList();
        }

        public List<Message> GetListSendInbox(string email)
        {
            return _messageDal.List(x => x.SenderMail == email);
        }

        public List<Message> GetListUnRead()
        {
            return _messageDal.List(x=>x.ReceiverMail == "aliyildiz@gmail.com").Where(x=>x.IsRead == false).ToList();
        }

        public List<Message> IsDraft()
        {
            return _messageDal.List(x => x.IsDraft == true && x.SenderMail == "aliyildiz@gmail.com").ToList();
        }

        public void MessageAdd(Message message)
        {
            _messageDal.Insert(message);
        }

        public void MessageDelete(Message message)
        {
            _messageDal.Delete(message);
        }

        public void MessageUpdate(Message message)
        {
            _messageDal.Update(message);
        }

    }
}
