using System;
using System.Collections.Generic;

namespace TradeDangerousNet.Database
{
    /// <summary>
    /// Describes a station (trading or otherwise) in a system.
    /// </summary>
    public class Station
    {
        public Station()
        {
            // ReSharper disable VirtualMemberCallInConstructor
            // Virtual member for entity framework navigation proxy
            RareItem = new HashSet<RareItem>();
            ShipVendor = new HashSet<ShipVendor>();
            StationItem = new HashSet<StationItem>();
            UpgradeVendor = new HashSet<UpgradeVendor>();
            // ReSharper enable VirtualMemberCallInConstructor
        }

        public long StationId { get; set; }
        public string Name { get; set; }
        public long SystemId { get; set; }
        public long LsFromStar { get; set; }
        public bool? Blackmarket { get; set; }
        public PadSizes MaxPadSize { get; set; }
        public bool? Market { get; set; }
        public bool? Shipyard { get; set; }
        public DateTime Modified { get; set; }
        public bool? Outfitting { get; set; }
        public bool? Rearm { get; set; }
        public bool? Refuel { get; set; }
        public bool? Repair { get; set; }
        public bool? Planetary { get; set; }
        public long TypeId { get; set; }

        public virtual System System { get; set; }
        public virtual ICollection<RareItem> RareItem { get; set; }
        public virtual ICollection<ShipVendor> ShipVendor { get; set; }
        public virtual ICollection<StationItem> StationItem { get; set; }
        public virtual ICollection<UpgradeVendor> UpgradeVendor { get; set; }

        public bool CheckPadSize(PadSizes targetSize) => targetSize <= MaxPadSize;
        public bool IsTrading => StationItem.Count > 0 || Market.GetValueOrDefault(false);

        public override string ToString() => $"{System.Name}/{Name}";
    }
}
