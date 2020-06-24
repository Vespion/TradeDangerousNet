using System;
using System.Collections.Generic;

namespace TradeDangerousNet.Database
{
    public partial class UpgradeVendor
    {
        public long UpgradeId { get; set; }
        public long StationId { get; set; }
        public long? Cost { get; set; }
        public DateTime Modified { get; set; }

        public virtual Station Station { get; set; }
        public virtual Upgrade Upgrade { get; set; }
    }
}
