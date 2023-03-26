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
            return db.TRANGTHAI.ToList();
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
                return db.TRANGTHAI.Find(id);
            }
        }
        //add item
        public int Insert(TRANGTHAI row)
        {
            db.TRANGTHAI.Add(row);
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
            db.TRANGTHAI.Remove(row);
            return db.SaveChanges();
        }
    }
}