using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContentService
    {
        List<Content> GetList();
        List<Content> GetList(string word);
        List<Content> GetListByHeadingId(int id);
        List<Content> GetListByWriter(int id);
        List<Content> GetContentByWriterHeading(int id);
        void ContentAdd(Content content);
        void ContentUpdate(Content content);
        void ContentDelete(Content content);
        Content GetById(int id);
    }
}
