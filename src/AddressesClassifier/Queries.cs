using AddressesClassifier.Interfaces;
using AddressesClassifier.NinjectModules;
using Ninject;

namespace AddressesClassifier
{
    public static class Queries
    {
        public static IGettingDataKladr InitGettingDataKladr()
        {
            IKernel ninjectKernel = new StandardKernel(new AddressesServiceNModule());
            return ninjectKernel.Get<IGettingDataKladr>();
        }
    }
}
