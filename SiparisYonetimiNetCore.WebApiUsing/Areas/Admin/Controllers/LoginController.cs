﻿using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using SiparisYonetimiNetCore.Entities;
using SiparisYonetimiNetCore.Service.Abstract;
using SiparisYonetimiNetCore.WebUI.Models;
using System.Security.Claims;

namespace SiparisYonetimiNetCore.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginController : Controller
    {
        private readonly IService<User> _service;

        public LoginController(IService<User> service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> LogoutAsync()
        {
            await HttpContext.SignOutAsync(); // Çıkış Yap 
            return RedirectToAction("Index"); // ve kullanıcıyı logine tekrar yönlendir
        }
        [HttpPost]
        public async Task<IActionResult> IndexAsync(AdminLoginViewModel user)
        {
            try
            {
                var kul = await _service.FirstOrDefaultAsync(u => u.Email == user.Email && u.Password == user.Password && u.IsActive);
                if (kul == null)
                {
                    ModelState.AddModelError("", "Giriş Başarısız!");
                }
                else
                {
                    var haklar = new List<Claim>() // Claim = Hak
                    {
                        new Claim(ClaimTypes.Name, kul.Name),
                        new Claim("Role",kul.IsAdmin? "Admin" : "User") // eğer kullanıcı adminse admin yetkisi değilse kullanıcı yetkisi ver
                    };
                    var kullaniciKimligi = new ClaimsIdentity(haklar,"Login");
                    ClaimsPrincipal principal = new(kullaniciKimligi);
                    await HttpContext.SignInAsync(principal);
                    return Redirect("/Admin/Main");

                }
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Hata Oluştu!");
            }
            return View(user);
        }
    }
}
