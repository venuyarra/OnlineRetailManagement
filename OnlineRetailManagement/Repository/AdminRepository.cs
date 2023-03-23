using OnlineRetailManagement.Models;

namespace OnlineRetailManagement.Repository
{
    public class AdminRepository : IAdminRepository
    {
        private OnlineRetaildbContext _context;
        public AdminRepository(OnlineRetaildbContext context)
        {
            _context = context;
        }
        public bool AddProductId(Product product)
        {
            throw new NotImplementedException();
        }

        public bool DeleteProductId(Product product)
        {
            throw new NotImplementedException();
        }

        public List<Orders> GetAllOrders()
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public bool UpdateProductId(Product product)
        {
            throw new NotImplementedException();
        }
        public bool GetUser(User user)
        {
            var t=_context.users.FirstOrDefault(o=>o.email== user.email);
            if (t != null)
            {
                return false;
            }
            return true;
        }
        public void AddUser(User user)
        {
            _context.users.Add(user);
            _context.SaveChanges();
        }
    }
}
