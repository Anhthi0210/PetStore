using PetStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PetStore.DAL
{
    public class VOUCHER_DAL
    {
        private DataContext db = new DataContext();
        //return 1 list
        public List<VOUCHER> getList()
        {
            return db.VOUCHER.ToList();
        }
        //return 1 item
        public VOUCHER getRow(string id)
        {
            if (id == null)
            {
                return null;
            }
            else
            {
                return db.VOUCHER.Find(id);
            }
        }
        //add item
        public int Insert(VOUCHER row)
        {
            db.VOUCHER.Add(row);
            return db.SaveChanges();
        }
        //update
        public int Edit(VOUCHER row)
        {
            db.Entry(row).State = EntityState.Modified;
            return db.SaveChanges();
        }
        //delete
        public int Delete(VOUCHER row)
        {
            db.VOUCHER.Remove(row);
            return db.SaveChanges();
        }
    }
}