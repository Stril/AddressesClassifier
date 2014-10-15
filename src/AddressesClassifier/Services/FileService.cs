using System.IO;

namespace AddressesClassifier.Services
{
    internal static class FileService
    {
        public static bool CheckKladrFile(string folder)
        {
            return File.Exists(GetKladrFileName(folder));
        }

        public static bool CheckStreetFile(string folder)
        {
            return File.Exists(GetStreetFileNmae(folder));
        }

        public static string GetKladrFileName(string folder)
        {
            return string.Format("{0}{1}kladr.dbf", folder, Path.DirectorySeparatorChar);
        }

        public static string GetStreetFileNmae(string folder)
        {
            return string.Format("{0}{1}street.dbf", folder, Path.DirectorySeparatorChar);
        }
    }
}
