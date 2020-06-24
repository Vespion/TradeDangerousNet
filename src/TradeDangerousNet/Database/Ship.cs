using System;
using System.Collections.Generic;

namespace TradeDangerousNet.Database
{
    /// <summary>
    /// Ship description.
    /// </summary>
    public class Ship
    {
        public Ship()
        {
            // ReSharper disable VirtualMemberCallInConstructor
            // Virtual member for entity framework navigation proxy
            ShipVendor = new HashSet<ShipVendor>();
            // ReSharper enable VirtualMemberCallInConstructor
        }

        /// <summary>
        /// The database ID
        /// </summary>
        public long ShipId { get; set; }
        
        /// <summary>
        /// The name as present in the database
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// How many credits to buy
        /// </summary>
        public long Cost { get; set; }
        
        /// <summary>
        /// FDevID as provided by the companion API.
        /// </summary>
        public long? FdevId { get; set; }

        /// <summary>
        /// List of Stations ship is sold at.
        /// </summary>
        public virtual ICollection<ShipVendor> ShipVendor { get; set; }
    }
}
