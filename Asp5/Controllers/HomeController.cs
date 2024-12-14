using Asp5.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Asp5.Controllers
{
    public class HomeController : Controller
    {
        private readonly BookShContext _context;

        public HomeController(BookShContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Category()
        {
            var categories = await _context.Categories.ToListAsync();
            return View(categories);
        }

        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCategory(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return RedirectToAction("Category");
        }

        [HttpGet]
        public async Task<IActionResult> DetailsCategory(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories.FirstOrDefaultAsync(m => m.CategoryId == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }
        public async Task<IActionResult> EditCategory(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditCategory(Category categories)
        {
            _context.Categories.Update(categories);
            await _context.SaveChangesAsync();
            return RedirectToAction("Category");
        }


        [HttpGet]
        [ActionName("ConfirmDeleteCategory")]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> ConfirmDeleteCategory(int? id)

        {
            if (id != null)
            {
                Category categories = await _context.Categories.FirstOrDefaultAsync(p => p.CategoryId == id);
                if (categories != null)
                    return View(categories);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Categories.FirstOrDefaultAsync(m => m.CategoryId == id);
            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }

        [HttpGet]
        public IActionResult Order()
        {
            var orders = _context.Orders.ToList();
            return View(orders);
        }
        public IActionResult CreateOrder()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrders(Order orders)
        {
            _context.Orders.Add(orders);
            await _context.SaveChangesAsync();
            return RedirectToAction("Order");
        }
        public async Task<IActionResult> DetailsOrder(int? id)
        {
            if (id != null)
            {
                Order orders = await _context.Orders.FirstOrDefaultAsync(p => p.OrderId == id);
                if (orders != null)
                    return View(orders);
            }
            return NotFound();
        }
        public async Task<IActionResult> EditOrder(int? id)
        {
            if (id != null)
            {
                Order orders = await _context.Orders.FirstOrDefaultAsync(p => p.OrderId == id);
                if (orders != null)
                    return View(orders);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> EditOrder(Order orders)
        {
            _context.Orders.Update(orders);
            await _context.SaveChangesAsync();
            return RedirectToAction("Order");
        }


        [HttpGet]
        [ActionName("ConfirmDeleteOder")]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> ConfirmDeleteOders(int? id)
        {
            if (id != null)
            {
                Order orders = await _context.Orders.FirstOrDefaultAsync(p => p.OrderId == id);
                if (orders != null)
                    return View(orders);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var orders = await _context.Orders.FindAsync(id);
            if (orders == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(orders);
            await _context.SaveChangesAsync();

            return RedirectToAction("Order");
        }
        public async Task<IActionResult> Product()
        {
            var products = _context.Products.ToList();
            return View(products);
        }
        public IActionResult CreateProduct()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateProduct(Product products)
        {
            _context.Products.Add(products);
            await _context.SaveChangesAsync();
            return RedirectToAction("Product");
        }

        [HttpGet]
        public async Task<IActionResult> DetailsProduct(int? id)
        {
            if (id != null)
            {
                Product product = await _context.Products.FirstOrDefaultAsync(p => p.ProductId == id);
                if (product != null)
                    return View(product);
            }
            return NotFound();
        }
        public async Task<IActionResult> EditProduct(int? id)
        {
            if (id != null)
            {
                Product product = await _context.Products.FirstOrDefaultAsync(p => p.ProductId == id);
                if (product != null)
                    return View(product);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> EditProduct(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
            return RedirectToAction("Product");
        }

        [HttpGet]
        [ActionName("ConfirmDeleteProduct")]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> ConfirmDeleteProduct(int? id)
        {
            if (id != null)
            {
                Product product = await _context.Products.FirstOrDefaultAsync(p => p.ProductId == id);
                if (product != null)
                    return View(product);

            }
            return NotFound();
        }

        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return RedirectToAction("Product");
        }
        [HttpGet]
        public async Task<IActionResult> User()
        {
            var user = await _context.Users.ToListAsync();
            return View(user);
        }

        [HttpGet]
        public IActionResult CreateUser()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return RedirectToAction("User");
        }

        [HttpGet]
        public async Task<IActionResult> DetailsUser(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FirstOrDefaultAsync(m => m.UserId == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }
        public async Task<IActionResult> EditUser(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUser(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return RedirectToAction("User");
        }


        [HttpGet]
        [ActionName("ConfirmDeleteUser")]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> ConfirmDeleteUser(int? id)

        {
            if (id != null)
            {
                User user = await _context.Users.FirstOrDefaultAsync(p => p.UserId == id);
                if (user != null)
                    return View(user);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var user = await _context.Users.FirstOrDefaultAsync(m => m.UserId == id);
            if (user == null)
            {
                return NotFound();
            }

            return View(user);
        }
        

    }
}