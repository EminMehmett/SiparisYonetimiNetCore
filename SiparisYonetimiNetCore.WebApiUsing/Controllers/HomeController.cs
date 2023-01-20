using Microsoft.AspNetCore.Mvc;
using SiparisYonetimiNetCore.Entities;
using SiparisYonetimiNetCore.WebApiUsing.Models;
using SiparisYonetimiNetCore.WebUI.Models;
using System.Diagnostics;

namespace SiparisYonetimiNetCore.WebApiUsing.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiAdres;
        public HomeController(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _apiAdres = "https://localhost:7252/api/";
        }



        public async Task<IActionResult> IndexAsync()
        {
            var model = new HomePageViewModel
            {
                Slides = await _httpClient.GetFromJsonAsync<List<Slide>>(_apiAdres + "Slider"),
                Products = await _httpClient.GetFromJsonAsync<List<Product>>(_apiAdres + "Products"),
                Brands = await _httpClient.GetFromJsonAsync<List<Brand>>(_apiAdres + "Brands"),
            };
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}