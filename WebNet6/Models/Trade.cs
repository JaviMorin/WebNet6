using System;
using System.Collections.Generic;

namespace WebNet6.Models
{
    public partial class Trade
    {
        public int TradeId { get; set; }
        public string Name { get; set; } = null!;
        public int TradeTypeId { get; set; }

        public virtual TradeType TradeType { get; set; } = null!;
    }
}
