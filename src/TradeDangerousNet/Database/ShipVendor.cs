using System;
using System.Collections.Generic;

namespace TradeDangerousNet.Database
{
    public partial class ShipVendor
    {
        public long ShipId { get; set; }
        public long StationId { get; set; }
        public DateTime Modified { get; set; }

        public virtual Ship Ship { get; set; }
        public virtual Station Station { get; set; }
    }
}
