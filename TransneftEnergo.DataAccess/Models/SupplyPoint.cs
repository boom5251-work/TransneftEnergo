namespace TransneftEnergo.DataAccess.Models
{
    /// <summary>
    /// Точка поставки электроэнергии.
    /// </summary>
    public sealed class SupplyPoint
    {
        /// <summary>
        /// Уникальный идентификатор (первичный ключ).
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название.
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// Максимальная мощность кВт.
        /// </summary>
        public required double MaxPower { get; set; }



        /// <summary>
        /// Уникальный идентификатор объекта потребления (внешний ключ).
        /// </summary>
        public int ConsumptionObjectId { get; set; }

        /// <summary>
        /// Объект потребления.
        /// </summary>
        public ConsumptionObject ConsumptionObject { get; set; } = null!;

        /// <summary>
        /// Расчетный прибор учета.
        /// </summary>
        public AccountingDevice AccountingDevice { get; set; } = null!;
    }
}