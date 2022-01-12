using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMessageService
    {
        List<Message> GetListInbox(string email);
        List<Message> GetListSendInbox(string email);
        List<Message> GetListUnRead();
        List<Message> GetListRead();
        List<Message> GetList();
        List<Message> IsDraft();
        void MessageAdd(Message message);
        void MessageDelete(Message message);
        void MessageUpdate(Message message);
        Message GetById(int id);
        //int Count(Expression<Func<Message, bool>> filter = null);
    }
}
