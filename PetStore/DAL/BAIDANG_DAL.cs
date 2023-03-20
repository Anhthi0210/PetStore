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
            return db.BAIDANGs.ToList();
        }
        public List<BAIDANG> getList(string id)
        {
            if (id == null) return null;
            else
            {
                return db.BAIDANGs.Where(m => m.TenDangNhap == id).ToList();
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
                return db.BAIDANGs.Find(id);
            }
        }
        //add item
        public int Insert(BAIDANG row)
        {
            db.BAIDANGs.Add(row);
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
            db.BAIDANGs.Remove(row);
            return db.SaveChanges();
        }
    }
}