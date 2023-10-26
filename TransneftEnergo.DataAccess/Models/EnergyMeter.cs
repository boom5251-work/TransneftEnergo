using TransneftEnergo.DataAccess.Models.Base;

namespace TransneftEnergo.DataAccess.Models
{
    /// <summary>
    /// Счетчик электроэнергии.
    /// </summary>
    public sealed class EnergyMeter
    {
        /// <summary>
        /// Уникальный идентификатор (первичный ключ).
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Тип счетчика энергии.
        /// </summary>
        public required EnergyMetterType Type { get; set; }

        /// <summary>
        /// Дата поверки.
        /// </summary>
        public required DateTime VerificationDate { get; set; }



        /// <summary>
        /// Уникальный идентификатор точки измерения энергии (внешний ключ).
        /// </summary>
        public int MeasuringPointId { get; set; }

        /// <summary>
        /// Точка измерения электроэнергии.
        /// </summary>
        public MeasuringPoint MeasuringPoint { get; set; } = null!;
    }
}