using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using Moq;
using Moq.Language.Flow;

namespace Pdbc.Shopping.Tests.Helpers.Extensions
{
    public static class MoqExtensions
    {
        //public static void Verify<TItem>(this TItem item, Expression<Action<TItem>> exp) where TItem : class
        //{
        //    //Mock<IRootProcessor> mock = Mock.Get(_rootProcessor);
        //    var mock = Mock.Get(item);
        //    mock.Verify(exp);
        //}

        //public static void Verify<TItem>(this TItem item, Expression<Action<TItem>> exp, Times times) where TItem : class
        //{
        //    //Mock<IRootProcessor> mock = Mock.Get(_rootProcessor);
        //    var mock = Mock.Get(item);
        //    mock.Verify(exp, times);
        //}

        public static void AssertWasCalled<TItem>(this TItem item, Expression<Action<TItem>> exp) where TItem : class
        {
            //Mock<IRootProcessor> mock = Mock.Get(_rootProcessor);
            var mock = Mock.Get(item);
            mock.Verify(exp, Times.AtLeastOnce); //TODO Test with Once and make sure multiple calls are specified !!
        }

        public static void AssertWasNotCalled<TItem>(this TItem item, Expression<Action<TItem>> exp) where TItem : class
        {
            //Mock<IRootProcessor> mock = Mock.Get(_rootProcessor);
            var mock = Mock.Get(item);
            mock.Verify(exp, Times.Never);
        }
        public static void AssertWasCalled<TItem>(this TItem item, Expression<Action<TItem>> exp, Times times) where TItem : class
        {
            //Mock<IRootProcessor> mock = Mock.Get(_rootProcessor);
            var mock = Mock.Get(item);
            mock.Verify(exp, times);
        }
        //, Times.Exactly(2)
        //public static ISetup<TItem> Setup<TItem>(this TItem item, Expression<Action<TItem>> exp) where TItem : class
        //{
        //    Mock<TItem> mock = Mock.Get(item);
        //    return mock.Setup(exp);
        //}

        //public static ISetup<TItem, TResult> Setup<TItem, TResult>(this TItem item, Expression<Func<TItem, TResult>> exp) where TItem : class
        //{
        //    //Mock<IRootProcessor> mock = Mock.Get(_rootProcessor);
        //    Mock<TItem> mock = Mock.Get(item);
        //    return mock.Setup(exp);
        //}

        //, Times.Exactly(2)



        // TODO Rename to Setup
        public static ISetup<TItem> Stub<TItem>(this TItem item, Expression<Action<TItem>> exp) where TItem : class
        {
            Mock<TItem> mock = Mock.Get(item);
            return mock.Setup(exp);
        }

        // TODO Rename to Setup
        public static ISetup<TItem, TResult> Stub<TItem, TResult>(this TItem item, Expression<Func<TItem, TResult>> exp) where TItem : class
        {
            //Mock<IRootProcessor> mock = Mock.Get(_rootProcessor);
            Mock<TItem> mock = Mock.Get(item);
            return mock.Setup(exp);
        }

        // TODO Rename to Returns
        public static IReturnsResult<TItem> Return<TItem, TResult>(this ISetup<TItem, TResult> setup, TResult result) where TItem : class
        {
            return setup.Returns(result);
        }

        public static void VerifyAllExpectations<TItem>(this TItem item) where TItem : class
        {
            Mock<TItem> mock = Mock.Get(item);
            mock.VerifyAll();
        }
        /*
        public static ISetup<TItem, TResult> Setup<TResult>(this TItem item, Expression<Func<TItem, TResult>> exp) where TItem : class
        {
            //Mock<IRootProcessor> mock = Mock.Get(_rootProcessor);
            Mock<TItem> mock = Mock.Get(item);
            ISetup<TItem> result = mock.Setup(exp);

            return result;
        }


        public ISetup<T, TResult> Setup<TResult>(this T item, Expression<Func<T, TResult>> expression)
        {
            var setup = Mock.Setup(this, expression, null);
            return new NonVoidSetupPhrase<T, TResult>(setup);
        }
        */
    }

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
