using PetStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PetStore.DAL
{
    public class NHACUNGCAP_DAL
    {
        private DataContext db = new DataContext();
        //return 1 list
        public List<NHACUNGCAP> getList()
        {
            return db.NHACUNGCAPs.ToList();
        }
        //return 1 item
        public NHACUNGCAP getRow(string id)
        {
            if (id == null)
            {
                return null;
            }
            else
            {
                return db.NHACUNGCAPs.Find(id);
            }
        }
        //add item
        public int Insert(NHACUNGCAP row)
        {
            db.NHACUNGCAPs.Add(row);
            return db.SaveChanges();
        }
        //update
        public int Edit(NHACUNGCAP row)
        {
            db.Entry(row).State = EntityState.Modified;
            return db.SaveChanges();
        }
        //delete
        public int Delete(NHACUNGCAP row)
        {
            db.NHACUNGCAPs.Remove(row);
            return db.SaveChanges();
        }
    }
}