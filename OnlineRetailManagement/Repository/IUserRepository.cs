using OnlineRetailManagement.Models;

namespace OnlineRetailManagement.Repository
{
    public interface IUserRepository
    {
        List<Product> GetAllProductsByName(string ProductName);
        void AddProducttoCart(int productid,string useremail);
        Boolean AddProductstoOrders(Orders orders);
        void DeleteProductFromCart(int productid,string useremail);
        Product GetProduct(int id);
        User GetUser(Login login);
        List<Product> GetAllProducts();
        List<ProductsInCart> GetAllProductsFromCart(string useremail);
        void RemoveCart(int cartid,double total);

        List<Orders> GetAllOrders(string email);
        Cart GetCart(string email);
    }
}
