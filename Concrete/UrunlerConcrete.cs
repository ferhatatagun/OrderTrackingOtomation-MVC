using _SiparisTakipSistemi.Abstract;
using _SiparisTakipSistemi.Models;
using _SiparisTakipSistemi.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _SiparisTakipSistemi.Concrete
{
    public class UrunlerConcrete : IDataBusiness<Urunler>
    {
        public bool DeleteData(Urunler model, int Id)
        {
            try
            {
                using (SiparisTakipEntities db = new SiparisTakipEntities())
                {
                    var urun = (from urunsil in db.Urunlers where urunsil.UrunId == Id select urunsil).FirstOrDefault();
                    db.Urunlers.Remove(urun);
                    db.SaveChanges();


                    return true;
                }
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool InsertData(Urunler model)
        {
            try
            {
                using (SiparisTakipEntities db = new SiparisTakipEntities())
                {
                    db.Urunlers.Add(model);
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {

                return false;
            }
        }

        public List<Urunler> ListData()
        {
            using (SiparisTakipEntities db = new SiparisTakipEntities())
            {
                return db.Urunlers.ToList();
            }

        }

        public Urunler SelectData(int id)
        {
            using (SiparisTakipEntities db = new SiparisTakipEntities())
            {
                return db.Urunlers.Find(id);
            }
        }

        public bool UpdateData(Urunler model)
        {
            //    try
            //    {
            //        using (SiparisTakipEntities db = new SiparisTakipEntities())
            //        {
            //            db.Urunlers.Add(model);
            //            db.SaveChanges();
            //            return true;
            //        }
            //    }
            //    catch (Exception)
            //    {
            //        return false;
            //    }
            //}
            try
            {
                using (SiparisTakipEntities db = new SiparisTakipEntities())
                {
                    var currentitem = db.Urunlers.Where(x => x.UrunId == model.UrunId).FirstOrDefault();
                    currentitem.UrunId = model.UrunId;
                    currentitem.KategoriId = model.KategoriId;
                    db.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        public UrunDetay UrunlerDetailsData(int id)
        {
            using (SiparisTakipEntities db = new SiparisTakipEntities())
            {
                UrunDetay model = new UrunDetay();
                SP_UrunlerJoin_Result urun = this.Select(id);
                model.DetailsofUrunler = urun;
                return model;
            }
        }
        public SP_UrunlerJoin_Result Select(int id)
        {
            using (SiparisTakipEntities db = new SiparisTakipEntities())
            {
                return db.SP_UrunlerJoin().ToList().Find(x => x.UrunId == id);
            }
        }
    }
}