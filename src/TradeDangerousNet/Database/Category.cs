using System;
using System.Collections.Generic;

namespace TradeDangerousNet.Database
{
    public class Category
    {
        /// <summary>
        /// Items are organized into categories (Food, Drugs, Metals, etc).
        /// Category objects describes a category's ID, name and list of items.
        /// </summary>
        public Category()
        {
            // ReSharper disable VirtualMemberCallInConstructor
            // Virtual member for entity framework navigation proxy
            Item = new HashSet<Item>();
            RareItem = new HashSet<RareItem>();
            // ReSharper enable VirtualMemberCallInConstructor
        }

        public long CategoryId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Item> Item { get; set; }
        public virtual ICollection<RareItem> RareItem { get; set; }
    }
}
