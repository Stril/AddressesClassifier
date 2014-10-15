namespace AddressesClassifier.Models
{
    /// <summary>
    /// Реализует регионы с двузначными кодами
    /// </summary>
    public class Territory
    {
        /// <summary>
        /// Код, идентификатор
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Сокращение
        /// </summary>
        public string Contraction { get; set; }
        /// <summary>
        /// Код территории
        /// </summary>
        public string TrimCode { get; set; }
    }
}
