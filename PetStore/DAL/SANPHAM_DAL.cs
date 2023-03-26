using PetStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace PetStore.DAL
{
    public class SANPHAM_DAL
    {
        private DataContext db = new DataContext();
        //return 1 list

        public List<SANPHAM> getList()
        {
            return db.SANPHAM.ToList();
        }

        public SANPHAM getRow(string id)
        {
            if (id == null)
            {
                return null;
            }
            else
            {
                return db.SANPHAM.Find(id);
            }
        }
        //add item
        public int Insert(SANPHAM row)
        {
            db.SANPHAM.Add(row);
            return db.SaveChanges();
        }
        //update
        public int Edit(SANPHAM row)
        {
            db.Entry(row).State = EntityState.Modified;
            return db.SaveChanges();
        }
        //delete
        public int Delete(SANPHAM row)
        {
            db.SANPHAM.Remove(row);
            return db.SaveChanges();
        }
    }
}