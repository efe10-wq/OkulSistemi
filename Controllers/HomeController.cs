using Microsoft.AspNetCore.Mvc;
using OkulSistemi.Models;

namespace OkulSistemi.Controllers;

public class HomeController : Controller
{
    private readonly OkulContext _db;
    public HomeController(OkulContext db) { _db = db; }

    // 1. KAYIT OLMA SAYFASI (Giriş Formu)
    public IActionResult Kayit()
    {
        return View();
    }

    // 2. KAYIT OLMA İŞLEMİ (POST)
    [HttpPost]
    public IActionResult Kayit(Kullanici yeniKullanici)
    {
        if (ModelState.IsValid)
        {
            _db.Kullanicilar.Add(yeniKullanici);
            _db.SaveChanges();
            return RedirectToAction("Basarili");
        }
        return View(yeniKullanici);
    }

    public IActionResult Basarili() => Content("Kayıt başarıyla tamamlandı!");

    // 3. YÖNETİCİ PANELİ (Sadece kayıtlı olanları listeler)
    public IActionResult YoneticiPaneli()
    {
        var liste = _db.Kullanicilar.ToList();
        return View(liste);
    }
}
