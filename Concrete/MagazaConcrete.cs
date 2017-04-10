using _SiparisTakipSistemi.Abstract;
using _SiparisTakipSistemi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _SiparisTakipSistemi.Concrete
{
    public class MagazaConcrete : IDataBusiness<Magaza>
    {
        public bool DeleteData(Magaza model, int Id)
        {
            try
            {
                using (SiparisTakipEntities db = new SiparisTakipEntities())
                {
                    db.Magazas.Remove(model);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool InsertData(Magaza model)
        {
            try
            {
                using (SiparisTakipEntities db = new SiparisTakipEntities())
                {
                    db.Magazas.Add(model);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;

            }
        }

        public List<Magaza> ListData()
        {
            using (SiparisTakipEntities db = new SiparisTakipEntities())
            {
                return db.Magazas.ToList();
            }
        }

        public Magaza SelectData(int id)
        {
            using (SiparisTakipEntities db = new SiparisTakipEntities())
            {
                return db.Magazas.Find(id);
            }
        }

        public bool UpdateData(Magaza model)
        {
            try
            {
                using (SiparisTakipEntities db = new SiparisTakipEntities())
                {
                    db.Magazas.Add(model);
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