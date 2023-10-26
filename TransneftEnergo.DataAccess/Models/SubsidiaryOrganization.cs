namespace TransneftEnergo.DataAccess.Models
{
    /// <summary>
    /// Дочерняя организация.
    /// </summary>
    public sealed class SubsidiaryOrganization
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
        /// Уникальный идентификатор организации (внешний ключ).
        /// </summary>
        public required int OrganizationId { get; set; }

        /// <summary>
        /// Организация.
        /// </summary>
        public Organization Organization { get; set; } = null!;



        /// <summary>
        /// Список объектов потребления.
        /// </summary>
        public List<ConsumptionObject> ConsumptionObjects { get; set; } = new();
    }
}