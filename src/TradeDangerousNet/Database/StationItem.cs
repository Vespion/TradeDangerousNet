using System;
using System.Collections.Generic;

namespace TradeDangerousNet.Database
{
    public partial class StationItem
    {
        public long StationId { get; set; }
        public long ItemId { get; set; }
        public long DemandPrice { get; set; }
        public long DemandUnits { get; set; }
        public long DemandLevel { get; set; }
        public long SupplyPrice { get; set; }
        public long SupplyUnits { get; set; }
        public long SupplyLevel { get; set; }
        public DateTime Modified { get; set; }
        public long FromLive { get; set; }

        public virtual Item Item { get; set; }
        public virtual Station Station { get; set; }
    }
}
