using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

// ReSharper disable IdentifierTypo
// ReSharper disable StringLiteralTypo
// ReSharper disable UnusedMember.Global

namespace TradeDangerousNet.Database
{
    public class TradeDangerousContext : DbContext
    {
        public TradeDangerousContext()
        {
        }

        public TradeDangerousContext(DbContextOptions<TradeDangerousContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Added> Added { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<FdevOutfitting> FdevOutfitting { get; set; }
        public virtual DbSet<FdevShipyard> FdevShipyard { get; set; }
        public virtual DbSet<Item> Item { get; set; }
        public virtual DbSet<RareItem> RareItem { get; set; }
        public virtual DbSet<Ship> Ship { get; set; }
        public virtual DbSet<ShipVendor> ShipVendor { get; set; }
        public virtual DbSet<Station> Station { get; set; }
        public virtual DbSet<StationBuying> StationBuying { get; set; }
        public virtual DbSet<StationItem> StationItem { get; set; }
        public virtual DbSet<StationSelling> StationSelling { get; set; }
        public virtual DbSet<System> System { get; set; }
        public virtual DbSet<Upgrade> Upgrade { get; set; }
        public virtual DbSet<UpgradeVendor> UpgradeVendor { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=.\\data\\TradeDangerous.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var nullableBoolConverter = new ValueConverter<bool?,string>(
                model => model.HasValue ? (model.Value ? "Y" : "N") : "?", 
                provider => provider switch
                {
                    "Y" => new bool?(true),
                    "N" => new bool?(false),
                    _ => null
                });
            modelBuilder.Entity<Added>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .IsUnique();

                entity.Property(e => e.AddedId)
                    .HasColumnName("added_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("VARCHAR(40)");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasIndex(e => e.CategoryId)
                    .IsUnique();

                entity.Property(e => e.CategoryId)
                    .HasColumnName("category_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("VARCHAR(40)");
            });

            modelBuilder.Entity<FdevOutfitting>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("FDevOutfitting");

                entity.HasIndex(e => e.Id)
                    .IsUnique();

                entity.Property(e => e.Category)
                    .HasColumnName("category")
                    .HasColumnType("CHAR(10)");

                entity.Property(e => e.Class)
                    .IsRequired()
                    .HasColumnName("class")
                    .HasColumnType("CHAR(1)");

                entity.Property(e => e.Entitlement)
                    .HasColumnName("entitlement")
                    .HasColumnType("CHAR(10)");

                entity.Property(e => e.Guidance)
                    .HasColumnName("guidance")
                    .HasColumnType("CHAR(10)");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Mount)
                    .HasColumnName("mount")
                    .HasColumnType("CHAR(10)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("VARCHAR(40)");

                entity.Property(e => e.Rating)
                    .IsRequired()
                    .HasColumnName("rating")
                    .HasColumnType("CHAR(1)");

                entity.Property(e => e.Ship)
                    .HasColumnName("ship")
                    .HasColumnType("VARCHAR(40)");

                entity.Property(e => e.Symbol)
                    .HasColumnName("symbol")
                    .HasColumnType("VARCHAR(40)");
            });

            modelBuilder.Entity<FdevShipyard>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("FDevShipyard");

                entity.HasIndex(e => e.Id)
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("VARCHAR(40)");

                entity.Property(e => e.Symbol)
                    .HasColumnName("symbol")
                    .HasColumnType("VARCHAR(40)");
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.HasIndex(e => e.FdevId)
                    .HasName("idx_item_by_fdev_id");

                entity.HasIndex(e => e.ItemId)
                    .IsUnique();

                entity.Property(e => e.ItemId)
                    .HasColumnName("item_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.AvgPrice).HasColumnName("avg_price");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.FdevId).HasColumnName("fdev_id");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("VARCHAR(40)");

                entity.Property(e => e.UiOrder).HasColumnName("ui_order");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Item)
                    .HasForeignKey(d => d.CategoryId);
            });

            modelBuilder.Entity<RareItem>(entity =>
            {
                entity.HasKey(e => e.RareId);

                entity.HasIndex(e => e.Name)
                    .IsUnique();

                entity.Property(e => e.RareId)
                    .HasColumnName("rare_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.Cost).HasColumnName("cost");

                entity.Property(e => e.Illegal)
                    .IsRequired()
                    .HasColumnName("illegal")
                    .HasColumnType("TEXT(1)")
                    .HasDefaultValueSql("'?'");

                entity.Property(e => e.MaxAllocation).HasColumnName("max_allocation");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("VARCHAR(40)");

                entity.Property(e => e.StationId).HasColumnName("station_id");

                entity.Property(e => e.Suppressed)
                    .IsRequired()
                    .HasColumnName("suppressed")
                    .HasColumnType("TEXT(1)")
                    .HasDefaultValueSql("'?'");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.RareItem)
                    .HasForeignKey(d => d.CategoryId);

                entity.HasOne(d => d.Station)
                    .WithMany(p => p.RareItem)
                    .HasForeignKey(d => d.StationId);
            });

