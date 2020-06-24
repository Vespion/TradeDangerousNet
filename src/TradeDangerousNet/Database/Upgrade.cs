using System;
using System.Collections.Generic;

namespace TradeDangerousNet.Database
{
    public partial class Upgrade
    {
        public Upgrade()
        {
            UpgradeVendor = new HashSet<UpgradeVendor>();
        }

        public long UpgradeId { get; set; }
        public string Name { get; set; }
        public byte[] Weight { get; set; }
        public byte[] Cost { get; set; }

        public virtual ICollection<UpgradeVendor> UpgradeVendor { get; set; }
    }
}
