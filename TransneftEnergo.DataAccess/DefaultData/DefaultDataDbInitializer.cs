using Microsoft.EntityFrameworkCore;
using TransneftEnergo.DataAccess.Models;

namespace TransneftEnergo.DataAccess.DefaultData
{
    /// <summary>
    /// Методы расширения инициализации БД.
    /// </summary>
    public static class DefaultDataDbInitializer
    {
        /// <summary>
        /// Обеспечивает инициализацию БД случайными данными.
        /// </summary>
        /// <param name="modelBuilder">Строитель модели.</param>
        public static void EnsureDbInitialization(this ModelBuilder modelBuilder)
        {
            var organizations = InitializeOrganizations(modelBuilder);
            var subsidiaryOrganizations = InitializeSubsidiaryOrganizations(modelBuilder, organizations);
            var consumptionObjects = InitializeConsumptionObjects(modelBuilder, subsidiaryOrganizations);
            var measuringPoints = InitializeMeasuringPoints(modelBuilder, consumptionObjects);
            var supplyPoints = InitializeSupplyPoints(modelBuilder, consumptionObjects);
            var hardware = InitializeHardware(modelBuilder, measuringPoints);
            var accountingDevices = InitializeAccountingDevices(modelBuilder, supplyPoints);

            var allBindings = RandomDataGenerator.CreateBindings(measuringPoints, accountingDevices, 1000);

            _ = modelBuilder.Entity<Organization>().HasData(organizations);
            _ = modelBuilder.Entity<SubsidiaryOrganization>().HasData(subsidiaryOrganizations);            
            _ = modelBuilder.Entity<ConsumptionObject>().HasData(consumptionObjects);
            _ = modelBuilder.Entity<MeasuringPoint>().HasData(measuringPoints);
            _ = modelBuilder.Entity<SupplyPoint>().HasData(supplyPoints);
            _ = modelBuilder.Entity<EnergyMeter>().HasData(hardware.Select(tuple => tuple.Item1));
            _ = modelBuilder.Entity<CurrentTransformer>().HasData(hardware.Select(tuple => tuple.Item2));
            _ = modelBuilder.Entity<VoltageTransformer>().HasData(hardware.Select(tuple => tuple.Item3));
            _ = modelBuilder.Entity<AccountingDevice>().HasData(accountingDevices);
            _ = modelBuilder.Entity<MeasuringPointAccountingDevice>().HasData(allBindings);

        }


        /// <summary>
        /// Инициализирует организации.
        /// </summary>
        /// <param name="modelBuilder">Строитель модели.</param>
        /// <returns>Перечисление организаций.</returns>
        private static IEnumerable<Organization> InitializeOrganizations(ModelBuilder modelBuilder)
        {
            int organizationId = 1;
            var organizations = RandomDataGenerator.CreateOrganizations(5);

            foreach (var organization in organizations)
                organization.Id = organizationId++;

            return organizations;
        }


        /// <summary>
        /// Инициализирует дочерние организации.
        /// </summary>
        /// <param name="modelBuilder">Строитель модели<./param>
        /// <param name="organizations"></param>
        /// <returns>Перечисление дочерних организаций.</returns>
        private static IEnumerable<SubsidiaryOrganization> InitializeSubsidiaryOrganizations(ModelBuilder modelBuilder, IEnumerable<Organization> organizations)
        {
            int subsidiaryOrganizationId = 1;
            var allSubsidiaryOrganizations = new List<SubsidiaryOrganization>();

            foreach (var organization in organizations)
            {
                var subsidiaryOrganizations = RandomDataGenerator.CreateSubsidiaryOrganizations(organization, 5);
                allSubsidiaryOrganizations.AddRange(subsidiaryOrganizations);
            }

            foreach (var subsidiaryOrganization in allSubsidiaryOrganizations)
                subsidiaryOrganization.Id = subsidiaryOrganizationId++;

            
            return allSubsidiaryOrganizations;
        }


