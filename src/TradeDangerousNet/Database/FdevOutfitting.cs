using System;
using System.Collections.Generic;

namespace TradeDangerousNet.Database
{
    public partial class FdevOutfitting
    {
        public long Id { get; set; }
        public string Symbol { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public string Mount { get; set; }
        public string Guidance { get; set; }
        public string Ship { get; set; }
        public string Class { get; set; }
        public string Rating { get; set; }
        public string Entitlement { get; set; }
    }
}
