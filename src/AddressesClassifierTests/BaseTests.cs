using System;
using System.IO;
using NUnit.Framework;

namespace AddressesClassifierTests
{
    [TestFixture]
    public class BaseTests
    {
        [Test]
        [Description("Отсутсвует файл kladr.dbf в проекте для тестировния")]
        public void FileKladrExistsInPoject_ReturnTrue()
        {
            Assert.IsTrue(File.Exists(Environment.CurrentDirectory + Path.DirectorySeparatorChar + @"Files\kladr.dbf"));
        }

        [Test]
        [Description("Отсутсвует файл street.dbf в проекте для тестировния")]
        public void FileStreetExistsInPoject_ReturnTrue()
        {
            Assert.IsTrue(File.Exists(Environment.CurrentDirectory + Path.DirectorySeparatorChar + @"Files\street.dbf"));
        }
    }
}
