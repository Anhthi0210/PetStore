using PetStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PetStore.DAL
{
    public class KHACHHANG_DAL
    {
        private DataContext db = new DataContext();
        //return 1 list
        public List<KHACHHANG> getList()
        {
            return db.KHACHHANGs.ToList();
        }
        //return 1 item
        public KHACHHANG getRow(string id)
        {
            if (id == null)
            {
                return null;
            }
            else
            {
                return db.KHACHHANGs.Find(id);
            }
        }
        //add item
        public int Insert(KHACHHANG row)
        {
            db.KHACHHANGs.Add(row);
            return db.SaveChanges();
        }
        //update
        public int Edit(KHACHHANG row)
        {
            db.Entry(row).State = EntityState.Modified;
            return db.SaveChanges();
        }
        //delete
        public int Delete(KHACHHANG row)
        {
            db.KHACHHANGs.Remove(row);
            return db.SaveChanges();
        }
    }
}