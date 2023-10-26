using TransneftEnergo.DataAccess.Models;
using TransneftEnergo.DataAccess.Models.Base;

namespace TransneftEnergo.DataAccess.DefaultData
{
    /// <summary>
    /// Генератор псевдослучайных данных.
    /// </summary>
    public static class RandomDataGenerator
    {
        /// <summary>
        /// Создает случайные организации.
        /// </summary>
        /// <param name="count">Число случайных организаций.</param>
        /// <returns>Список случайных организаций.</returns>
        public static IEnumerable<Organization> CreateOrganizations(int count)
        {    
            var organizations = new List<Organization>();

            var names = CreateOrganizationNames(count);
            var addresses = CreateAddresses(count);

            for (int i = 0; i < count; i++)
            {
                var organization = new Organization
                {
                    Name = names[i],
                    Address = addresses[i]
                };

                organizations.Add(organization);
            }

            return organizations;
        }


        /// <summary>
        /// Создает случайные дочерние организации для существующей организации.
        /// </summary>
        /// <param name="organization">Организация.</param>
        /// <param name="count">Число случайных дочерних организаций.</param>
        /// <returns>Список случайных дочерних организаций.</returns>
        public static IEnumerable<SubsidiaryOrganization> CreateSubsidiaryOrganizations(Organization organization, int count)
        {
            var subsidiaryOrganizations = new List<SubsidiaryOrganization>();

            var names = CreateOrganizationNames(count);
            var addresses = CreateAddresses(count);

            for (int i = 0; i < count; i++)
            {
                var subsidiaryOrganization = new SubsidiaryOrganization
                {
                    Name = names[i],
                    Address = addresses[i],
                    OrganizationId = organization.Id
                };

                subsidiaryOrganizations.Add(subsidiaryOrganization);
            }

            return subsidiaryOrganizations;
        }


        /// <summary>
        /// Создает случайные объекты потребления.
        /// </summary>
        /// <param name="subsidiaryOrganization">Дочерняя организация.</param>
        /// <param name="count">Число случайных объектов потребления.</param>
        /// <returns>Список случайных объектов потребления.</returns>
        public static IEnumerable<ConsumptionObject> CreateConsumptionsObjects(SubsidiaryOrganization subsidiaryOrganization, int count)
        {
            var consumptionObjects = new List<ConsumptionObject>();

            var random = new Random();
            var seasons = new List<string> { "Зима", "Весна", "Лето", "Осень" };
            var addresses = CreateAddresses(count);

            for (int i = 0; i < count; i++)
            {
                string name = $"ПС {random.Next(100) * 10}/{random.Next(10) * 10} {seasons[random.Next(4)]}";

                var consumptionObject = new ConsumptionObject
                {
                    Name = name,
                    Address = addresses[i],
                    SubsidiaryOrganizationId = subsidiaryOrganization.Id
                };

                consumptionObjects.Add(consumptionObject);
            }

            return consumptionObjects;
        }


        /// <summary>
        /// Создает случайные точки измерения энергии.
        /// </summary>
        /// <param name="consumptionObject">Объект потребления.</param>
        /// <param name="count">Число случайных точек измерения энергии.</param>
        /// <returns>Список случайных точек измерения электроэнергии.</returns>
        public static IEnumerable<MeasuringPoint> CreateMeasuringPoints(ConsumptionObject consumptionObject, int count)
        {
            var measuringPoints = new List<MeasuringPoint>();

            var random = new Random();

            for (int i = 0; i < count; i++)
            {
                var measuringPoint = new MeasuringPoint
                {
                    Name = $"Точка измерения электроэнергии № {random.Next(1000000000)}",
                    ConsumptionObjectId = consumptionObject.Id
                };

                measuringPoints.Add(measuringPoint);
            }

            return measuringPoints;
        }


