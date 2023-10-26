using Microsoft.EntityFrameworkCore;

namespace TransneftEnergo.DataAccess.Models
{
    /// <summary>
    /// Сущность соединения точки измерения электроэнергии и расчетного прибора учета.
    /// </summary>
    public sealed class MeasuringPointAccountingDevice
    {
        /// <summary>
        /// Дата ввода в эксплуатацию.
        /// </summary>
        public DateTime FromDate { get; set; }

        /// <summary>
        /// Дата вывода из эксплуатации.
        /// </summary>
        public DateTime ToDate { get; set; }



        /// <summary>
        /// Уникальный идентификатор точки измерения электроэнергии (внешний ключ).
        /// </summary>
        public int MeasuringPointId { get; set; }

        /// <summary>
        /// Уникальный идентификатор расчетного прибора учета (внешний ключ).
        /// </summary>
        public int AccountingDeviceId { get; set; }
    }
}