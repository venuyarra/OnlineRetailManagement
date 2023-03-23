using OnlineRetailManagement.Models;

namespace OnlineRetailManagement.Repository
{
    public interface IAdminRepository
    {
        Boolean AddProductId(Product product);
        Boolean DeleteProductId(int id);
        Boolean UpdateProduct(Product product);
        Product GetProductbyId(int id);
        List<Product> GetAllProducts();
        List<Orders> GetAllOrders();
        bool GetUser(User user);
        void AddUser(User user);
    }
}
