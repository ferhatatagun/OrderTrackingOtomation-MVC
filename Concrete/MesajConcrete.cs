using _SiparisTakipSistemi.Abstract;
using _SiparisTakipSistemi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _SiparisTakipSistemi.Concrete
{
    public class MesajConcrete : IDataBusiness<Mesaj>
    {
        public bool DeleteData(Mesaj model, int Id)
        {
            try
            {
                using (SiparisTakipEntities db = new SiparisTakipEntities())
                {
                    db.Mesajs.Remove(model);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool InsertData(Mesaj model)
        {

            try
            {
                using (SiparisTakipEntities db = new SiparisTakipEntities())
                {
                    db.Mesajs.Add(model);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<Mesaj> ListData()
        {
            using (SiparisTakipEntities db = new SiparisTakipEntities())
            {
                return db.Mesajs.ToList();
            }
        }

        public Mesaj SelectData(int id)
        {
            using (SiparisTakipEntities db = new SiparisTakipEntities())
            {
                return db.Mesajs.Find(id);
            }
        }

        public bool UpdateData(Mesaj model)
        {
            try
            {
                using (SiparisTakipEntities db = new SiparisTakipEntities())
                {
                    db.Mesajs.Add(model);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}