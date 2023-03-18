using PetStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PetStore.DAL
{
    public class DONHANG_DAL
    {
        private DataContext db = new DataContext();
        //return 1 list
        public List<DONHANG> getList()
        {
            return db.DONHANGs.ToList();
        }
        //return 1 item
        public DONHANG getRow(string id)
        {
            if (id == null)
            {
                return null;
            }
            else
            {
                return db.DONHANGs.Find(id);
            }
        }
        //add item
        public int Insert(DONHANG row)
        {
            db.DONHANGs.Add(row);
            return db.SaveChanges();
        }
        //update
        public int Edit(DONHANG row)
        {
            db.Entry(row).State = EntityState.Modified;
            return db.SaveChanges();
        }
        //delete
        public int Delete(DONHANG row)
        {
            db.DONHANGs.Remove(row);
            return db.SaveChanges();
        }
    }
}