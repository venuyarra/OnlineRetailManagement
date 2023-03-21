using OnlineRetailManagement.Models;

namespace OnlineRetailManagement.Repository
{
    public class UserRepository : IUserRepository
    {
        private OnlineRetaildbContext _context;
        public UserRepository(OnlineRetaildbContext context)
        {
            _context = context;
        }
        public bool AddProductstoOrders(Orders orders)
        {
            throw new NotImplementedException();
        }

        public bool AddProducttoCart(Product product)
        {
            throw new NotImplementedException();
        }

        public bool DeleteProductFromCart(ProductsInCart productincart)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllProductsByName(string ProductName)
        {
            throw new NotImplementedException();
        }
    }
}
