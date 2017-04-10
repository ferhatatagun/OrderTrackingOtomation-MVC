using _SiparisTakipSistemi.Abstract;
using _SiparisTakipSistemi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _SiparisTakipSistemi.Concrete
{
    public class SiparisGirConcrete : IDataBusiness<Sipari>
    {
        public bool DeleteData(Sipari model, int Id)
        {
            try
            {
                using (SiparisTakipEntities db = new SiparisTakipEntities())
                {
                    db.Siparis.Remove(model);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;

            }
        }

        public bool InsertData(Sipari model)
        {
            try
            {
                using (SiparisTakipEntities db = new SiparisTakipEntities())
                {
                    db.Siparis.Add(model);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<Sipari> ListData()
        {
            using (SiparisTakipEntities db = new SiparisTakipEntities())
            {
                return db.Siparis.ToList();
            }
        }

        public Sipari SelectData(int id)
        {
            using (SiparisTakipEntities db = new SiparisTakipEntities())
            {
                return db.Siparis.Find(id);
            }
        }

        public bool UpdateData(Sipari model)
        {
            try
            {
                using (SiparisTakipEntities db = new SiparisTakipEntities())
                {
                    var currentitem = db.Siparis.Where(x => x.SiparisId == model.SiparisId).FirstOrDefault();
                    currentitem.Adet = model.Adet;
                    currentitem.SiparisTarihi = model.SiparisTarihi;
                    currentitem.SiparisDurumu = model.SiparisDurumu;
                    currentitem.Magaza.SorumluAdi = model.Magaza.SorumluAdi;
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