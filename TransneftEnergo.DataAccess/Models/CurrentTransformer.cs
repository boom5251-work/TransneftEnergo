using TransneftEnergo.DataAccess.Models.Base;

namespace TransneftEnergo.DataAccess.Models
{
    /// <summary>
    /// Трансформатор тока.
    /// </summary>
    public sealed class CurrentTransformer
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
        /// Тип трансформатора тока.
        /// </summary>
        public required TransformerType Type { get; set; }

        /// <summary>
        /// Дата поверки.
        /// </summary>
        public required DateTime VerificationDate { get; set; }

        /// <summary>
        /// КТТ (коэффициент трансформации).
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