using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebNet6.Models;
using WebNet6.Models.ViewModels;

namespace WebNet6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiTradeController : ControllerBase
    {
        private readonly TitanContext _context;

        public ApiTradeController(TitanContext context)
        {
            _context = context;
        }

        public async Task<List<TradeTypeViewModel>> Get() => await _context.Trades.Include(b => b.TradeType)
            .Select(b => new TradeTypeViewModel()
            {
                Name = b.Name,
                Type = b.TradeType.Name
            }).ToListAsync();
    }
}
