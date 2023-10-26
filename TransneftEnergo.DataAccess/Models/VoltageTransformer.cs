using TransneftEnergo.DataAccess.Models.Base;

namespace TransneftEnergo.DataAccess.Models
{
    /// <summary>
    /// Трансформатор напряжения.
    /// </summary>
    public sealed class VoltageTransformer
    {
        /// <summary>
        /// Уникальный идентификатор (первичный ключ).
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Номер.
        /// </summary>
        public required long Number { get; set; }

        /// <summary>
        /// Тип трансформатора напряжения.
        /// </summary>
        public required TransformerType Type { get; set; }

        /// <summary>
        /// Дата поверки.
        /// </summary>
        public required DateTime VerificationDate { get; set; }

        /// <summary>
        /// КТН (коэффициент трансформации).
        /// </summary>
        public required double TransformationCoefficient { get; set; }



        /// <summary>
        /// Уникальный идентификатор точки измерения энергии (внешний ключ).
        /// </summary>
        public int MeasuringPointId { get; set; }

        /// <summary>
        /// Точка измерения энергии.
        /// </summary>
        public MeasuringPoint MeasuringPoint { get; set; } = null!;
    }
}