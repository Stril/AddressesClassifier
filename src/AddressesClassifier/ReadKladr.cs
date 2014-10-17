using AddressesClassifier.Interfaces;
using AddressesClassifier.NinjectModules;
using Ninject;

namespace AddressesClassifier
{
    public class ReaderKladr
    {
        private readonly string _folder;

        public ReaderKladr(string folder)
        {
            _folder = folder;
        }
        
        /// <summary>
        /// Получение интерфейса чтение файла Кладра средствами библиотеки NDbfReaderEx
        /// </summary>
        /// <returns></returns>
        public IReadFileClassifier NdbfReader()
        {
            IKernel ninjectKernel = new StandardKernel(new ReadKladrNdbfNModule(_folder));
            var readFileClassifier = ninjectKernel.Get<IReadFileClassifier>();
            return readFileClassifier;
        }

        /// <summary>
        /// Получение интерфейса чтение файла Кладр используя api OLE DB с провайдером Microsoft.Jet.OLEDB.4.0
        /// </summary>
        /// <returns></returns>
        public IReadFileClassifier OleDbReader()
        {
            IKernel ninjectKernel = new StandardKernel(new ReadKladrOleDbNModule(_folder));
            var readFileClassifier = ninjectKernel.Get<IReadFileClassifier>();
            return readFileClassifier;
        }

        /// <summary>
        /// Получение интерфейса чтение файла Кладр используя api ODBC с использованием драйвера Driver={Microsoft dBASE Driver (*.dbf)};DriverID=277...
        /// </summary>
        /// <returns></returns>
        public IReadFileClassifier OdbcReader()
        {
            IKernel ninjectKernel = new StandardKernel(new ReadKladrOdbcNModule(_folder));
            var readFileClassifier = ninjectKernel.Get<IReadFileClassifier>();
            return readFileClassifier;
        }
    }
}
