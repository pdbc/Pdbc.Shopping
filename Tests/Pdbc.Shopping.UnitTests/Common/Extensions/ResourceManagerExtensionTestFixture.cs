using NUnit.Framework;
using Pdbc.Shopping.Common.Extensions;
using Pdbc.Shopping.I18N;
using Pdbc.Shopping.Tests.Helpers;
using Pdbc.Shopping.Tests.Helpers.Extensions;

namespace Pdbc.Shopping.UnitTests.Common.Extensions
{
    public class ResourceManagerExtensionTestFixture : BaseSpecification
    {
        [Test]
        public void Verify_resources_can_be_retrieved_in_specific_language()
        {
            var items =  UnitTestResources.ResourceManager.GetResources("nl");
            items.ShouldHaveCount(3);
        }

        [Test]
        public void Verify_resources_can_be_retrieved_in_specific_language_in_different_casing()
        {
            var items = UnitTestResources.ResourceManager.GetResources("NL");
            items.ShouldHaveCount(3);
        }

        [Test]
        public void Verify_resources_can_be_retrieved_in_generic_language_specified()
        {
            var items = UnitTestResources.ResourceManager.GetResources("en");
            items.ShouldHaveCount(3);
        }

        [Test]
        public void Verify_resources_can_be_retrieved_in_not_specified_language()
        {
            var items = UnitTestResources.ResourceManager.GetResources("es");
            items.ShouldHaveCount(3);
        }

        [Test]
        public void Verify_resources_can_be_retrieved_by_default_language()
        {
            var items = UnitTestResources.ResourceManager.GetResources(null);
            items.ShouldHaveCount(3);
        }


        [Test]
        public void Verify_resources_by_key_can_be_retrieved_by_default_language()
        {
            var item = UnitTestResources.ResourceManager.GetResourceByKey(nameof(UnitTestResources.Label_Name));
            item.ShouldBeEqualTo("Name");
        }

        [Test]
        public void Verify_resources_by_key_can_be_retrieved_in_dutch()
        {
            var item = UnitTestResources.ResourceManager.GetResourceByKey(nameof(UnitTestResources.Label_Name), "nl");
            item.ShouldBeEqualTo("Naam");
        }

        [Test]
        public void Verify_resources_by_key_can_be_retrieved_in_not_specified_language()
        {
            var item = UnitTestResources.ResourceManager.GetResourceByKey(nameof(UnitTestResources.Label_Name), "es");
            item.ShouldBeEqualTo("Name");
        }



        [Test]
        public void Verify_resources_by_key_can_be_retrieved_by_default_language_fallback_scenario()
        {
            var item = UnitTestResources.ResourceManager.GetResourceByKey(nameof(UnitTestResources.Label_EnglishOnly));
            item.ShouldBeEqualTo("EnglishOnly");
        }

        [Test]
        public void Verify_resources_by_key_can_be_retrieved_in_dutch_fallback_scenario()
        {
            var item = UnitTestResources.ResourceManager.GetResourceByKey(nameof(UnitTestResources.Label_EnglishOnly), "nl");
            item.ShouldBeEqualTo("EnglishOnly");
        }

        [Test]
        public void Verify_resources_by_key_can_be_retrieved_in_not_specified_language_fallback_scenario()
        {
            var item = UnitTestResources.ResourceManager.GetResourceByKey(nameof(UnitTestResources.Label_EnglishOnly), "es");
            item.ShouldBeEqualTo("EnglishOnly");
        }
    }
}
