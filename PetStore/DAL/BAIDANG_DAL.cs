using PetStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PetStore.DAL
{
    public class BAIDANG_DAL
    {
        private DataContext db = new DataContext();
        //return 1 list
        public List<BAIDANG> getList()
        {
            return db.BAIDANG.ToList();
        }
        public List<BAIDANG> getList(string id)
        {
            if (id == null) return null;
            else
            {
                return db.BAIDANG.Where(m => m.TenDangNhap == id).ToList();
            }

        }
        //return 1 item
        public BAIDANG getRow(string id)
        {
            if (id == null)
            {
                return null;
            }
            else
            {
                return db.BAIDANG.Find(id);
            }
        }
        //add item
        public int Insert(BAIDANG row)
        {
            db.BAIDANG.Add(row);
            return db.SaveChanges();
        }
        //update
        public int Edit(BAIDANG row)
        {
            db.Entry(row).State = EntityState.Modified;
            return db.SaveChanges();
        }
        //delete
        public int Delete(BAIDANG row)
        {
            db.BAIDANG.Remove(row);
            return db.SaveChanges();
        }
    }
}