using BacolaBackDb.Models.Home;
using System.Collections.Generic;

namespace BacolaBackDb.ViewModels
{
    public class HomeVM
    {
        public List<Product> Products { get; set; }
        public List<Category> Categories { get; set; }
        public List<Slider> Sliders { get; set; }
        public List<BasketVM> BasketVM { get; set; }
        public Product Product { get; set; }
        public List<DiscountBanner> DiscountBanners { get; set; }

        public Dictionary<string, string> Settings { get; set; }
        //public List<ProductImage> ProductImages { get; set; }
    }
}
