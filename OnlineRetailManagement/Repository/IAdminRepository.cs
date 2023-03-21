using OnlineRetailManagement.Models;

namespace OnlineRetailManagement.Repository
{
    public interface IAdminRepository
    {
        Boolean AddProductId(Product product);
        Boolean DeleteProductId(Product product);
        Boolean UpdateProductId(Product product);
        List<Product> GetAllProducts();
        List<Orders> GetAllOrders();
    }
}
