using AddressesClassifier.Interfaces;
using AddressesClassifier.NinjectModules;
using Ninject;

namespace AddressesClassifier
{
    public class ReadKladr
    {
        private readonly string _folder;

        public ReadKladr(string folder)
        {
            _folder = folder;
        }

        public IReadFileClassifier NdbfReader()
        {
            IKernel ninjectKernel = new StandardKernel(new ReadKladrNdbfNModule(_folder));
            var readFileClassifier = ninjectKernel.Get<IReadFileClassifier>();
            return readFileClassifier;
        }

        public IReadFileClassifier OleDbReader()
        {
            IKernel ninjectKernel = new StandardKernel(new ReadKladrOleDbNModule(_folder));
            var readFileClassifier = ninjectKernel.Get<IReadFileClassifier>();
            return readFileClassifier;
        }
    }
}
