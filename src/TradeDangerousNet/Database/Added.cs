using System;
using System.Collections.Generic;

namespace TradeDangerousNet.Database
{
    public partial class Added
    {
        public Added()
        {
            System = new HashSet<System>();
        }

        public long AddedId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<System> System { get; set; }
    }
}
