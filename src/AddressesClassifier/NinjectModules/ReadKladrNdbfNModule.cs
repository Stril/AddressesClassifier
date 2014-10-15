using AddressesClassifier.Implementations;
using AddressesClassifier.Interfaces;
using Ninject.Modules;

namespace AddressesClassifier.NinjectModules
{
    internal class ReadKladrNdbfNModule : NinjectModule
    {
        private readonly string _path;

        public ReadKladrNdbfNModule(string path)
        {
            _path = path;
        }

        public override void Load()
        {
            Bind<IReadFileClassifier>().To<ReadFileClassifierNdbf>()
                .WithConstructorArgument("folder", _path);
            Bind<ReadFileClassifierNdbf>().ToSelf();
        }
    }
}
