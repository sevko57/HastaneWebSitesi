using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication7.Models.Entity;
using WebApplication7.Models.ViewModel;

namespace WebApplication7.Controllers
{
    public class HomeController : Controller
    {
        hastaneEntities db = new hastaneEntities();
        public ActionResult Anasayfa()
        {


            return View();
        }
        public ActionResult Galeri()
        {


            return View();
        }
        public ActionResult Hakkımızda()
        {


            return View();
        }
        public ActionResult Hekimler()
        {


            return View();
        }
        public ActionResult İletişim()
        {


            return View();
        }
        public ActionResult Görüşler()
        {


            return View();
        }
        [HttpPost]
        public ActionResult Görüşler(Iletisim mesajlar)
        {
            Kullanicilar dbKullanicilar = this.checkTc(mesajlar.Kullanicilar.tc_no);

            if (dbKullanicilar != null)
            {
                mesajlar.Kullanicilar = dbKullanicilar;
            }

            db.Iletisim.Add(mesajlar);
            int sonuc = db.SaveChanges();
            if (sonuc > 0)
            {
                ViewBag.Result = "Gönderim Başarılı";
            }
            else
            {
                ViewBag.Result = "Gönderim Başarısız";
            }
            return View();
        }

        private Kullanicilar checkTc(string tc)
        {
            Kullanicilar kullanicilar = db.Kullanicilar.FirstOrDefault(x => x.tc_no == tc);
            return kullanicilar;

        }

        public ActionResult Girişyap()
        {


            return View();
        }
        [HttpPost]
        public ActionResult Girişyap(Kullanicilar user)
        {

            var giris = db.Kullanicilar.FirstOrDefault(m => m.tc_no == user.tc_no && m.sifre == user.sifre);
            if (giris != null)
            {
                return RedirectToAction("Kullanici", "Home");
            }
            else
            {
                ViewBag.Result = "Kullanıcı Adı veya Şifre Hatalı";
                return View();
            }

        }
        public ActionResult Üyeol()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Üyeol(Kullanicilar kullanici)
        {
            db.Kullanicilar.Add(kullanici);
            int sonuc = db.SaveChanges();
            if (sonuc > 0)
            {
                ViewBag.Result = "Kayıt Başarılı";
                ViewBag.Status = "success";
            }
            else
            {
                ViewBag.Result = "Kayıt Başarısız.. Alanları Doğru Girdiğinizden Emin Olunuz.";
                ViewBag.Status = "danger";

            }
            return View();
        }
        public ActionResult Birimler(int? birim_id)
        {
            BirimlerViewModel birimlerViewModel = new BirimlerViewModel();
            List<SelectListItem> birimler = db.Birimler.Select(m => new SelectListItem
            {
                Text = m.birim_adi,
                Value = m.birim_id.ToString()
            }).ToList();
            if (birim_id.HasValue)
            {
                var doktorlar = db.Doktorlar.Where(m => m.birim_id == birim_id).ToList();
                var fiyatlar = db.Fiyat.Where(m => m.birim_id == birim_id).ToList();
                List<string> fiyatlarList = new List<string>();
                foreach (Fiyat item in fiyatlar)
                {
                    if (item.fiyat1.HasValue)
                    {
                        fiyatlarList.Add(item.fiyat1.Value.ToString());
                    }
                }

                birimlerViewModel.Fiyats = fiyatlarList;
                birimlerViewModel.Doktorlars = doktorlar;
            }
            birimlerViewModel.Birimlers = birimler;
            ViewBag.brm = birimler;

            return View(birimlerViewModel);
        }
        public ActionResult Kullanici()
        {
            KullaniciVievModel kullaniciVievModel = new KullaniciVievModel();
            kullaniciVievModel.Randevulars = db.Randevular.ToList();
            kullaniciVievModel.Kullanicilars = db.Kullanicilar.ToList();
            return View();
        }

        public ActionResult Randevu()
        {
            return View(this.GetRandevuPage());
        }


        [HttpPost]
        public ActionResult Randevu(Randevular randevular)
        {
            Kullanicilar kullanicilar = db.Kullanicilar.FirstOrDefault(x => x.tc_no == randevular.Kullanicilar.tc_no);

            randevular.Kullanicilar = kullanicilar;

            db.Randevular.Add(randevular);
            db.SaveChanges();


            return View(this.GetRandevuPage());
        }

        [HttpGet]
        public JsonResult GetDoktorlar(int klinikId)
        {
            var doktorlar = db.Doktorlar.Where(x => x.birim_id == klinikId).ToList();
            foreach (var item in doktorlar)
            {
                item.Randevular = null;
                item.Birimler = new Birimler();
            }
            return Json(new { data = doktorlar }, JsonRequestBehavior.AllowGet);
        }

        /**
         * Randevu alma sayfasının ilgili birimlerinin dolu gelmesi için eklenen işlemlerin olduğu metot.
         * Aynı action'un post metodunda da verileri gönderebilmek için bu metodu yazdık.
         * Bu metodu sadece bu class içerisinde kullanacağımız için erişim belirtecini Private yaptık.
         */
        private RandevuViewModel GetRandevuPage()
        {
            RandevuViewModel randevuViewModel = new RandevuViewModel();
            List<SelectListItem> birimler = db.Birimler
                        .Select(x => new SelectListItem
                        {
                            Text = x.birim_adi,
                            Value = x.birim_id.ToString()
                        }).ToList();

            randevuViewModel.Birimlers = birimler;
            randevuViewModel.Kullanicilars = db.Kullanicilar.ToList();
            return randevuViewModel;
        }

        [HttpGet]
        public PartialViewResult GetRandevular(string tc)
        {
            var list = db.Randevular.Where(x => x.Kullanicilar.tc_no == tc).ToList();
            return PartialView(list);
        }

        [HttpGet]
        public ActionResult DeleteRandevu(int randevuId)
        {
            var randevu = db.Randevular.FirstOrDefault(x => x.Randevu_id == randevuId);
            if (randevu != null)
            {
                db.Randevular.Remove(randevu);
                db.SaveChanges();
            }
            return RedirectToAction("Kullanici", "Home");
        }

        public ActionResult RandevuGuncelle(int randevuId)
        {
            var randevu = db.Randevular.FirstOrDefault(x => x.Randevu_id == randevuId);
            return View(randevu);
        }

        [HttpPost]
        public ActionResult RandevuGuncelle(Randevular randevular)
        {
            //db.Randevular.Add(randevular);
            var randevu = db.Randevular.Find(randevular.Randevu_id);
            randevu.Randevu_saat = randevular.Randevu_saat;
            db.SaveChanges();
            return RedirectToAction("Kullanici","Home");
        }
    }
}