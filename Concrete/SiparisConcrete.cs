using _SiparisTakipSistemi.Abstract;
using _SiparisTakipSistemi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _SiparisTakipSistemi.Concrete
{
    public class SiparisConcrete : IDataBusiness<Sipari>
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
                List<Sipari> tempList = new List<Sipari>();
                List<Urunler> tempList2 = new List<Urunler>();

                var siparisList = db.Siparis.ToList();
                var urunlerList = db.Siparis.ToList();
                var magazaList = db.Magazas.ToList();

                for (int i = 0; i < siparisList.Count; i++)
                {
                    var currentMagaza = magazaList.Where(x => x.MagazaId == siparisList[i].MagazaId).FirstOrDefault();
                    tempList.Add(new Sipari()
                    {
                        SiparisId=siparisList[i].SiparisId,
                        Magaza = currentMagaza,
                        SiparisTarihi = siparisList[i].SiparisTarihi,
                        SiparisDurumu = siparisList[i].SiparisDurumu,
                        Adet =siparisList[i].Adet,
                        UrunId=siparisList[i].UrunId,
                        //UreticiId=siparisList[i].UreticiId,
                        //MagazaId=siparisList[i].MagazaId,    
                        //Uretici=siparisList[i].Uretici,
                        
                        Urunler = new Urunler()
                        {
                            UrunAdi = urunlerList[i].Urunler.UrunAdi,
                            Model = urunlerList[i].Urunler.Model,
                        },
                        IsSelected = false
                    });
                }

                //foreach (var item in db.Siparis.ToList())
                //{
                //    tempList.Add(new Sipari()
                //    {
                //        Magaza = db.Magazas.Where(x => x.MagazaId == item.MagazaId).FirstOrDefault(),
                //        SiparisTarihi = item.SiparisTarihi,
                //        SiparisDurumu = item.SiparisDurumu,

                //    });
                //    foreach (var item2 in db.Siparis.ToList())
                //    {
                //        tempList2.Add(new Urunler()
                //        {
                //            UrunAdi = item2.Urunler.UrunAdi,
                //            Model = item2.Urunler.Model,


                //        });
                //    }
                //    return tempList;
                //}

                return tempList;

            }

        }
        public List<SP_SiparisDurumları_Result> Liste()
        {
            using (SiparisTakipEntities db = new SiparisTakipEntities())
            {
                return db.SP_SiparisDurumları().ToList();
            }
        }
        public List<Sipari> Liste2()
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
    }
}