            modelBuilder.Entity<Ship>(entity =>
            {
                entity.HasIndex(e => e.ShipId)
                    .IsUnique();

                entity.Property(e => e.ShipId)
                    .HasColumnName("ship_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cost).HasColumnName("cost");

                entity.Property(e => e.FdevId).HasColumnName("fdev_id");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("VARCHAR(40)");
            });

            modelBuilder.Entity<ShipVendor>(entity =>
            {
                entity.HasKey(e => new { e.ShipId, e.StationId });

                entity.Property(e => e.ShipId).HasColumnName("ship_id");

                entity.Property(e => e.StationId).HasColumnName("station_id");

                entity.Property(e => e.Modified)
                    .IsRequired()
                    .HasColumnName("modified")
                    .HasColumnType("DATETIME")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasOne(d => d.Ship)
                    .WithMany(p => p.ShipVendor)
                    .HasForeignKey(d => d.ShipId);

                entity.HasOne(d => d.Station)
                    .WithMany(p => p.ShipVendor)
                    .HasForeignKey(d => d.StationId);
            });

            modelBuilder.Entity<Station>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("idx_station_by_name");

                entity.HasIndex(e => e.StationId)
                    .IsUnique();

                entity.HasIndex(e => new { e.SystemId, e.StationId })
                    .HasName("idx_station_by_system");

                entity.Property(e => e.StationId)
                    .HasColumnName("station_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Blackmarket)
                    .IsRequired()
                    .HasColumnName("blackmarket")
                    .HasConversion(nullableBoolConverter)
                    .HasColumnType("TEXT(1)")
                    .HasDefaultValueSql("'?'");

                entity.Property(e => e.LsFromStar).HasColumnName("ls_from_star");

                entity.Property(e => e.Market)
                    .IsRequired()
                    .HasColumnName("market")
                    .HasConversion(nullableBoolConverter)
                    .HasColumnType("TEXT(1)")
                    .HasDefaultValueSql("'?'");

                entity.Property(e => e.MaxPadSize)
                    .IsRequired()
                    .HasColumnName("max_pad_size")
                    .HasColumnType("TEXT(1)")
                    .HasConversion<string>()
                    .HasDefaultValueSql("'?'");

                entity.Property(e => e.Modified)
                    .IsRequired()
                    .HasColumnName("modified")
                    .HasColumnType("DATETIME")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("VARCHAR(40)");

                entity.Property(e => e.Outfitting)
                    .IsRequired()
                    .HasColumnName("outfitting")
                    .HasConversion(nullableBoolConverter)
                    .HasColumnType("TEXT(1)")
                    .HasDefaultValueSql("'?'");

                entity.Property(e => e.Planetary)
                    .IsRequired()
                    .HasColumnName("planetary")
                    .HasColumnType("TEXT(1)")
                    .HasConversion(nullableBoolConverter)
                    .HasDefaultValueSql("'?'");

                entity.Property(e => e.Rearm)
                    .IsRequired()
                    .HasColumnName("rearm")
                    .HasConversion(nullableBoolConverter)
                    .HasColumnType("TEXT(1)")
                    .HasDefaultValueSql("'?'");

                entity.Property(e => e.Refuel)
                    .IsRequired()
                    .HasColumnName("refuel")
                    .HasConversion(nullableBoolConverter)
                    .HasColumnType("TEXT(1)")
                    .HasDefaultValueSql("'?'");

                entity.Property(e => e.Repair)
                    .IsRequired()
                    .HasColumnName("repair")
                    .HasConversion(nullableBoolConverter)
                    .HasColumnType("TEXT(1)")
                    .HasDefaultValueSql("'?'");

                entity.Property(e => e.Shipyard)
                    .IsRequired()
                    .HasColumnName("shipyard")
                    .HasConversion(nullableBoolConverter)
                    .HasColumnType("TEXT(1)")
                    .HasDefaultValueSql("'?'");

                entity.Property(e => e.SystemId).HasColumnName("system_id");

                entity.Property(e => e.TypeId).HasColumnName("type_id");

                entity.HasOne(d => d.System)
                    .WithMany(p => p.Station)
                    .HasForeignKey(d => d.SystemId);
            });

            modelBuilder.Entity<StationBuying>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("StationBuying");

                entity.Property(e => e.ItemId).HasColumnName("item_id");

                entity.Property(e => e.Level)
                    .HasColumnName("level")
                    .HasColumnType("INT");

                entity.Property(e => e.Modified)
                    .HasColumnName("modified")
                    .HasColumnType("DATETIME");

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("INT");

                entity.Property(e => e.StationId).HasColumnName("station_id");

