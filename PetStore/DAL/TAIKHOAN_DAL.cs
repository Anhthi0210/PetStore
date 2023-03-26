using PetStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PetStore.DAL
{
    public class TAIKHOAN_DAL
    {
        private DataContext db = new DataContext();
        //return 1 list
        public List<DANHMUC> getList()
        {
            return db.DANHMUC.ToList();
        }
        //return 1 item
        public DANHMUC getRow(string id)
        {
            if (id == null)
            {
                return null;
            }
            else
            {
                return db.DANHMUC.Find(id);
            }
        }
        //add item
        public int Insert(DANHMUC row)
        {
            db.DANHMUC.Add(row);
            return db.SaveChanges();
        }
        //update
        public int Edit(DANHMUC row)
        {
            db.Entry(row).State = EntityState.Modified;
            return db.SaveChanges();
        }
        //delete
        public int Delete(DANHMUC row)
        {
            db.DANHMUC.Remove(row);
            return db.SaveChanges();
        }
    }
}