using AddressesClassifier.Models;
using NUnit.Framework;

namespace AddressesClassifierTests.ModelsTests
{
    [TestFixture]
    public class TerritoryModelTests
    {
        private Territory _model;

        [SetUp]
        public void SetUp()
        {
            _model = new Territory();
        }

        [Test]
        [Description("В модели Territory было изменено или удалено свойство Code")]
        public void NamePropertyCode_ReturnNotNull()
        {
            var model = _model.GetType().GetProperty("Code");
            Assert.NotNull(model);
        }

        [Test]
        [Description("В модели Territory было изменено или удалено свойство Name")]
        public void NamePropertyName_ReturnNotNull()
        {
            var model = _model.GetType().GetProperty("Name");
            Assert.NotNull(model);
        }

        [Test]
        [Description("В модели Territory было изменено или удалено свойство Contraction")]
        public void NamePropertyContraction_ReturnNotNull()
        {
            var model = _model.GetType().GetProperty("Contraction");
            Assert.NotNull(model);
        }

        [Test]
        [Description("В модели Territory было изменено или удалено свойство TrimCode")]
        public void NamePropertyPostIndex_ReturnNotNull()
        {
            var model = _model.GetType().GetProperty("TrimCode");
            Assert.NotNull(model);
        }
    }
}
