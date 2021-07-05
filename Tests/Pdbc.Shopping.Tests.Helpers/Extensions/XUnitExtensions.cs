using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Pdbc.Shopping.Tests.Helpers.Extensions
{
    /// <summary>
    /// Test extensions
    /// </summary>
    public static class XUnitTestExtensions
    {

        /// <summary>
        /// Should the be false.
        /// </summary>
        /// <param name="condition">if set to <c>true</c> [condition].</param>
        public static void ShouldBeFalse(this bool condition)
        {
            ShouldBeFalse(condition, string.Empty);
        }

        /// <summary>
        /// Should be false
        /// </summary>
        /// <param name="condition">if set to <c>true</c> [condition].</param>
        /// <param name="reason">The reason.</param>
        /// <param name="reasonParameters">The reason parameters.</param>
        public static void ShouldBeFalse(this bool condition, string reason, params object[] reasonParameters)
        {
            //Execute.Verify(!condition, "Expected {0}{2}, but found {1}.", false, condition, reason, reasonParameters);
            Assert.False(condition);
        }

        /// <summary>
        /// Should the be true.
        /// </summary>
        /// <param name="condition">if set to <c>true</c> [condition].</param>
        public static void ShouldBeTrue(this bool condition)
        {
            ShouldBeTrue(condition, string.Empty);
        }

        /// <summary>
        /// Should be true.
        /// </summary>
        /// <param name="condition">if set to <c>true</c> [condition].</param>
        /// <param name="reason">The reason.</param>
        /// <param name="reasonParameters">The reason parameters.</param>
        public static void ShouldBeTrue(this bool condition, string reason, params object[] reasonParameters)
        {
            //Execute.Verify(condition, "Expected {0}{2}, but found {1}.", true, condition, reason, reasonParameters);
            Assert.True(condition);
        }


        /// <summary>
        /// Should Be Equal To
        /// </summary>
        /// <param name="actual">The actual.</param>
        /// <param name="expected">The expected.</param>
        /// <returns></returns>
        public static object ShouldBeEqualTo(this object actual, object expected)
        {
            Assert.Equal(expected, actual);
            return expected;
        }

        /// <summary>
        /// Should Be Not Equal To
        /// </summary>
        /// <param name="actual">The actual.</param>
        /// <param name="expected">The expected.</param>
        /// <returns></returns>
        public static object ShouldNotBeEqualTo(this object actual, object expected)
        {
            Assert.NotEqual(expected, actual);
            return expected;
        }

        /// <summary>
        /// Should be null.
        /// </summary>
        /// <param name="target">An object.</param>
        public static void ShouldBeNull(this object target)
        {
            Assert.Null(target);
        }

        /// <summary>
        /// Should be one of.
        /// </summary>
        /// <param name="actual">The actual.</param>
        /// <param name="listOf">The list of.</param>
        public static void ShouldBeOneOf(this object actual, params object[] listOf)
        {
            var isOneOff = false;
            foreach (var o in listOf)
            {
                if (actual.Equals(o))
                    isOneOff = true;
            }
            Assert.True(isOneOff);
        }

        /// <summary>
        /// Should not be null
        /// </summary>
        /// <param name="target">An object.</param>
        public static void ShouldNotBeNull(this object target)
        {
            Assert.NotNull(target);
        }

        /// <summary>
        /// Should be the same as
        /// </summary>
        /// <param name="actual">The actual.</param>
        /// <param name="expected">The expected.</param>
        /// <returns></returns>
        public static object ShouldBeTheSameAs(this object actual, object expected)
        {
            Assert.Same(expected, actual);
            return expected;
        }

        /// <summary>
        /// Should not be empty.
        /// </summary>
        /// <param name="collection">The collection.</param>
        public static void ShouldNotBeEmpty(this ICollection collection)
        {
#if MSTEST
            Assert.IsTrue(collection.Count > 0, string.Format("The collection should not be empty"));
#else
            Assert.NotEmpty(collection);
#endif
        }



        /// <summary>
        /// Should be greater than.
        /// </summary>
        /// <param name="arg1">The arg1.</param>
        /// <param name="arg2">The arg2.</param>
        /// <returns></returns>
        public static IComparable ShouldBeGreaterThan(this IComparable arg1, IComparable arg2)
        {
            Assert.True(arg1.CompareTo(arg2) > 0, string.Format("{0} should be greater than {1}", arg1, arg2));
            return arg2;
        }


        /// <summary>
        /// Should have a count.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="actual">The actual.</param>
        /// <param name="predicate">The predicate.</param>
        /// <param name="message">The message.</param>
        public static void ShouldHaveCount<T>(this IEnumerable<T> actual, Predicate<int> predicate, string message)
        {
            predicate(actual.Count()).ShouldBeTrue(message);
        }
    }
}
