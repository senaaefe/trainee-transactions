using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using HR_SEFE.Models;
using System.Web.Security;
using System.Configuration;




namespace HR_SEFE.Controllers
{
    public class HomeController : Controller
    {

        HREntities10 db = new HREntities10();

        //GET: basvuru        
             
        public ActionResult Index()
        {
            return View();
        }






        
        public ActionResult kisi()

        {
            return View();
        }

        [HttpPost]
        public ActionResult kisi(basvuru model,basvuru kisi)
        {
            if (ModelState.IsValid)
            {
                db.basvuru.Add(kisi);
                kisi.secilen = "Hayır";
                db.SaveChanges();
                ViewBag.sonuc = "KAYIT YAPILDI!";

                return View("kisi");
            }
            ViewBag.sonuc = "KAYIT YAPILMADI!";
           return View();

        }








        public ActionResult uye(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult uye(admin model, string returnUrl)
        {
            var count = db.admin.Where(x => x.kullanici == model.kullanici && x.sifre == model.sifre).Count();

            if (count == 0)
            {
                ViewBag.Msg = "KULLANICI BULUNAMADI!";
                return View();
            }
            else
            {
                FormsAuthentication.SetAuthCookie(model.kullanici, false);
                return RedirectToLocal(returnUrl);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("basvurukonrol");
            }
        }








        public ActionResult basvurukonrol()

        {
           
            return View();
        }









        public ActionResult basvuruliste()

        {
            var model = db.basvuru.ToList().Where(i=>i.secilen== "Hayır");
           
            return View(model);
        }
 
        






        public ActionResult basvurusecilen()
        {

            var model = db.basvuru.ToList().Where(i => i.secilen == "Evet");
            return View(model);

        }









        public ActionResult ekle(int ID)

        {
            using (HREntities10 db = new HREntities10())
            {

                var kategori = db.basvuru.Find(ID);
                kategori.secilen = "Evet";
                db.SaveChanges();
                return RedirectToAction("basvuruliste");

            }


        }








        public ActionResult sil(int ID)

        {
            using (HREntities10 db = new HREntities10())
            {
                var kategori = db.basvuru.Find(ID);
            kategori.secilen = "Hayır";
            db.SaveChanges();
            return RedirectToAction("basvurusecilen");
            }
        }








        public ActionResult cikis()

        {
            Session.Abandon();
            Session.Clear();
            Session.RemoveAll();

            FormsAuthentication.SignOut();

            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetExpires(DateTime.Now);

            return View();
        }


        
    }
}

