using System;
using System.Collections.Generic;

namespace TradeDangerousNet.Database
{
    public partial class StationSelling
    {
        public long? StationId { get; set; }
        public long? ItemId { get; set; }
        public long? Price { get; set; }
        public long? Units { get; set; }
        public long? Level { get; set; }
        public DateTime Modified { get; set; }
    }
}
