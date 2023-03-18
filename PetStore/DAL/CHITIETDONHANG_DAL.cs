using PetStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PetStore.DAL
{
    public class CHITIETDONHANG_DAL
    {
        private DataContext db = new DataContext();
        //return 1 list
        public List<CHITIETDONHANG> getList()
        {
            return db.CHITIETDONHANGs.ToList();
        }
        //return 1 item
        public CHITIETDONHANG getRow(string id)
        {
            if (id == null)
            {
                return null;
            }
            else
            {
                return db.CHITIETDONHANGs.Find(id);
            }
        }
        //add item
        public int Insert(CHITIETDONHANG row)
        {
            db.CHITIETDONHANGs.Add(row);
            return db.SaveChanges();
        }
        //update
        public int Edit(CHITIETDONHANG row)
        {
            db.Entry(row).State = EntityState.Modified;
            return db.SaveChanges();
        }
        //delete
        public int Delete(CHITIETDONHANG row)
        {
            db.CHITIETDONHANGs.Remove(row);
            return db.SaveChanges();
        }
    }
}