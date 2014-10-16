using AddressesClassifier.Implementations;
using AddressesClassifier.Interfaces;
using Ninject.Modules;

namespace AddressesClassifier.NinjectModules
{
    public class ReadKladrOdbcNModule : NinjectModule
    {
        private readonly string _path;

        public ReadKladrOdbcNModule(string path)
        {
            _path = path;
        }

        public override void Load()
        {
            Bind<IReadFileClassifier>().To<ReadFileClassifierOdbc>()
                .WithConstructorArgument("folder", _path);
            Bind<ReadFileClassifierOdbc>().ToSelf();
        }
    }
}
