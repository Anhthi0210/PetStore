using PetStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PetStore.DAL
{
    public class LOAIPET_DAL
    {
        private DataContext db = new DataContext();
        //return 1 list
        public List<LOAIPET> getList()
        {
            return db.LOAIPETs.ToList();
        }
        //return 1 item
        public LOAIPET getRow(string id)
        {
            if (id == null)
            {
                return null;
            }
            else
            {
                return db.LOAIPETs.Find(id);
            }
        }
        //add item
        public int Insert(LOAIPET row)
        {
            db.LOAIPETs.Add(row);
            return db.SaveChanges();
        }
        //update
        public int Edit(LOAIPET row)
        {
            db.Entry(row).State = EntityState.Modified;
            return db.SaveChanges();
        }
        //delete
        public int Delete(LOAIPET row)
        {
            db.LOAIPETs.Remove(row);
            return db.SaveChanges();
        }
    }
}