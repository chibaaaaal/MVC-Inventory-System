using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_Inventory_System.Models;
using System.Collections.Generic;
using System.Linq;


namespace MVC_Inventory_System.Controllers
{
    public class TransactionController : Controller
    {
        private readonly ISDBContext _context;

        public TransactionController(ISDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> TransactionList()
        {
            var Transactions = await _context.Transactions.ToListAsync();
            return View(Transactions);
        }
    }
}