        /// <summary>
        /// Инициализирует объект потребления.
        /// </summary>
        /// <param name="modelBuilder">Строитель модели.</param>
        /// <param name="subsidiaryOrganizations">Перечисление дочерних организаций.</param>
        /// <returns>Перечисление объектов потребления.</returns>
        private static IEnumerable<ConsumptionObject> InitializeConsumptionObjects(ModelBuilder modelBuilder, IEnumerable<SubsidiaryOrganization> subsidiaryOrganizations)
        {
            int consumptionObjectId = 1;
            var allConsumptionObjects = new List<ConsumptionObject>();

            foreach (var subsidiaryOrganization in subsidiaryOrganizations)
            {
                var consumptionObjects = RandomDataGenerator.CreateConsumptionsObjects(subsidiaryOrganization, 10);
                allConsumptionObjects.AddRange(consumptionObjects);
            }

            foreach (var consumptionObject in allConsumptionObjects)
                consumptionObject.Id = consumptionObjectId++;

            return allConsumptionObjects;
        }


        /// <summary>
        /// Инициализирует точки измерения электроэнергии.
        /// </summary>
        /// <param name="modelBuilder">Строитель модели.</param>
        /// <param name="consumptionObjects">Перечисление объектов потребления.</param>
        /// <returns>Список точек измерения электроэнергии.</returns>
        private static List<MeasuringPoint> InitializeMeasuringPoints(ModelBuilder modelBuilder, IEnumerable<ConsumptionObject> consumptionObjects)
        {
            int measuringPointId = 1;
            var allMeasuringPoints = new List<MeasuringPoint>();

            foreach (var consumptionObject in consumptionObjects)
            {
                var measuringPoints = RandomDataGenerator.CreateMeasuringPoints(consumptionObject, 20);
                allMeasuringPoints.AddRange(measuringPoints);
            }

            foreach (var measuringPoint in allMeasuringPoints)
                measuringPoint.Id = measuringPointId++;

            return allMeasuringPoints;
        }


        /// <summary>
        /// Инициализирует точки поставки электроэнергии.
        /// </summary>
        /// <param name="modelBuilder">Строитель модели.</param>
        /// <param name="consumptionObjects">Перечисление объектов потребления.</param>
        /// <returns>Перечисление точек поставки электроэнергии.</returns>
        private static IEnumerable<SupplyPoint> InitializeSupplyPoints(ModelBuilder modelBuilder, IEnumerable<ConsumptionObject> consumptionObjects)
        {
            int supplyPointId = 1;
            var allSupplyPoints = new List<SupplyPoint>();

            foreach (var consumptionObject in consumptionObjects)
            {
                var supplyPoints = RandomDataGenerator.CreateSupplyPoints(consumptionObject, 20);
                allSupplyPoints.AddRange(supplyPoints);
            }

            foreach (var supplyPoint in allSupplyPoints)
                supplyPoint.Id = supplyPointId++;

            return allSupplyPoints;
        }


        /// <summary>
        /// Инициализирует оборудование.
        /// </summary>
        /// <param name="modelBuilder">Строитель модели.</param>
        /// <param name="measuringPoints">Перечисление точек измерение электроэнергии.</param>
        /// <returns>Перечисление кортежей оборудования.</returns>
        private static IEnumerable<(EnergyMeter, CurrentTransformer, VoltageTransformer)> InitializeHardware(ModelBuilder modelBuilder, IEnumerable<MeasuringPoint> measuringPoints)
        {
            int hardwareId = 1;
            var allHardware = new List<(EnergyMeter, CurrentTransformer, VoltageTransformer)>();

            foreach (var measuringPoint in measuringPoints)
            {
                var hardware = RandomDataGenerator.CreateHardware(measuringPoint);
                hardware.Item1.Id = hardwareId;
                hardware.Item2.Id = hardwareId;
                hardware.Item3.Id = hardwareId;
                hardwareId++;
                allHardware.Add(hardware);
            }

            return allHardware;
        }


        /// <summary>
        /// Инициализирует расчетные приборы учета.
        /// </summary>
        /// <param name="modelBuilder">Строитель модели.</param>
        /// <param name="supplyPoints">Перечисление точек поставки электроэнергии.</param>
        /// <returns>Список расчетных приборов учета.</returns>
        private static List<AccountingDevice> InitializeAccountingDevices(ModelBuilder modelBuilder, IEnumerable<SupplyPoint> supplyPoints)
        {
            int accountingDeviceId = 1;
            var allAccountingDevices = new List<AccountingDevice>();

            foreach (var supplyPoint in supplyPoints)
            {
                var accountingDevice = RandomDataGenerator.CreateAccountingDevice(supplyPoint);
                accountingDevice.Id = accountingDeviceId++;
                allAccountingDevices.Add(accountingDevice);
            }

            return allAccountingDevices;
        }
    }
}