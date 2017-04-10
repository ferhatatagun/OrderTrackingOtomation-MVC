using _SiparisTakipSistemi.Concrete;
using _SiparisTakipSistemi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using _SiparisTakipSistemi.Models.ViewModels;

namespace _SiparisTakipSistemi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult AylıkRapor()
        {
            return View();
        }
        public ActionResult HaftalıkRapor()
        {
            return View();
        }
        public ActionResult YıllıkRapor()
        {
            return View();
        }
        public ActionResult TumRaporlama()
        {
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Hakkımızda.";

            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "İletişim.";
            return View();
        }
        public ActionResult SiparisGir()
        {

            var magaza = magc.ListData();
            var urunler = urunlerc.ListData();
            var uretici = ureticic.ListData();
            var db = new SiparisTakipEntities();
            ViewBag.magaza = new SelectList(db.Magazas, "MagazaId", "SorumluAdi");
            ViewBag.urunler = new SelectList(db.Urunlers, "UrunId", "UrunAdi");
            ViewBag.uretici = new SelectList(db.Ureticis, "UreticiId", "UreticiAdi");

            ViewBag.Message = "SiparisGir";
            return View();
        }

        SiparisGirConcrete sc = new SiparisGirConcrete();
        MagazaConcrete magc = new MagazaConcrete();
        UrunlerConcrete urunlerc = new UrunlerConcrete();
        UreticiConcrete ureticic = new UreticiConcrete();
        KategorilerConcrete kategoric = new KategorilerConcrete();
        [HttpPost]
        public ActionResult SiparisGir(Sipari siparis)
        {
            var db = new SiparisTakipEntities();
            ViewBag.magaza = new SelectList(db.Magazas, "MagazaId", "SorumluAdi");
            ViewBag.urunler = new SelectList(db.Urunlers, "UrunId", "UrunAdi");
            ViewBag.uretici = new SelectList(db.Ureticis, "UreticiId", "UreticiAdi");
            var result = sc.InsertData(siparis);
            return View(siparis);
        }
        public ActionResult SiparisDuzenle(int siparisId)
        {
            var db = new SiparisTakipEntities();
            ViewBag.magaza = new SelectList(db.Magazas, "MagazaId", "SorumluAdi");

            var selectedSiparis = sprsc.SelectData(siparisId);
            return View(selectedSiparis);
        }
        SiparisGirConcrete scc = new SiparisGirConcrete();
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SiparisDuzenle(Sipari siparis)
        {
            var db = new SiparisTakipEntities();
            ViewBag.magaza = new SelectList(db.Magazas, "MagazaId", "SorumluAdi");

            scc.UpdateData(siparis);
            return View(siparis);
        }
        public ActionResult MesajGonder()
        {
            return View();
        }
        MesajConcrete mc = new MesajConcrete();
        [HttpPost]
        public ActionResult MesajGonder(Mesaj mesaj)
        {
            var db = new SiparisTakipEntities();
            ViewBag.magaza = new SelectList(db.Magazas, "MagazaId", "SorumluAdi");
            ViewBag.urunler = new SelectList(db.Urunlers, "UrunId", "UrunAdi");

            mc.InsertData(mesaj);
            return View(mesaj);
        }
        public ActionResult GelenKutusu(Mesaj mesaj)
        {
            var db = new SiparisTakipEntities();
            var urunler = urunlerc.ListData();
            var mesajss = mc.ListData();

            ViewBag.mesajs = new SelectList(db.Mesajs, "Mesaj1", "Mesaj");
            mc.ListData();
            return View(mesajss);
        }
        SiparisGirConcrete tsc = new SiparisGirConcrete();
        SiparisConcrete sprsc = new SiparisConcrete();
        public ActionResult TumSiparisler()
        {
            //var db = new SiparisTakipEntities();
            //var magazas = magc.ListData();
            //ViewBag.magaza = new SelectList(db.Magazas, "MagazaId", "SorumluAdi");
            var siparis = sprsc.ListData();
            TumSiparislerViewModel vModel = new TumSiparislerViewModel();
            vModel.Siparisler = siparis;

            return View(vModel);
        }
        public ActionResult UrunBilgisi(int id)
        {
            ViewBag.Message = "UrunBilgisi";

            return View(urunlerc.UrunlerDetailsData(id));
        }
        public ActionResult UrunGir()
        {  
            var urunler = urunlerc.ListData();
            var kategori = kategoric.ListData();
            
            var db = new SiparisTakipEntities();
       
           
            ViewBag.kategori = new SelectList(db.Kategorilers, "KategoriId", "KategoriAdi");
            ViewBag.Message = "UrunGir";
            return View();
        }
        [HttpPost]
        public ActionResult UrunGir(Urunler urungir)
        {
            var db = new SiparisTakipEntities();
            var result = urunlerc.InsertData(urungir);

            ViewBag.kategori = new SelectList(db.Kategorilers, "KategoriId", "KategoriAdi");
            return View(urungir);
        }
        public ActionResult UrunDuzenle(Urunler urund)
        {
            var db = new SiparisTakipEntities();
            ViewBag.kategori = new SelectList(db.Kategorilers, "KategoriId", "KategoriAdi");
            ViewBag.urunler = new SelectList(db.Urunlers, "UrunId", "UrunAdi");

            urunlerc.UpdateData(urund);
            return View(urund);
        }
        public ActionResult DeleteUrunler(Urunler model, int id)
        {
           
                if (ModelState.IsValid)
                {
                    urunlerc.DeleteData(model, id);

                }
                return RedirectToAction("TumUrunler", "Home");
           
           
        }
        public ActionResult TumUrunler()
        {
            var urunler = urunlerc.ListData();
            var kategori = kategoric.ListData();
            var db = new SiparisTakipEntities();


            ViewBag.Message = "TumUrunler";
            return View(urunler);
        }
        int pageSize = 4;
        SiparisConcrete ad = new SiparisConcrete();
        public ViewResult SiparisDurumlari(int page = 1)
        {
            SiparisDurumlarıVm m = new Models.ViewModels.SiparisDurumlarıVm();
            m.SiparisDurumlari = (ad.Liste().OrderByDescending(x => x.UrunId).Skip((page - 1) * pageSize).Take(pageSize));
            m.PagingInfo = new PagingInfo
            {
                CurrentPage = page,
                ItemsPerPage = pageSize,
                TotalItems = ad.Liste().Count
            };
            return View(m);

        }
        #region PAging olanak olmayan hatası 
        //public ViewResult TumSiparisler(int page = 1)
        //{
        //    TumSiparislerViewModel m = new Models.TumSiparislerViewModel();
        //    m.TumSiparisler = (ad.Liste2().OrderByDescending(x => x.UrunId).Skip((page - 1) * pageSize).Take(pageSize));
        //    m.PagingInfo = new PagingInfo
        //    {
        //        CurrentPage = page,
        //        ItemsPerPage = pageSize,
        //        TotalItems = ad.Liste().Count
        //    };
        //    return View(m);

        //}
        #endregion
    }
}