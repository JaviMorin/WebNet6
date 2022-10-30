using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;
using WebNet6.Models;

namespace WebNet6.Controllers
{
    public class TradeTypeController : Controller
    {
        private readonly TitanContext _context;

        public TradeTypeController(TitanContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.TradeTypes.ToListAsync());
        }
    }
}
