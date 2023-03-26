using PetStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PetStore.DAL
{
    public class PHUONGTHUCGIAOHANG_DAL
    {
        private DataContext db = new DataContext();
        //return 1 list
        public List<PHUONGTHUCGIAOHANG> getList()
        {
            return db.PHUONGTHUCGIAOHANG.ToList();
        }
        //return 1 item
        public PHUONGTHUCGIAOHANG getRow(string id)
        {
            if (id == null)
            {
                return null;
            }
            else
            {
                return db.PHUONGTHUCGIAOHANG.Find(id);
            }
        }
        //add item
        public int Insert(PHUONGTHUCGIAOHANG row)
        {
            db.PHUONGTHUCGIAOHANG.Add(row);
            return db.SaveChanges();
        }
        //update
        public int Edit(PHUONGTHUCGIAOHANG row)
        {
            db.Entry(row).State = EntityState.Modified;
            return db.SaveChanges();
        }
        //delete
        public int Delete(PHUONGTHUCGIAOHANG row)
        {
            db.PHUONGTHUCGIAOHANG.Remove(row);
            return db.SaveChanges();
        }
    }
}