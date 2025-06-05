using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Inventory_System.Models;
using System.Collections.Generic;
using System.Linq;

namespace MVC_Inventory_System.Controllers
{
    public class ProductController : Controller
    {
        private readonly ISDBContext _context;

        public ProductController(ISDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> ProductList()
        {
            var Products = await _context.Products.ToListAsync();
            return View(Products);
        }

        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction("ProductList");
            }
            return View(product);
        }

        public IActionResult EditProduct(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.ProductId == id);
            if (product == null)
                return NotFound();
            return View(product);
        }

        [HttpPost]
        public IActionResult EditProduct(int id, Product product)
        {
            if (id != product.ProductId)
                return NotFound();

            if (ModelState.IsValid)
            {
                var existingProduct = _context.Products.FirstOrDefault(p => p.ProductId == id);
                if (existingProduct == null)
                    return NotFound();

                existingProduct.ProductName = product.ProductName;
                existingProduct.Quantity = product.Quantity;
                existingProduct.Price = product.Price;
                _context.SaveChanges();
                return RedirectToAction("ProductList");
            }
            return View(product);
        }

        public IActionResult DeleteProduct(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.ProductId == id);
            if (product == null)
                return NotFound();
            return View(product);
        }

        [HttpPost, ActionName("DeleteProduct")]
        public IActionResult DeleteConfirmed(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.ProductId == id);
            if (product != null)
            {
                _context.Remove(product);
                _context.SaveChanges();
            }
            return RedirectToAction("ProductList");
        }
    }
}
