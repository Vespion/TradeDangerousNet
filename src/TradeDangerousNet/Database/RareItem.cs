using System;
using System.Collections.Generic;

namespace TradeDangerousNet.Database
{
    /// <summary>
    /// Describes a RareItem from the database.
    /// </summary>
    public class RareItem
    {
        public long RareId { get; set; }
        public long StationId { get; set; }
        public long CategoryId { get; set; }
        public string Name { get; set; }
        public long? Cost { get; set; }
        public long? MaxAllocation { get; set; }
        public string Illegal { get; set; }
        public string Suppressed { get; set; }

        public virtual Category Category { get; set; }
        public virtual Station Station { get; set; }
    }
}
