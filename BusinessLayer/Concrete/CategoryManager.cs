﻿using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager
    {
        GenericRepository<Category> repo = new GenericRepository<Category>();
        public List<Category> GetAll()
        {
            return repo.List();
        }

        public void CategoryAdd(Category c)
        {
            if(c.CategoryName == "" || c.CategoryName.Length <= 3)
            {
                //hata mesajı
            }
            else
            {
                repo.Insert(c);
            }
        }
    }
}
