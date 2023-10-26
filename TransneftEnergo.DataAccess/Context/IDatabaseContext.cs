using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using TransneftEnergo.DataAccess.Models;

namespace TransneftEnergo.DataAccess.Context
{
    /// <summary>
    /// Интерфейс контекста базы данных.
    /// </summary>
    public interface IDatabaseContext
    {
        #region Члены класса DbContext.
        /// <inheritdoc cref="DbContext.Database" />
        public DatabaseFacade Database { get; }

        /// <inheritdoc cref="DbContext.SaveChanges()" />
        public int SaveChanges();

        /// <inheritdoc cref="DbContext.SaveChangesAsync(CancellationToken)()" />
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        #endregion


        #region Наборы данных.
        /// <summary>
        /// Набор расчетных приборов учета.
        /// </summary>
        public DbSet<AccountingDevice> AccountingDevices { get; set; }

        /// <summary>
        /// Набор объектов потребления.
        /// </summary>
        public DbSet<ConsumptionObject> ConsumptionObjects { get; set; }

        /// <summary>
        /// Набор трансформаторов тока.
        /// </summary>
        public DbSet<CurrentTransformer> CurrentTransformers { get; set; }

        /// <summary>
        /// Набор счетчиков электроэнергии
        /// </summary>
        public DbSet<EnergyMeter> EnergyMeters { get; set; }

        /// <summary>
        /// Набор точек измерения электроэнергии.
        /// </summary>
        public DbSet<MeasuringPoint> MeasuringPoints { get; set; }

        /// <summary>
        /// Набор сущностей соединения точки измерения электроэнергии и расчетного прибора учета.
        /// </summary>
        public DbSet<MeasuringPointAccountingDevice> MeasuringPointAccountingDevices { get; set; }

        /// <summary>
        /// Набор организаций.
        /// </summary>
        public DbSet<Organization> Organizations { get; set; }

        /// <summary>
        /// Набор дочерних организаций.
        /// </summary>
        public DbSet<SubsidiaryOrganization> SubsidiaryOrganizations { get; set; }

        /// <summary>
        /// Набор точек поставки электроэнергии.
        /// </summary>
        public DbSet<SupplyPoint> SupplyPoints { get; set; }

        /// <summary>
        /// Набор трансформаторов напряжения.
        /// </summary>
        public DbSet<VoltageTransformer> VoltageTransformers { get; set; }
        #endregion
    }
}