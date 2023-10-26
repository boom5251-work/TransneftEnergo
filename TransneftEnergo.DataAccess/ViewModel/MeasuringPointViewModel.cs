using TransneftEnergo.DataAccess.Models;

namespace TransneftEnergo.DataAccess.ViewModel
{
    /// <summary>
    /// Модель представления точка измерения электроэнергии.
    /// </summary>
    public sealed class MeasuringPointViewModel
    {
        /// <summary>
        /// Название.
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// Уникальный идентификатор объекта потребления.
        /// </summary>
        public required int ConsumptionObjectId { get; set; }

        /// <summary>
        /// Модель представления счетчика электроэнергии.
        /// </summary>
        public required EnergyMeterViewModel EnergyMeter { get; set; }

        /// <summary>
        /// Модель представления трансформатора тока.
        /// </summary>
        public required CurrentTransformerViewModel CurrentTransformer { get; set; }

        /// <summary>
        /// Модель представления трансформатор напряжения.
        /// </summary>
        public required VoltageTransformerViewModel VoltageTransformer { get; set; }



        /// <summary>
        /// Явное преобразование модели представления в модель домена.
        /// </summary>
        /// <param name="viewModel">Модель представления точки измерения электроэнергии.</param>
        public static explicit operator MeasuringPoint(MeasuringPointViewModel viewModel)
        {
            var measuringPoint = new MeasuringPoint
            {
                Name = viewModel.Name,
                ConsumptionObjectId = viewModel.ConsumptionObjectId,
                EnergyMeter = (EnergyMeter)viewModel.EnergyMeter,
                CurrentTransformer = (CurrentTransformer)viewModel.CurrentTransformer,
                VoltageTransformer = (VoltageTransformer)viewModel.VoltageTransformer
            };

            return measuringPoint;
        }
    }
}