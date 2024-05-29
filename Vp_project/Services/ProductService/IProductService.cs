using Vp_Project.Shared;

namespace Vp_Project.Client.Services.ProductService
{
    public interface IProductService
    {
        List<Product> Products { get; set; }
        void LoadProducts();
    }
}
