using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;

namespace Pdbc.Shopping.Tests.Helpers.Extensions
{
    public static class FluentValidatorExtension
    {
        public static void ExpectNoValidationError<T>(this IValidator<T> sut, T instance)
        {
            var validationResult = sut.Validate(instance);
            validationResult.Errors.ShouldBeEmpty();
        }

        public static void ExpectValidationError<T>(this IValidator<T> sut, T instance, String expectedErrorCode, int expectedNumberOfErrors = 1)
        {
            var validationResult = sut.Validate(instance);
            validationResult.ExpectAnError()
                .ExpectNumberOfErrors(expectedNumberOfErrors)
                .ExpectErrorWithCode(expectedErrorCode);
        }
        public static void ExpectValidationErrorForString<T>(this IValidator<T> sut, T instance,
            Action<T, String> setStringValueAction,
            String expectedErrorCode,
            int expectedNumberOfErrors = 1)
        {
            setStringValueAction(instance, null);
            sut.ExpectValidationError(instance, expectedErrorCode, expectedNumberOfErrors);

            setStringValueAction(instance, "");
            sut.ExpectValidationError(instance, expectedErrorCode, expectedNumberOfErrors);

            setStringValueAction(instance, "  ");
            sut.ExpectValidationError(instance, expectedErrorCode, expectedNumberOfErrors);
        }


        public static ValidationResult ExpectAnError(this ValidationResult validationResult)
        {
            validationResult.Errors.Count.ShouldBeGreaterThan(0);
            return validationResult;
        }

        public static ValidationResult ExpectNumberOfErrors(this ValidationResult entity, int count)
        {
            entity.Errors.Count.ShouldBeEqualTo(count);
            return entity;
        }
        public static ValidationResult ExpectErrorWithCode(this ValidationResult entity, String code)
        {
            entity.Errors.FirstOrDefault(x => x.ErrorCode == code).ShouldNotBeNull();
            return entity;
        }

        public static ValidationResult ExpectNoErrorWithCode(this ValidationResult entity, String code)
        {
            entity.Errors.FirstOrDefault(x => x.ErrorCode == code).ShouldBeNull();
            return entity;
        }

    }
}
