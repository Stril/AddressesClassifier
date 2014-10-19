using System.Linq;
using AddressesClassifier;
using AddressesClassifier.Interfaces;
using ExampleUsageService;

namespace WinFormUsing
{
    public class ModelContract
    {
        public ModelContract()
        {
            Folder = "";
            ReaderType = Contracts.ReaderTypes.FirstOrDefault(p => p.CodeEnum == Contracts.ReaderTypesEnum.Odbc);
            GettingDataKladr = Queries.InitGettingDataKladr();
        }

        public string Folder { get; set; }
        public Contracts.ReaderType ReaderType { get; set; }
        public IReadFileClassifier ReadFileClassifier { get; set; }
        public IGettingDataKladr GettingDataKladr { get; set; }
    }
}
