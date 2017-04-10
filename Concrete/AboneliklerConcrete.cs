using _SiparisTakipSistemi.Abstract;
using _SiparisTakipSistemi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _SiparisTakipSistemi.Concrete
{
    public class AboneliklerConcrete : IDataBusiness<Abonelikler>

    {
        public bool DeleteData(Abonelikler model,int id)
        {
            try
            {
                using (SiparisTakipEntities db = new SiparisTakipEntities())
                {
                    db.Aboneliklers.Remove(model);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool InsertData(Abonelikler model)
        {
            try
            {
                using (SiparisTakipEntities db = new SiparisTakipEntities())
                {
                    db.Aboneliklers.Add(model);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {

                return false;

            }
        }

        public List<Abonelikler> ListData()
        {
            {
                using (SiparisTakipEntities db = new SiparisTakipEntities())
                {
                     return db.Aboneliklers.ToList();
                }
            }

        }

        public Abonelikler SelectData(int id)
        {
            using (SiparisTakipEntities db = new SiparisTakipEntities())
            {
                return db.Aboneliklers.Find(id);
            }
        }

        public bool UpdateData(Abonelikler model)
        {
            try
            {
                using (SiparisTakipEntities db = new SiparisTakipEntities())
                {
                    db.Aboneliklers.Add(model);
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