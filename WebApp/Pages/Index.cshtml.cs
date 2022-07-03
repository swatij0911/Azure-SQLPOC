using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Model;
using WebApp.Services;

namespace WebApp.Pages
{
    public class IndexModel : PageModel
    {
        public List<Product> products;
       
        private readonly IProductService productService;

        public IndexModel(IProductService _productService)
        {          
            productService = _productService;
        }

        public void OnGet()
        {
            //products = new ProductService().GetProducts();

            products = productService.GetProducts();
        }
    }
}