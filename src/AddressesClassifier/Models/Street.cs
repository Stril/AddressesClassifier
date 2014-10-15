namespace AddressesClassifier.Models
{
    /// <summary>
    /// Реализует улицы
    /// </summary>
    public class Street
    {
        /// <summary>
        /// Код, идетификатор
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
        /// Почтовый индекс
        /// </summary>
        public string PostIndex { get; set; }
    }
}