        /// <summary>
        /// Создает случайные точки поставки энергии.
        /// </summary>
        /// <param name="consumptionObject">Объект потребления.</param>
        /// <param name="count">Число случайных точек поставки энергии.</param>
        /// <returns>Список случайных точек поставок электроэнергии.</returns>
        public static IEnumerable<SupplyPoint> CreateSupplyPoints(ConsumptionObject consumptionObject, int count)
        {
            var supplyPoints = new List<SupplyPoint>();

            var random = new Random();

            for (int i = 0; i < count; i++)
            {
                var supplyPoint = new SupplyPoint
                {
                    Name = $"Точка поставки электроэнергии № {random.NextInt64(1000000000)}",
                    MaxPower = random.NextDouble() * random.Next(1, 100),
                    ConsumptionObjectId = consumptionObject.Id
                };

                supplyPoints.Add(supplyPoint);
            }

            return supplyPoints;
        }


        /// <summary>
        /// Создает случайное оборудование точки измерения электроэнергии.
        /// </summary>
        /// <param name="measuringPoint">Точка измерения электроэнергии.</param>
        /// <returns>Кортеж: счетчик энергии, трансформатор тока, трансформатор напряжения.</returns>
        public static (EnergyMeter, CurrentTransformer, VoltageTransformer) CreateHardware(MeasuringPoint measuringPoint)
        {
            var random = new Random();

            var energyMeter = new EnergyMeter
            {
                Type = EnergyMetterType.Default,
                VerificationDate = CreateRandomDate(),
                MeasuringPointId = measuringPoint.Id
            };

            var currentTransformer = new CurrentTransformer
            {
                TransformationCoefficient = Math.Round(random.NextDouble(), 2),
                Number = random.NextInt64(1000000000),
                Type = TransformerType.Default,
                VerificationDate = CreateRandomDate(),
                MeasuringPointId = measuringPoint.Id
            };

            var VoltageTransformer = new VoltageTransformer
            {
                TransformationCoefficient = Math.Round(random.NextDouble(), 2),
                Number = random.NextInt64(1000000000),
                Type = TransformerType.Default,
                VerificationDate = CreateRandomDate(),
                MeasuringPointId = measuringPoint.Id
            };

            return (energyMeter, currentTransformer, VoltageTransformer);
        }


        /// <summary>
        /// Создает расчетный прибор учета.
        /// </summary>
        /// <param name="supplyPoint">Точка поставки электроэнергии.</param>
        /// <returns>Расчетный прибор учета.</returns>
        public static AccountingDevice CreateAccountingDevice(SupplyPoint supplyPoint)
        {
            return new AccountingDevice()
            {
                SupplyPointId = supplyPoint.Id
            };
        }


        /// <summary>
        /// Создает случайные связи точек измерения электроэнергии и расчетных приборов учета.
        /// </summary>
        /// <param name="measuringPoints">Список точек измерения электроэнергии.</param>
        /// <param name="accountingDevices">Список расчетных приборов учета.</param>
        /// <param name="count">Число случайных связей.</param>
        /// <returns>Случайные связи.</returns>
        public static IEnumerable<MeasuringPointAccountingDevice> CreateBindings(List<MeasuringPoint> measuringPoints, List<AccountingDevice> accountingDevices, int count)
        {
            var bindings = new List<MeasuringPointAccountingDevice>();

            var random = new Random();

            for (int i = 0; i < count; i++)
            {
                var measuringPoint = measuringPoints[random.Next(measuringPoints.Count)];
                var accountingDevice = accountingDevices[random.Next(accountingDevices.Count)];

                var fromDate = CreateRandomDate();
                var toDate = CreateRandomDate(fromDate);

                var binding = new MeasuringPointAccountingDevice
                {
                    MeasuringPointId = measuringPoint.Id,
                    AccountingDeviceId = accountingDevice.Id,
                    FromDate = fromDate,
                    ToDate = toDate
                };

                bindings.Add(binding);
            }

            return bindings;
        }



