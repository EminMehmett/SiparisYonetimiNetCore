using SiparisYonetimiNetCore.Entities;

namespace SiparisYonetimiNetCore.WebApiUsing.Models
{
    public class HomePageViewModel
    {
        public List<Slide>? Slides { get; set; }
        public List<Product>? Products { get; set; }
        public List<Brand>? Brands { get; set; }
    }
}
