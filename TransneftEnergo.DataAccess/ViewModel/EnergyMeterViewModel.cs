using TransneftEnergo.DataAccess.Models;
using TransneftEnergo.DataAccess.Models.Base;

namespace TransneftEnergo.DataAccess.ViewModel
{
    /// <summary>
    /// Модель представления счетчика электроэнергии.
    /// </summary>
    public sealed class EnergyMeterViewModel
    {
        /// <summary>
        /// Тип счетчика энергии.
        /// </summary>
        public required EnergyMetterType Type { get; set; }

        /// <summary>
        /// Дата поверки.
        /// </summary>
        public required DateTime VerificationDate { get; set; }



        /// <summary>
        /// Явное преобразование модели представления в модель домена.
        /// </summary>
        /// <param name="viewModel">Модель представления счетчика электроэнергии.</param>
        public static explicit operator EnergyMeter(EnergyMeterViewModel viewModel)
        {
            return new EnergyMeter
            {
                Type = viewModel.Type,
                VerificationDate = viewModel.VerificationDate
            };
        }
    }
}