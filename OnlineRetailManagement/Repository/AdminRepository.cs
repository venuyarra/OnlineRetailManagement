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
            var t=_context.products.FirstOrDefault(x=>x.productid==product.productid);
            if (t == null)
            {
                _context.products.Add(product);
                _context.SaveChanges();
                return true;
            }
            return false;
          
           
        }

        public bool DeleteProductId(int id)
        {
            var product = _context.products.Find(id);
            if (product != null)
            {
                _context.products.Remove(product);
                _context.SaveChanges();
                return true;
            }
           
            return false;
          
        }

        public List<Orders> GetAllOrders()
        {
            return _context.orders.ToList();
         
        }

        public List<Product> GetAllProducts()
        {

            return _context.products.ToList();
            
        }
        public Product GetProductbyId(int id)
        {
            return _context.products.Find(id);
        }

        public bool UpdateProduct(Product product)
        {
            _context.products.Update(product);
            _context.SaveChanges();
            return true;
            
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
