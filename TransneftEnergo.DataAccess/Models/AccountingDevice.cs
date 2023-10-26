namespace TransneftEnergo.DataAccess.Models
{
    /// <summary>
    /// Расчетный прибор учета.
    /// </summary>
    public sealed class AccountingDevice
    {
        /// <summary>
        /// Уникальный идентификатор (первичный ключ).
        /// </summary>
        public int Id { get; set; }



        /// <summary>
        /// Уникальный идентификатор точки поставки электроэнергии (внешний ключ).
        /// </summary>
        public int SupplyPointId { get; set; }

        /// <summary>
        /// Точка поставки электроэнергии.
        /// </summary>
        public SupplyPoint SupplyPoint { get; set; } = null!;



        /// <summary>
        /// Список точек измерения электроэнергии.
        /// </summary>
        public List<MeasuringPoint> MeasuringPoints { get; } = new();
    }
}