using Microsoft.AspNetCore.Mvc;
using SiparisYonetimiNetCore.Entities;
using SiparisYonetimiNetCore.Service.Abstract;
using System.Threading.Tasks;

namespace SiparisYonetimiNetCore.WebUI.ViewComponents
{
    public class Categories : ViewComponent
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiAdres;
        public Categories(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _apiAdres = "https://localhost:7252/api/Categories";
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var request = await _httpClient.GetFromJsonAsync<List<Category>>(_apiAdres);
            return View(request);
        }
    }
}
