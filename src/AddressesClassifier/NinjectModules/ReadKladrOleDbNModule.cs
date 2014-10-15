using AddressesClassifier.Implementations;
using AddressesClassifier.Interfaces;
using Ninject.Modules;

namespace AddressesClassifier.NinjectModules
{
    internal class ReadKladrOleDbNModule : NinjectModule
    {
        private readonly string _path;

        public ReadKladrOleDbNModule(string path)
        {
            _path = path;
        }

        public override void Load()
        {
            Bind<IReadFileClassifier>().To<ReadFileClassifierOleDb>()
             .WithConstructorArgument("folder", _path);
            Bind<ReadFileClassifierNdbf>().ToSelf();
        }
    }
}
