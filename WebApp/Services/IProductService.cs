using WebApp.Model;

namespace WebApp.Services
{
    public interface IProductService
    {
        List<Product> GetProducts();
    }
}