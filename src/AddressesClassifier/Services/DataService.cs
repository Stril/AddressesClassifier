using System.Data;

namespace AddressesClassifier.Services
{
    public static class DataService
    {
        /// <summary>
        /// Получение DT со стандартной схемой (code, name, index, socr)
        /// </summary>
        /// <returns></returns>
        public static DataTable GetDataTableStandart()
        {
            var dataTable = new DataTable();
            dataTable.Columns.AddRange(new[]
            {new DataColumn("code"), new DataColumn("name"), new DataColumn("index"), new DataColumn("socr")});
            return dataTable;
        }

        /// <summary>
        /// Получение DT со схемой для базового отображения (code, name, trimcode, socr)
        /// </summary>
        /// <returns></returns>
        public static DataTable GetDataTableBase()
        {
            var dataTable = new DataTable();
            dataTable.Columns.AddRange(new[]
            {new DataColumn("code"), new DataColumn("name"), new DataColumn("socr"), new DataColumn("trimcode")});
            return dataTable;
        }
    }
}
