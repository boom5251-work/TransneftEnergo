using System.ComponentModel.DataAnnotations.Schema;

namespace TransneftEnergo.DataAccess.Models
{
    /// <summary>
    /// Объект потребления.
    /// </summary>
    public sealed class ConsumptionObject
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
        /// Адрес.
        /// </summary>
        public required string Address { get; set; }



        /// <summary>
        /// Уникальный идентификатор дочерней организации (внешний ключ).
        /// </summary>
        public int SubsidiaryOrganizationId { get; set; }

        /// <summary>
        /// Дочерняя организация.
        /// </summary>
        public SubsidiaryOrganization SubsidiaryOrganization { get; set; } = null!;



        /// <summary>
        /// Список точек измерения электроэнергии.
        /// </summary>
        public List<MeasuringPoint> MeasuringPoints { get; set; } = new();

        /// <summary>
        /// Список точек поставки электроэнергии.
        /// </summary>
        public List<SupplyPoint> SupplyPoints { get; set; } = new();
    }
}