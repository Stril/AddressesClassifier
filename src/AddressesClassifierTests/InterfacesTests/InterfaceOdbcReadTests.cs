﻿using System;
using System.IO;
using System.Linq;
using AddressesClassifier;
using NUnit.Framework;

namespace AddressesClassifierTests.InterfacesTests
{
    [TestFixture]
    public class InterfaceOdbcReadTests
    {
        private string _folder;
        private ReaderKladr _readerKladr;

        [SetUp]
        public void SetUp()
        {
            _folder = string.Format("{0}{1}files", Environment.CurrentDirectory, Path.DirectorySeparatorChar);
            _readerKladr = new ReaderKladr(_folder);
        }

        [Test]
        public void ReadAllRegions_DataTableNotNullAndCountIs59_ReturnTrue()
        {
            var data = _readerKladr.OdbcReader().ReadAllRegions();
            Assert.IsTrue(data != null && data.Rows.Count == 59);
        }

        [Test]
        public void ReadRegion83_CountIs56_ReturnTrue()
        {
            var data = _readerKladr.OdbcReader().ReadRegion("83");
            Assert.IsTrue(data != null && data.Rows.Count == 56);
        }

        [Test]
        public void ReadRegionBaseInfo_CountIs2_ReturnTrue()
        {
            var data = _readerKladr.OdbcReader().ReadBaseInfo();
            Assert.IsTrue(data != null && data.Rows.Count == 2);
        }

        [Test]
        public void ReadAllRegionsModel_CountIs56_ReturnTrue()
        {
            var data = _readerKladr.OdbcReader().ReadAllRegionsModel();
            Assert.IsTrue(data != null && data.Count() == 59);
        }

        [Test]
        public void ReadRegionModel83_CountIs56_ReturnTrue()
        {
            var data = _readerKladr.OdbcReader().ReadRegionModel("83");
            Assert.IsTrue(data.Count() == 56);
        }

        [Test]
        public void ReadRegionModel99_CountIs3_ReturnTrue()
        {
            var data = _readerKladr.OdbcReader().ReadRegionModel("99");
            Assert.IsTrue(data.Count() == 3);
        }

        [Test]
        public void ReadRegionBaseInfoModel_CountIs2_ReturnTrue()
        {
            var data = _readerKladr.OdbcReader().ReadBaseInfoModel();
            Assert.IsTrue(data.Count() == 2);
        }

        [Test]
        public void ReadRegionBaseInfoModel_CheckNameRegion99_ReturnTrue()
        {
            var data = _readerKladr.OdbcReader().ReadBaseInfoModel();
            var item = data.FirstOrDefault(p => p.Code.StartsWith("99"));
            Assert.IsTrue(item != null && item.Name == "Байконур");
        }

        [Test]
        public void ReadAllStreets_CountIs415_ReturnTrue()
        {
            var data = _readerKladr.OdbcReader().ReadAllStreets();
            Assert.IsTrue(data.Rows.Count == 415);
        }

        [Test]
        public void ReadStreetsByRegion83_CountIs320_ReturnTrue()
        {
            var data = _readerKladr.OdbcReader().ReadStreetsByRegion("83");
            Assert.IsTrue(data.Rows.Count == 320);
        }

        [Test]
        public void ReadAllStreetsModel_CountIs415_ReturnTrue()
        {
            var data = _readerKladr.OdbcReader().ReadAllStreetsModel();
            Assert.IsTrue(data.Count() == 415);
        }

    }
}
