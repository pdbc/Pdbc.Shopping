using NUnit.Framework;
using Pdbc.Shopping.Common.Validation;
using Pdbc.Shopping.Core.CQRS.Resources.Errors.List;
using Pdbc.Shopping.I18N;
using Pdbc.Shopping.Tests.Helpers;
using Pdbc.Shopping.Tests.Helpers.Core.CQRS.Resources.ErrorMessages;
using Pdbc.Shopping.Tests.Helpers.Core.Validation;

namespace Pdbc.Shopping.UnitTests.Core.CQRS.Resources.ErrorMessages.List
{
    public class ListErrorMessagesQueryValidatorTestFixture : ContextSpecification<ListErrorMessageQueryValidator>
    {
        private ValidationBag _validationBag;

        protected override void Establish_context()
        {
            base.Establish_context();

           _validationBag = new ValidationBag();
        }

        [Test]
        public void Verify_error_when_language_is_null()
        {
            var query = new ListErrorMessagesQueryTestDataBuilder().WithLanguage(null);
            SUT.Validate(query, _validationBag).GetAwaiter().GetResult();
            _validationBag.ExpectErrorWithCode(nameof(ErrorResources.LanguageIsEmpty));
        }

        [Test]
        public void Verify_error_when_language_is_empty_string()
        {
            var query = new ListErrorMessagesQueryTestDataBuilder().WithLanguage("");
            SUT.Validate(query, _validationBag).GetAwaiter().GetResult();
            _validationBag.ExpectErrorWithCode(nameof(ErrorResources.LanguageIsEmpty));
        }

        [Test]
        public void Verify_error_when_language_is_spaces_string()
        {
            var query = new ListErrorMessagesQueryTestDataBuilder().WithLanguage("   ");
            SUT.Validate(query, _validationBag).GetAwaiter().GetResult();
            _validationBag.ExpectErrorWithCode(nameof(ErrorResources.LanguageIsEmpty));
        }

    }
}
