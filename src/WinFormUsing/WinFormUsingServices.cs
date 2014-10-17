using System;
using AddressesClassifier;
using AddressesClassifier.Interfaces;
using ExampleUsageService;

namespace WinFormUsing
{
    public static class WinFormUsingServices
    {
        public static IReadFileClassifier GetReadFileClassifier(ModelContract contract)
        {
            if(contract == null) return null;
            if(contract.ReaderType == null) return null;
            if(string.IsNullOrEmpty(contract.Folder)) return null;
            
            var reader = new ReaderKladr(contract.Folder);
            switch (contract.ReaderType.CodeEnum)
            {
                case Contracts.ReaderTypesEnum.Oledb:
                    return reader.OleDbReader();
                case Contracts.ReaderTypesEnum.Odbc:
                    return reader.OdbcReader();
                case Contracts.ReaderTypesEnum.NDbfReaderEx:
                    return reader.NdbfReader();
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
