using System.Collections.Generic;

namespace ExampleUsageService
{
    public static class Contracts
    {
        public class ReaderType
        {
            public string Name { get; set; }
            public ReaderTypesEnum CodeEnum { get; set; }
        }

        public static IEnumerable<ReaderType> ReaderTypes
        {
            get
            {
                return new List<ReaderType>
                {
                    new ReaderType {CodeEnum = ReaderTypesEnum.Odbc, Name = "ODBC"},
                    new ReaderType {CodeEnum = ReaderTypesEnum.Oledb, Name = "OLE DB"},
                    new ReaderType {CodeEnum = ReaderTypesEnum.NDbfReaderEx, Name = "NDbfReaderEx"},

                };
            }
        }

        public enum ReaderTypesEnum
        {
            Oledb,
            Odbc,
            NDbfReaderEx
        }
    }
}
