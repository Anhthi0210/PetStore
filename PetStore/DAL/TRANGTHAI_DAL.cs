using PetStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PetStore.DAL
{
    public class TRANGTHAI_DAL
    {
        private DataContext db = new DataContext();
        //return 1 list
        public List<TRANGTHAI> getList()
        {
            return db.TRANGTHAIs.ToList();
        }
        //return 1 item
        public TRANGTHAI getRow(string id)
        {
            if (id == null)
            {
                return null;
            }
            else
            {
                return db.TRANGTHAIs.Find(id);
            }
        }
        //add item
        public int Insert(TRANGTHAI row)
        {
            db.TRANGTHAIs.Add(row);
            return db.SaveChanges();
        }
        //update
        public int Edit(TRANGTHAI row)
        {
            db.Entry(row).State = EntityState.Modified;
            return db.SaveChanges();
        }
        //delete
        public int Delete(TRANGTHAI row)
        {
            db.TRANGTHAIs.Remove(row);
            return db.SaveChanges();
        }
    }
}