                entity.Property(e => e.Units)
                    .HasColumnName("units")
                    .HasColumnType("INT");
            });

            modelBuilder.Entity<StationItem>(entity =>
            {
                entity.HasKey(e => new { e.StationId, e.ItemId });

                entity.HasIndex(e => new { e.ItemId, e.DemandPrice })
                    .HasName("si_itm_dmdpr");

                entity.HasIndex(e => new { e.ItemId, e.SupplyPrice })
                    .HasName("si_itm_suppr");

                entity.HasIndex(e => new { e.Modified, e.StationId, e.ItemId })
                    .HasName("si_mod_stn_itm");

                entity.Property(e => e.StationId).HasColumnName("station_id");

                entity.Property(e => e.ItemId).HasColumnName("item_id");

                entity.Property(e => e.DemandLevel)
                    .HasColumnName("demand_level")
                    .HasColumnType("INT");

                entity.Property(e => e.DemandPrice)
                    .HasColumnName("demand_price")
                    .HasColumnType("INT");

                entity.Property(e => e.DemandUnits)
                    .HasColumnName("demand_units")
                    .HasColumnType("INT");

                entity.Property(e => e.FromLive).HasColumnName("from_live");

                entity.Property(e => e.Modified)
                    .IsRequired()
                    .HasColumnName("modified")
                    .HasColumnType("DATETIME")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.SupplyLevel)
                    .HasColumnName("supply_level")
                    .HasColumnType("INT");

                entity.Property(e => e.SupplyPrice)
                    .HasColumnName("supply_price")
                    .HasColumnType("INT");

                entity.Property(e => e.SupplyUnits)
                    .HasColumnName("supply_units")
                    .HasColumnType("INT");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.StationItem)
                    .HasForeignKey(d => d.ItemId);

                entity.HasOne(d => d.Station)
                    .WithMany(p => p.StationItem)
                    .HasForeignKey(d => d.StationId);
            });

            modelBuilder.Entity<StationSelling>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("StationSelling");

                entity.Property(e => e.ItemId).HasColumnName("item_id");

                entity.Property(e => e.Level)
                    .HasColumnName("level")
                    .HasColumnType("INT");

                entity.Property(e => e.Modified)
                    .HasColumnName("modified")
                    .HasColumnType("DATETIME");

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("INT");

                entity.Property(e => e.StationId).HasColumnName("station_id");

                entity.Property(e => e.Units)
                    .HasColumnName("units")
                    .HasColumnType("INT");
            });

            modelBuilder.Entity<System>(entity =>
            {
                entity.HasIndex(e => e.SystemId)
                    .IsUnique();

                entity.HasIndex(e => new { e.PosX, e.PosY, e.PosZ, e.SystemId })
                    .HasName("idx_system_by_pos");

                entity.Property(e => e.SystemId)
                    .HasColumnName("system_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.AddedId).HasColumnName("added_id");

                entity.Property(e => e.Modified)
                    .IsRequired()
                    .HasColumnName("modified")
                    .HasColumnType("DATETIME")
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("VARCHAR(40)");

                entity.Property(e => e.PosX)
                    .HasColumnName("pos_x")
                    .HasColumnType("DOUBLE");

                entity.Property(e => e.PosY)
                    .HasColumnName("pos_y")
                    .HasColumnType("DOUBLE");

                entity.Property(e => e.PosZ)
                    .HasColumnName("pos_z")
                    .HasColumnType("DOUBLE");

                entity.HasOne(d => d.Added)
                    .WithMany(p => p.System)
                    .HasForeignKey(d => d.AddedId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Upgrade>(entity =>
            {
                entity.HasIndex(e => e.UpgradeId)
                    .IsUnique();

                entity.Property(e => e.UpgradeId)
                    .HasColumnName("upgrade_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cost)
                    .IsRequired()
                    .HasColumnName("cost")
                    .HasColumnType("NUMBER");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("VARCHAR(40)");

                entity.Property(e => e.Weight)
                    .IsRequired()
                    .HasColumnName("weight")
                    .HasColumnType("NUMBER");
            });

            modelBuilder.Entity<UpgradeVendor>(entity =>
            {
                entity.HasKey(e => new { e.UpgradeId, e.StationId });

                entity.HasIndex(e => e.StationId)
                    .HasName("idx_vendor_by_station_id");

                entity.Property(e => e.UpgradeId).HasColumnName("upgrade_id");

                entity.Property(e => e.StationId).HasColumnName("station_id");

                entity.Property(e => e.Cost).HasColumnName("cost");

                entity.Property(e => e.Modified)
                    .IsRequired()
                    .HasColumnName("modified")
                    .HasColumnType("DATETIME");

                entity.HasOne(d => d.Station)
                    .WithMany(p => p.UpgradeVendor)
                    .HasForeignKey(d => d.StationId);

                entity.HasOne(d => d.Upgrade)
                    .WithMany(p => p.UpgradeVendor)
                    .HasForeignKey(d => d.UpgradeId);
            });
        }
    }
}
