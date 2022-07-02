using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApp.Model;
using WebApp.Services;

namespace WebApp.Pages
{
    public class IndexModel : PageModel
    {
        public List<Product> products;
        public void OnGet()
        {
            products = new ProductService().GetProducts();
        }
    }
}