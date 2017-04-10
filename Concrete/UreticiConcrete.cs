using _SiparisTakipSistemi.Abstract;
using _SiparisTakipSistemi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _SiparisTakipSistemi.Concrete
{
    public class UreticiConcrete : IDataBusiness<Uretici>
    {
        public bool DeleteData(Uretici model, int Id)
        {
            try
            {
                using (SiparisTakipEntities db = new SiparisTakipEntities())
                {
                    db.Ureticis.Remove(model);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool InsertData(Uretici model)
        {
            try
            {
                using (SiparisTakipEntities db = new SiparisTakipEntities())
                {
                    db.Ureticis.Add(model);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
           
        }

        public List<Uretici> ListData()
        {
            using (SiparisTakipEntities db = new SiparisTakipEntities())
            {
                return db.Ureticis.ToList();
            }
        }

        public Uretici SelectData(int id)
        {
            using (SiparisTakipEntities db = new SiparisTakipEntities())
            {
                return db.Ureticis.Find(id);
            }
        }

        public bool UpdateData(Uretici model)
        {
            try
            {
                using (SiparisTakipEntities db = new SiparisTakipEntities())
                {
                    db.Ureticis.Remove(model);
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