        /// <summary>
        /// Создает список случайных названий организаций.
        /// </summary>
        /// <param name="count">Число случайных названий.</param>
        /// <returns>Список случайных названий организаций.</returns>
        private static List<string> CreateOrganizationNames(int count)
        {
            var prefixes = new List<string> { "АО", "ОАО", "ЗАО", "ПАО", "НПАО", "ООО", "РАО" };
            var firstParts = new List<string> { "Оптовая", "Территориальная", "Муниципальная", "Государственная" };
            var secondParts = new List<string> { "генерирующая компания", "энерго-компания", "Энерго", "ГК Энергосети", "ГК №1", "ГК №2", "ГК №3" };
            var regions = new List<string> { "Север", "Юг", "Запад", "Восток", "Центр", "Москва", "ЛенОбл", "Кубань", "Донбасс", "Урал", "Сибирь" };

            var random = new Random();
            var names = new List<string>();

            for (int i = 0; i < count; i++)
            {
                string prefix = prefixes[random.Next(prefixes.Count)];
                string firstPart = firstParts[random.Next(firstParts.Count)];
                string secondPart = secondParts[random.Next(secondParts.Count)];
                string region = regions[random.Next(regions.Count)];

                names.Add($"{prefix} «{firstPart} {secondPart} {region}»");
            }
                
            return names;
        }


        /// <summary>
        /// Создает список случайных адресов.
        /// </summary>
        /// <param name="count">Число случайных адресов.</param>
        /// <returns>Список случайных адресов.</returns>
        private static List<string> CreateAddresses(int count)
        {
            var prefixes = new List<string> { "д.", "с.", "пгт", "г." };
            var firstParts = new List<string> { "Дам", "Кор", "Нов", "Камин", "Лен", "Слав", "Свят", "Гор", "Рин" };
            var secondParts = new List<string> { "ин", "ян", "инск", "янск", "ск", "ий", "ый", "ка" };
            var streetPostfixes = new List<string> { "ская", "ова", "ина", "ева", "овой", "иной", "евой" };

            var random = new Random();
            var addresses = new List<string>();

            for (int i = 0; i < count; i++)
            {
                string prefix = prefixes[random.Next(prefixes.Count)];
                string firstPart = firstParts[random.Next(firstParts.Count)];
                string nextFirstPart = firstParts[random.Next(firstParts.Count)];
                string secondPart = secondParts[random.Next(secondParts.Count)];

                if ((secondPart == "ий" || secondPart == "ый") && random.NextDouble() < 0.25)
                    secondPart += " Яр";

                if ((secondPart == "ка") && random.NextDouble() < 0.5)
                    firstPart = "Усть-" + firstPart;

                string street = $"{firstParts[random.Next(firstParts.Count)]}о{firstParts[random.Next(firstParts.Count)].ToLower()}{streetPostfixes[random.Next(streetPostfixes.Count)]}";

                string address = $"{prefix} {firstPart}о{nextFirstPart.ToLower()}{secondPart}, ул. {street}, д. {random.Next(1, 50)}";

                if (random.NextDouble() < 0.4)
                    address += $", к. {random.Next(1, 5)}";

                addresses.Add(address);
            }

            return addresses;
        }


        /// <summary>
        /// Создает случайную дату с 1 января 2017 года или с указанной даты.
        /// </summary>
        /// <param name="after">Создать дату после указанной.</param>
        /// <returns>Случайная дата.</returns>
        private static DateTime CreateRandomDate(DateTime? after = null)
        {
            var from = after is null ? new DateTime(2000, 1, 1) : after;
            var to = new DateTime(2030, 1, 1);

            long fromSeconds = ((DateTimeOffset)from).ToUnixTimeSeconds();
            long toSeconds = ((DateTimeOffset)to).ToUnixTimeSeconds();

            long randomSeconds = new Random().NextInt64(fromSeconds, toSeconds);
            return DateTimeOffset.FromUnixTimeSeconds(randomSeconds).Date;
        }
    }
}