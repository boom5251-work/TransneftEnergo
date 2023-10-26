namespace TransneftEnergo.DataAccess.Models
{
    /// <summary>
    /// Точка измерения электроэнергии.
    /// </summary>
    public sealed class MeasuringPoint
    {
        /// <summary>
        /// Уникальный идентификатор первичный ключ.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название.
        /// </summary>
        public required string Name { get; set; }



        /// <summary>
        /// Уникальный идентификатор объекта потребления (внешний ключ).
        /// </summary>
        public int ConsumptionObjectId { get; set; }

        /// <summary>
        /// Объект потребления.
        /// </summary>
        public ConsumptionObject ConsumptionObject { get; set; } = null!;



        /// <summary>
        /// Счетчик энергии.
        /// </summary>
        public EnergyMeter EnergyMeter { get; set; } = null!;

        /// <summary>
        /// Трансформатор тока.
        /// </summary>
        public CurrentTransformer CurrentTransformer { get; set; } = null!;

        /// <summary>
        /// Трансформер напряжения.
        /// </summary>
        public VoltageTransformer VoltageTransformer { get; set; } = null!;



        /// <summary>
        /// Список расчетных приборов учета.
        /// </summary>
        public List<AccountingDevice> AccountingDevices { get; } = new();
    }
}