using OnlineRetailManagement.Models;

namespace OnlineRetailManagement.Repository
{
    public interface IUserRepository
    {
        List<Product> GetAllProductsByName(string ProductName);
        Boolean AddProducttoCart(Product product);
        Boolean AddProductstoOrders(Orders orders);
        Boolean DeleteProductFromCart(ProductsInCart productincart);

    }
}
