using Microsoft.EntityFrameworkCore;
using TransneftEnergo.DataAccess.DefaultData;
using TransneftEnergo.DataAccess.Models;

namespace TransneftEnergo.DataAccess.Context
{
    /// <summary>
    /// Контекст базы данных.
    /// </summary>
    public sealed class DatabaseContext : DbContext, IDatabaseContext
    {
        /// <summary>
        /// Параметризированный конструктор.
        /// </summary>
        /// <param name="options">Параметры базы данных приложения.</param>
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            #if DEBUG
            Database.EnsureCreated();
            #endif
        }



        #region Набор данных.
        /// <inheritdoc />
        public DbSet<AccountingDevice> AccountingDevices { get; set; } = null!;

        /// <inheritdoc />
        public DbSet<ConsumptionObject> ConsumptionObjects { get; set; } = null!;

        /// <inheritdoc />
        public DbSet<CurrentTransformer> CurrentTransformers { get; set; } = null!;

        /// <inheritdoc />
        public DbSet<EnergyMeter> EnergyMeters { get; set; } = null!;

        /// <inheritdoc />
        public DbSet<MeasuringPoint> MeasuringPoints { get; set; } = null!;

        /// <inheritdoc />
        public DbSet<MeasuringPointAccountingDevice> MeasuringPointAccountingDevices { get; set; } = null!;

        /// <inheritdoc />
        public DbSet<Organization> Organizations { get; set; } = null!;

        /// <inheritdoc />
        public DbSet<SubsidiaryOrganization> SubsidiaryOrganizations { get; set; } = null!;

        /// <inheritdoc />
        public DbSet<SupplyPoint> SupplyPoints { get; set; } = null!;

        /// <inheritdoc />
        public DbSet<VoltageTransformer> VoltageTransformers { get; set; } = null!;
        #endregion



        /// <inheritdoc />
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccountingDevice>()
                .HasMany(accountingDevice => accountingDevice.MeasuringPoints)
                .WithMany(measuringPoint => measuringPoint.AccountingDevices)
                .UsingEntity<MeasuringPointAccountingDevice>
                (
                    b => b.HasOne<MeasuringPoint>().WithMany().HasForeignKey(b => b.MeasuringPointId).OnDelete(DeleteBehavior.ClientCascade),
                    b => b.HasOne<AccountingDevice>().WithMany().HasForeignKey(b => b.AccountingDeviceId).OnDelete(DeleteBehavior.ClientCascade)
                );

            #if DEBUG
            modelBuilder.EnsureDbInitialization();
            #endif
        }
    }
}