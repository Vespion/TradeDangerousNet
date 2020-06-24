using System;
using System.Collections.Generic;

namespace TradeDangerousNet.Database
{
    /// <summary>
    /// A product that can be bought/sold in the game.
    /// </summary>
    public class Item
    {
        public Item()
        {
            // ReSharper disable VirtualMemberCallInConstructor
            // Virtual member for entity framework navigation proxy
            StationItem = new HashSet<StationItem>();
            // ReSharper enable VirtualMemberCallInConstructor
        }

        public long ItemId { get; set; }
        public string Name { get; set; }
        public long CategoryId { get; set; }
        public long UiOrder { get; set; }
        public long? AvgPrice { get; set; }
        public long? FdevId { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<StationItem> StationItem { get; set; }
    }
}
