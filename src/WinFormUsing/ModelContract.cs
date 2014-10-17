using System.Linq;
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
        }

        public string Folder { get; set; }
        public Contracts.ReaderType ReaderType { get; set; }
        public IReadFileClassifier ReadFileClassifier { get; set; }
    }
}
