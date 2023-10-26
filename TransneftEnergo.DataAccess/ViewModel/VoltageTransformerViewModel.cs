using TransneftEnergo.DataAccess.Models;
using TransneftEnergo.DataAccess.Models.Base;

namespace TransneftEnergo.DataAccess.ViewModel
{
    /// <summary>
    /// Модель представления трансформатора напряжения.
    /// </summary>
    public sealed class VoltageTransformerViewModel
    {
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
        /// Явное преобразование модели представления в модель домена.
        /// </summary>
        /// <param name="viewModel">Модель представления трансформатора напряжения.</param>
        public static explicit operator VoltageTransformer(VoltageTransformerViewModel viewModel)
        {
            return new VoltageTransformer
            {
                Type = viewModel.Type,
                Number = viewModel.Number,
                TransformationCoefficient = viewModel.TransformationCoefficient,
                VerificationDate = viewModel.VerificationDate
            };
        }
    }
}