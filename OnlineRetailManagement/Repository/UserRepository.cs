using OnlineRetailManagement.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;


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
     

        public void AddProducttoCart(int productId,string useremail)
        {
            var activecart = _context.carts.FirstOrDefault(o => o.Status == true && o.Email == useremail);
            ProductsInCart productsInCart= new ProductsInCart();

            productsInCart.ProductId = productId;
            Random random = new Random();
            productsInCart.ProductInCartId = random.Next(10000);
            var product =  _context.products.FirstOrDefault(o=>o.productid==productId);

            productsInCart.TotalPrice = product.productprice;
           

            if (activecart == null)
            {
                Cart cart = new Cart();
                cart.Status = true;
                cart.Email = useremail;
                cart.CartId= random.Next(10000);
                _context.carts.Add(cart);
                _context.SaveChanges();
               productsInCart.CartId=cart.CartId;

            }
            else
            {
                productsInCart.CartId = activecart.CartId;

            }
            _context.productsincart.Add(productsInCart); 
            _context.SaveChanges();

          
        }

        public void DeleteProductFromCart(int productid,string useremail)
        {
            var activecart = _context.carts.FirstOrDefault(o => o.Status == true && o.Email == useremail);
            var productincart = _context.productsincart.FirstOrDefault(o => o.CartId == activecart.CartId && o.ProductId == productid);

            _context.productsincart.Remove(productincart);
            _context.SaveChanges();


        }

        public List<Product> GetAllProductsByName(string name)
        {
           List<Product> products = _context.products.Where(o=>o.productname==name).ToList(); 
            return products;
        }
        public Product GetProduct(int id)
        {
            return _context.products.Find(id);
        }
        public User GetUser(Login login)
        {
            return _context.users.FirstOrDefault(o => o.email == login.email && o.password == login.password);
        }
        public List<Product> GetAllProducts()
        {
            return _context.products.ToList();
           
        }
        public List<ProductsInCart> GetAllProductsFromCart(string useremail)
        {
            var activecart = _context.carts.FirstOrDefault(o => o.Status == true && o.Email == useremail);
            
            return _context.productsincart.Where(o=>o.CartId==activecart.CartId).ToList();
        }
       public void RemoveCart(int cartid,double total)
        {

            var cart=_context.carts.Find(cartid);
            Orders order = new Orders();
            Random random= new Random();
            order.CartId = cartid;
            order.OrderId = random.Next(10000);
            order.OrderDate= DateTime.Now;
            order.totalprice = total;
            cart.Status = false;
            
            _context.carts.Update(cart);

            _context.SaveChanges();
            _context.orders.Add(order);
            _context.SaveChanges();
        }
        public List<Orders> GetAllOrders(string email)
        {
            var orders = from o in _context.orders
                         join c in _context.carts
                         on o.CartId equals c.CartId
                         where c.Email == email
                         select o;

            //var orders=_context.orders.Include(o => o.cart).Where(o=>o.CartId==o.cart.CartId &&o.cart.Email==email);
            return orders.ToList();
        }
        public Cart GetCart(string email)
        {
            return _context.carts.FirstOrDefault(o => o.Status == true && o.Email == email);
        }
    }
}
