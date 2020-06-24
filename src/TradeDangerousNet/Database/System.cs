using System;
using System.Collections.Generic;

namespace TradeDangerousNet.Database
{
    /// <summary>
    /// Describes a star system which may contain one or more Station objects.
    /// </summary>
    public class System
    {
        public System()
        {
            // ReSharper disable once VirtualMemberCallInConstructor
            // Virtual member for entity framework navigation proxy
            Station = new HashSet<Station>();
        }

        public long SystemId { get; set; }
        public string Name { get; set; }
        public double PosX { get; set; }
        public double PosY { get; set; }
        public double PosZ { get; set; }
        public long? AddedId { get; set; }
        public DateTime Modified { get; set; }

        public virtual Added Added { get; set; }
        public virtual ICollection<Station> Station { get; set; }

        public double DistanceTo(System otherSystem)
        {
            return Math.Pow(Math.Pow(PosX - otherSystem.PosX, 2) +
                            Math.Pow(PosY - otherSystem.PosY, 2) +
                            Math.Pow(PosZ - otherSystem.PosZ, 2), 0.5);
        }
    }
}
