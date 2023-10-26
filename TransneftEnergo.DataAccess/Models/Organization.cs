namespace TransneftEnergo.DataAccess.Models
{
    /// <summary>
    /// Организация.
    /// </summary>
    public sealed class Organization
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
        /// Список дочерних организаций.
        /// </summary>
        public List<SubsidiaryOrganization> SubsidiaryOrganizations { get; set; } = new();
    }
}