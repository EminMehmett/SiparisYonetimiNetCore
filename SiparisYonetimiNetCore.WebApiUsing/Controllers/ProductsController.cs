using Microsoft.AspNetCore.Mvc;
using NuGet.Packaging.Signing;
using SiparisYonetimiNetCore.Entities;

namespace SiparisYonetimiNetCore.WebApiUsing.Controllers
{
    public class ProductsController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiAdres;
        public ProductsController(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _apiAdres = "https://localhost:7252/api/";
        }
        public async Task<ActionResult> Index()
        {
            var model = await _httpClient.GetFromJsonAsync<List<Product>>(_apiAdres + "Products");
            return View(model);
        }
        public async Task<ActionResult> Detail(int id)
        {
            var list = await _httpClient.GetFromJsonAsync<List<Product>>(_apiAdres + "Products");
            var model = list.FirstOrDefault(p => p.Id == id);
            return View(model); 
        }
    }
}
