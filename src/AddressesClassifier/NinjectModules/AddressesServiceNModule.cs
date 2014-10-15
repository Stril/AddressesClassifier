using AddressesClassifier.Implementations;
using AddressesClassifier.Interfaces;
using Ninject.Modules;

namespace AddressesClassifier.NinjectModules
{
    internal class AddressesServiceNModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IGettingDataKladr>().To<GettingDataKladr>();
            Bind<GettingDataKladr>().ToSelf();
        }
    }
}
