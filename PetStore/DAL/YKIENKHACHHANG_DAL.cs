using PetStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PetStore.DAL
{
    public class YKIENKHACHHANG_DAL
    {
        private DataContext db = new DataContext();
        //return 1 list
        public List<YKIENKHACHHANG> getList()
        {
            return db.YKIENKHACHHANG.ToList();
        }
        //return 1 item
        public YKIENKHACHHANG getRow(string id)
        {
            if (id == null)
            {
                return null;
            }
            else
            {
                return db.YKIENKHACHHANG.Find(id);
            }
        }
        //add item
        public int Insert(YKIENKHACHHANG row)
        {
            db.YKIENKHACHHANG.Add(row);
            return db.SaveChanges();
        }
        //update
        public int Edit(YKIENKHACHHANG row)
        {
            db.Entry(row).State = EntityState.Modified;
            return db.SaveChanges();
        }
        //delete
        public int Delete(YKIENKHACHHANG row)
        {
            db.YKIENKHACHHANG.Remove(row);
            return db.SaveChanges();
        }
    }
}