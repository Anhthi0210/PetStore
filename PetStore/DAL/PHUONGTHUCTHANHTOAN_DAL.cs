using PetStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PetStore.DAL
{
    public class PHUONGTHUCTHANHTOAN_DAL
    {
        private DataContext db = new DataContext();
        //return 1 list
        public List<PHUONGTHUCTHANHTOAN> getList()
        {
            return db.PHUONGTHUCTHANHTOANs.ToList();
        }
        //return 1 item
        public PHUONGTHUCTHANHTOAN getRow(string id)
        {
            if (id == null)
            {
                return null;
            }
            else
            {
                return db.PHUONGTHUCTHANHTOANs.Find(id);
            }
        }
        //add item
        public int Insert(PHUONGTHUCTHANHTOAN row)
        {
            db.PHUONGTHUCTHANHTOANs.Add(row);
            return db.SaveChanges();
        }
        //update
        public int Edit(PHUONGTHUCTHANHTOAN row)
        {
            db.Entry(row).State = EntityState.Modified;
            return db.SaveChanges();
        }
        //delete
        public int Delete(PHUONGTHUCTHANHTOAN row)
        {
            db.PHUONGTHUCTHANHTOANs.Remove(row);
            return db.SaveChanges();
        }
    }
}