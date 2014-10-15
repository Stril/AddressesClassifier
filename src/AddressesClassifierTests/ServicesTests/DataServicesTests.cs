using AddressesClassifier.Services;
using NUnit.Framework;

namespace AddressesClassifierTests.ServicesTests
{
    [TestFixture]
    public class DataServicesTests
    {
        [Test]
        public void GetDataTableStandart_CheckColumnCode_ReturnNotNull()
        {
            var dt = DataService.GetDataTableStandart();
            Assert.IsNotNull(dt.Columns["code"]);
        }

        [Test]
        public void GetDataTableStandart_CheckColumnName_ReturnNotNull()
        {
            var dt = DataService.GetDataTableStandart();
            Assert.IsNotNull(dt.Columns["name"]);
        }

        [Test]
        public void GetDataTableStandart_CheckColumnIndex_ReturnNotNull()
        {
            var dt = DataService.GetDataTableStandart();
            Assert.IsNotNull(dt.Columns["index"]);
        }

        [Test]
        public void GetDataTableStandart_CheckColumnSocr_ReturnNotNull()
        {
            var dt = DataService.GetDataTableStandart();
            Assert.IsNotNull(dt.Columns["socr"]);
        }

        [Test]
        public void GetDataTableStandart_ColumnCountIs4_ReturnTrue()
        {
            var dt = DataService.GetDataTableStandart();
            Assert.IsTrue(dt.Columns.Count == 4);
        }

        [Test]
        public void GetDataTableBase_CheckColumnCode_ReturnNotNull()
        {
            var dt = DataService.GetDataTableBase();
            Assert.IsNotNull(dt.Columns["code"]);
        }

        [Test]
        public void GetDataTableBase_CheckColumnName_ReturnNotNull()
        {
            var dt = DataService.GetDataTableBase();
            Assert.IsNotNull(dt.Columns["name"]);
        }

        [Test]
        public void GetDataTableBase_CheckColumnSocr_ReturnNotNull()
        {
            var dt = DataService.GetDataTableBase();
            Assert.IsNotNull(dt.Columns["socr"]);
        }

        [Test]
        public void GetDataTableBase_CheckColumnTrimCode_ReturnNotNull()
        {
            var dt = DataService.GetDataTableBase();
            Assert.IsNotNull(dt.Columns["trimcode"]);
        }

        [Test]
        public void GetDataTableBase_ColumnCountIs4_ReturnTrue()
        {
            var dt = DataService.GetDataTableBase();
            Assert.IsTrue(dt.Columns.Count == 4);
        }
    }
}