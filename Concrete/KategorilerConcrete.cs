using _SiparisTakipSistemi.Abstract;
using _SiparisTakipSistemi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _SiparisTakipSistemi.Concrete
{
    public class KategorilerConcrete : IDataBusiness<Kategoriler>
    {
        public bool DeleteData(Kategoriler model, int Id)
        {
            try
            {
                using (SiparisTakipEntities db = new SiparisTakipEntities())
                {
                    db.Kategorilers.Remove(model);
                    db.SaveChanges();
                    return true;

                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool InsertData(Kategoriler model)
        {
            try
            {
                using (SiparisTakipEntities db = new SiparisTakipEntities())
                {
                    db.Kategorilers.Add(model);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Kategoriler> ListData()
        {
            {
                using (SiparisTakipEntities db = new SiparisTakipEntities())
                {
                   return db.Kategorilers.ToList();

                }
            }
        }

        public Kategoriler SelectData(int id)
        {
            using (SiparisTakipEntities db = new SiparisTakipEntities())
            {
                return db.Kategorilers.Find(id);
            }
        }

        public bool UpdateData(Kategoriler model)
        {
            try
            {
                using (SiparisTakipEntities db = new SiparisTakipEntities())
                {
                    db.Kategorilers.Add(model);
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