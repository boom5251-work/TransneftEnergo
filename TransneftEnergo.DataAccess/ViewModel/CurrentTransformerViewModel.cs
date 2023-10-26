using TransneftEnergo.DataAccess.Models;
using TransneftEnergo.DataAccess.Models.Base;

namespace TransneftEnergo.DataAccess.ViewModel
{
    /// <summary>
    /// Модель представления трансформатора тока.
    /// </summary>
    public sealed class CurrentTransformerViewModel
    {
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
        /// Явное преобразование модели представления в модель домена.
        /// </summary>
        /// <param name="viewModel">Модель представления трансформатора тока.</param>
        public static explicit operator CurrentTransformer(CurrentTransformerViewModel viewModel)
        {
            return new CurrentTransformer
            {
                Type = viewModel.Type,
                Number = viewModel.Number,
                TransformationCoefficient = viewModel.TransformationCoefficient,
                VerificationDate = viewModel.VerificationDate
            };
        }
    }
}