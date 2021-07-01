using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Pdbc.Shopping.Common.Validation;
using Pdbc.Shopping.Core.CQRS.Resources.ErrorMessages.Get;
using Pdbc.Shopping.Core.Validation.Extensions;
using Pdbc.Shopping.I18N;
using Pdbc.Shopping.Tests.Helpers;
using Pdbc.Shopping.Tests.Helpers.Core.CQRS.Resources.ErrorMessages;
using Pdbc.Shopping.Tests.Helpers.Core.Validation;

namespace Pdbc.Shopping.UnitTests.Core.CQRS.Resources.ErrorMessages.Get
{
    public class GetErrorMessageQueryValidatorTestFixture : ContextSpecification<GetErrorMessageQueryValidator>
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
            var query = new GetErrorMessageQueryTestDataBuilder().WithLanguage(null);
            SUT.Validate(query, _validationBag).GetAwaiter().GetResult();
            _validationBag.ExpectErrorWithCode(nameof(ErrorResources.LanguageIsEmpty));
        }

        [Test]
        public void Verify_error_when_language_is_empty_string()
        {
            var query = new GetErrorMessageQueryTestDataBuilder().WithLanguage("");
            SUT.Validate(query, _validationBag).GetAwaiter().GetResult();
            _validationBag.ExpectErrorWithCode(nameof(ErrorResources.LanguageIsEmpty));
        }

        [Test]
        public void Verify_error_when_language_is_spaces_string()
        {
            var query = new GetErrorMessageQueryTestDataBuilder().WithLanguage("   ");
            SUT.Validate(query, _validationBag).GetAwaiter().GetResult();
            _validationBag.ExpectErrorWithCode(nameof(ErrorResources.LanguageIsEmpty));
        }

        [Test]
        public void Verify_error_when_resource_key_is_null()
        {
            var query = new GetErrorMessageQueryTestDataBuilder().WithKey(null);
            SUT.Validate(query, _validationBag).GetAwaiter().GetResult();
            _validationBag.ExpectErrorWithCode(nameof(ErrorResources.ResourceKeyIsEmpty));
        }

        [Test]
        public void Verify_error_when_resource_key_is_empty_string()
        {
            var query = new GetErrorMessageQueryTestDataBuilder().WithKey("");
            SUT.Validate(query, _validationBag).GetAwaiter().GetResult();
            _validationBag.ExpectErrorWithCode(nameof(ErrorResources.ResourceKeyIsEmpty));
        }

        [Test]
        public void Verify_error_when_resource_key_is_spaces_string()
        {
            var query = new GetErrorMessageQueryTestDataBuilder().WithKey("   ");
            SUT.Validate(query, _validationBag).GetAwaiter().GetResult();
            _validationBag.ExpectErrorWithCode(nameof(ErrorResources.ResourceKeyIsEmpty));
        }
    }
}
