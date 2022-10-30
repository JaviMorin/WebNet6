using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebNet6.Models;
using WebNet6.Models.ViewModels;

namespace WebNet6.Controllers
{
    public class TradeController : Controller
    {
        private readonly TitanContext _context;

        public TradeController(TitanContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var trades = _context.Trades.Include(t => t.TradeType);
            return View(await trades.ToListAsync());
        }
        public IActionResult Create()
        {
            ViewData["Types"] = new SelectList(_context.TradeTypes, "TradeTypeId", "Name");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TradeViewModel model)
        {
            if (ModelState.IsValid)
            {
                var trade = new Trade()
                {
                    Name = model.Name,
                    TradeTypeId = model.TradeTypeId
                };

                _context.Add(trade);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            ViewData["Types"] = new SelectList(_context.TradeTypes, "TradeTypeId", "Name", model.TradeTypeId);
            return View();
        }
    }
}
