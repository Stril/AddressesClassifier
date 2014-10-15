namespace AddressesClassifier.Models
{
    /// <summary>
    /// Реализует субъекты, города, населенные пункты
    /// </summary>
    public class Region
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
        /// <summary>
        /// Признак городафедерального значения (Москва, Спб, Севастополь)
        /// </summary>
        public bool IsFederalCity { get; set; }
    }
}
