using AddressesClassifier.Models;
using NUnit.Framework;

namespace AddressesClassifierTests.ModelsTests
{
    [TestFixture]
    public class StreetModelTests
    {
        private Street _model;

        [SetUp]
        public void SetUp()
        {
            _model = new Street();
        }

        [Test]
        [Description("В модели Street было изменено или удалено свойство Code")]
        public void NamePropertyCode_ReturnNotNull()
        {
            var model = _model.GetType().GetProperty("Code");
            Assert.NotNull(model);
        }
        [Test]
        [Description("В модели Street было изменено или удалено свойство Name")]
        public void NamePropertyName_ReturnNotNull()
        {
            var model = _model.GetType().GetProperty("Name");
            Assert.NotNull(model);
        }
        [Test]
        [Description("В модели Street было изменено или удалено свойство Contraction")]
        public void NamePropertyContraction_ReturnNotNull()
        {
            var model = _model.GetType().GetProperty("Contraction");
            Assert.NotNull(model);
        }
        [Test]
        [Description("В модели Street было изменено или удалено свойство PostIndex")]
        public void NamePropertyPostIndex_ReturnNotNull()
        {
            var model = _model.GetType().GetProperty("PostIndex");
            Assert.NotNull(model);
        }
    }
}
