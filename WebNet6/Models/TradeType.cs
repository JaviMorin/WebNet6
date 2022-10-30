using System;
using System.Collections.Generic;

namespace WebNet6.Models
{
    public partial class TradeType
    {
        public TradeType()
        {
            Trades = new HashSet<Trade>();
        }

        public int TradeTypeId { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Trade> Trades { get; set; }
    }
}
