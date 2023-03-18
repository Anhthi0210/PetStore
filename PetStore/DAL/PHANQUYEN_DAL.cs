using PetStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PetStore.DAL
{
    public class PHANQUYEN_DAL
    {
        private DataContext db = new DataContext();
        //return 1 list
        public List<PHANQUYEN> getList()
        {
            return db.PHANQUYENs.ToList();
        }
        //return 1 item
        public PHANQUYEN getRow(string id)
        {
            if (id == null)
            {
                return null;
            }
            else
            {
                return db.PHANQUYENs.Find(id);
            }
        }
        //add item
        public int Insert(PHANQUYEN row)
        {
            db.PHANQUYENs.Add(row);
            return db.SaveChanges();
        }
        //update
        public int Edit(PHANQUYEN row)
        {
            db.Entry(row).State = EntityState.Modified;
            return db.SaveChanges();
        }
        //delete
        public int Delete(PHANQUYEN row)
        {
            db.PHANQUYENs.Remove(row);
            return db.SaveChanges();
        }
    }
}