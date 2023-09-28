using Microsoft.AspNetCore.Mvc;
using ProjeCore.Models;

namespace ProjeCore.Controllers
{
    public class DefaultController : Controller
    {
        Context c = new Context();
        public IActionResult Index()
        {
            var degerler = c.Birims.ToList();
            return View(degerler);
        }

        [HttpGet]
        public IActionResult YeniBirim()
        {
            return View();
        }
        [HttpPost]
        public IActionResult YeniBirim(Birim b)
        {
            c.Birims.Add(b);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult BirimSil(int id)
        {
            var birim = c.Birims.Find(id);
            c.Birims.Remove(birim);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult    BirimGetir(int id)
        {
            var depart = c.Birims.Find(id);
            return View(depart);
        }
        public IActionResult BirimGuncelle(Birim b)
        {
            var dep = c.Birims.Find(b.BirimID);
            dep.BirimAd = b.BirimAd;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult BirimDetay(int id)
        {
            var degerler=c.Personels.Where(x=>x.BirimID==id).ToList();
            var brmad =c.Birims.Where(x => x.BirimID == id).Select(y=>y.BirimAd).FirstOrDefault();
            ViewBag.brm=brmad;
            return View(degerler);
        }
    }
}
