using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Pdbc.Shopping.Tests.Helpers.Extensions
{
    /// <summary>
    /// Test extensions
    /// </summary>
    public static class TestExtensions
    {

        /// <summary>
        /// Asserts when the exception was not thrown
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="method">The method.</param>
        /// <returns></returns>
        public static T AssertWasThrown<T>(this Action method) where T : Exception
        {
            return (T)ShouldThrowException(method, typeof(T));
        }

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
            Assert.IsFalse(condition);
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
            Assert.IsTrue(condition);
        }


        /// <summary>
        /// Should Be Equal To
        /// </summary>
        /// <param name="actual">The actual.</param>
        /// <param name="expected">The expected.</param>
        /// <returns></returns>
        public static object ShouldBeEqualTo(this object actual, object expected)
        {
            Assert.AreEqual(expected, actual);
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
            Assert.AreNotEqual(expected, actual);
            return expected;
        }

        /// <summary>
        /// Should be null.
        /// </summary>
        /// <param name="target">An object.</param>
        public static void ShouldBeNull(this object target)
        {
            Assert.IsNull(target);
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
            Assert.IsTrue(isOneOff);
        }

        /// <summary>
        /// Should not be null
        /// </summary>
        /// <param name="target">An object.</param>
        public static void ShouldNotBeNull(this object target)
        {
            Assert.IsNotNull(target);
        }

        /// <summary>
        /// Should be the same as
        /// </summary>
        /// <param name="actual">The actual.</param>
        /// <param name="expected">The expected.</param>
        /// <returns></returns>
        public static object ShouldBeTheSameAs(this object actual, object expected)
        {
            Assert.AreSame(expected, actual);
            return expected;
        }

        /// <summary>
        /// Should not be the same as
        /// </summary>
        /// <param name="actual">The actual.</param>
        /// <param name="expected">The expected.</param>
        /// <returns></returns>
        public static object ShouldNotBeTheSameAs(this object actual, object expected)
        {
            Assert.AreNotSame(expected, actual);
            return expected;
        }

        /// <summary>
        /// Should be of type
        /// </summary>
        /// <param name="actual">The actual.</param>
        /// <param name="expected">The expected.</param>
        public static void ShouldBeOfType(this object actual, Type expected)
        {
            Assert.IsInstanceOf(expected, actual);
        }

        /// <summary>
        /// Should be of type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="actual">The actual.</param>
        public static void ShouldBeOfType<T>(this object actual)
        {
            Assert.IsInstanceOf(typeof(T), actual);
        }

        /// <summary>
        /// Should not be of type
        /// </summary>
        /// <param name="actual">The actual.</param>
        /// <param name="expected">The expected.</param>
        public static void ShouldNotBeOfType(this object actual, Type expected)
        {
            Assert.IsNotInstanceOf(expected, actual);
        }

        /// <summary>
        /// Should not be of type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="actual">The actual.</param>
        public static void ShouldNotBeOfType<T>(this object actual)
        {
            ShouldNotBeOfType(actual, typeof(T));
        }

        /// <summary>
        /// Should contains the expected object
        /// </summary>
        /// <param name="actualList">The actual list.</param>
        /// <param name="expected">The expected.</param>
        public static void ShouldContain(this IList actualList, object expected)
        {
            Assert.Contains(expected, actualList);
        }

        /// <summary>
        /// Should contains the expected object
        /// </summary>
        /// <param name="actual">The actual.</param>
        /// <param name="expected">The expected.</param>
        public static void ShouldContain(this IEnumerable actual, object expected)
        {
            var contains = false;
            foreach (var entry in actual)
            {
                if (entry.Equals(expected))
                    contains = true;

            }
            contains.ShouldBeTrue();
        }

        /// <summary>
        /// Should contains the expected object
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="actual">The actual.</param>
        /// <param name="expected">The expected.</param>
        public static void ShouldContain<T>(this IEnumerable<T> actual, T expected)
        {
            ShouldContain(actual, x => x.Equals(expected));
        }

        /// <summary>
        /// Should contains the expected expression only once
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="actual">The actual.</param>
        /// <param name="expected">The expected.</param>
        public static void ShouldContainOne<T>(this IEnumerable<T> actual, Func<T, bool> expected)
        {
            var x = actual.Single(expected);
            x.ShouldNotBeEqualTo(default(T));
        }

        /// <summary>
        /// Should contains the expected expression
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="actual">The actual.</param>
        /// <param name="expected">The expected.</param>
        public static void ShouldContain<T>(this IEnumerable<T> actual, Func<T, bool> expected)
        {
            var x = actual.FirstOrDefault(expected);
            x.ShouldNotBeEqualTo(default(T));
        }

        /// <summary>
        /// Should contains the expected string
        /// </summary>
        /// <param name="actual">The actual.</param>
        /// <param name="expected">The expected.</param>
        public static void ShouldContain(this string actual, string expected)
        {
            StringAssert.Contains(expected, actual);
        }

        /// <summary>
        /// Should not contains the expected string
        /// </summary>
        /// <param name="value">The value.</param>
        /// <param name="expectedValue">The expected value.</param>
        public static void ShouldNotContain(this string value, string expectedValue)
        {
            Assert.IsFalse(value.Contains(expectedValue));
        }


        /// <summary>
        /// Should be empty.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="actual">The actual.</param>
        public static void ShouldBeEmpty<T>(this IEnumerable<T> actual)
        {
            actual.Count().ShouldBeEqualTo(0);
        }

        /// <summary>
        /// The collection Should be empty.
        /// </summary>
        /// <param name="actual">The collection.</param>
        public static void ShouldBeEmpty(this IEnumerable actual)
        {
            var cnt = 0;
            foreach (var unused in actual)
            {
                cnt++;
            }
            Assert.IsTrue(cnt == 0, "Should be empty");
        }

        /// <summary>
        /// Should have a count.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="actual">The actual.</param>
        /// <param name="expected">The expected.</param>
        public static void ShouldHaveCount<T>(this IEnumerable<T> actual, int expected)
        {
            actual.Count().ShouldBeEqualTo(expected);
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

        /// <summary>
        /// Should be greater than.
        /// </summary>
        /// <param name="arg1">The arg1.</param>
        /// <param name="arg2">The arg2.</param>
        /// <returns></returns>
        public static IComparable ShouldBeGreaterThan(this IComparable arg1, IComparable arg2)
        {
#if MSTEST
            Assert.IsTrue(arg1.CompareTo(arg2) > 0, string.Format("{0} should be greater than {1}", arg1, arg2));
#else
            Assert.Greater(arg1, arg2);
#endif
            return arg2;
        }

        /// <summary>
        /// Should be less than.
        /// </summary>
        /// <param name="arg1">The arg1.</param>
        /// <param name="arg2">The arg2.</param>
        /// <returns></returns>
        public static IComparable ShouldBeLessThan(this IComparable arg1, IComparable arg2)
        {
#if MSTEST
            Assert.IsTrue(arg1.CompareTo(arg2) < 0, string.Format("{0} should be less than {1}", arg1, arg2));
#else
            Assert.Less(arg1, arg2);
#endif
            return arg2;
        }


        /// <summary>
        /// The string Should be empty.
        /// </summary>
        /// <param name="target">A string.</param>
        public static void ShouldBeEmpty(this string target)
        {
#if MSTEST
            Assert.IsTrue(string.IsNullOrEmpty(target), string.Format("The string should be empty"));
#else
            Assert.IsEmpty(target);
#endif
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
            Assert.IsNotEmpty(collection);
#endif
        }

        /// <summary>
        /// Should not be empty.
        /// </summary>
        /// <param name="target">A string.</param>
        public static void ShouldNotBeEmpty(this string target)
        {
#if MSTEST
            Assert.IsTrue(!string.IsNullOrEmpty(target), string.Format("The string should not be empty"));
#else
            Assert.IsNotEmpty(target);
#endif
        }

        /// <summary>
        /// Should Be Equal and Ignoring Case
        /// </summary>
        /// <param name="actual">The actual.</param>
        /// <param name="expected">The expected.</param>
        /// <returns></returns>
        public static string ShouldBeEqualIgnoringCase(this string actual, string expected)
        {
#if MSTEST
            Assert.IsTrue(actual.Equals(expected, StringComparison.OrdinalIgnoreCase), string.Format("The string should be equal ignoring case"));
#else
            StringAssert.AreEqualIgnoringCase(expected, actual);
#endif
            return expected;
        }

        /// <summary>
        /// The string should end with.
        /// </summary>
        /// <param name="actual">The actual.</param>
        /// <param name="expected">The expected.</param>
        public static void ShouldEndWith(this string actual, string expected)
        {
#if MSTEST
            StringAssert.EndsWith(actual,expected );
#else
            StringAssert.EndsWith(expected, actual);
#endif

        }

        /// <summary>
        /// The string should start with.
        /// </summary>
        /// <param name="actual">The actual.</param>
        /// <param name="expected">The expected.</param>
        public static void ShouldStartWith(this string actual, string expected)
        {
#if MSTEST
            StringAssert.StartsWith(actual,expected );
#else
            StringAssert.StartsWith(expected, actual);

#endif
        }

        /// <summary>
        /// The exception should Contain the error message
        /// </summary>
        /// <param name="exception">The exception.</param>
        /// <param name="expected">The expected.</param>
        public static void ShouldContainErrorMessage(this Exception exception, string expected)
        {
#if MSTEST
            StringAssert.Contains(exception.Message, expected);
#else
            StringAssert.Contains(expected, exception.Message);
#endif
        }

        /// <summary>
        /// The action should thrown the specified exception
        /// </summary>
        /// <example>
        /// <![CDATA[
        ///   Action action = () => sut.MethodCall;
        ///   var msg = action.ShouldThrowException<InvalidConfigurationException>();
        ///   msg.ShouldContainErrorMessage("invalid message");
        /// ]]>
        /// </example> 
        /// <typeparam name="T"></typeparam>
        /// <param name="method">The method.</param>
        /// <returns></returns>
        public static T ShouldThrowException<T>(this Action method) where T : Exception
        {
            return (T)ShouldThrowException(method, typeof(T));
        }

        /// <summary>
        /// The action should thrown the specified exception
        /// </summary>
        /// <example>
        /// <![CDATA[
        /// Syntax: Action action = () => sut.MethodCall;
        ///         var msg = action.ShouldThrowException(typeof(InvalidConfigurationException));
        ///         msg.ShouldContainErrorMessage("invalid message");
        /// ]]>
        /// </example> 
        /// <param name="method">The method.</param>
        /// <param name="exceptionType">Type of the exception.</param>
        /// <returns></returns>
        public static Exception ShouldThrowException(this Action method, Type exceptionType)
        {
            Exception exception = null;
            try
            {
                method();
            }
            catch (Exception e)
            {
                Assert.AreEqual(exceptionType, e.GetType());
                exception = e;
            }
            if (exception == null)
            {
                Assert.Fail($"The '{exceptionType.FullName}' exception should be thrown.");
            }
            return exception;
        }

        /// <summary>
        /// Should the be thrown by.
        /// Syntax: typeof(InvalidConfigurationException).ShouldBeThrownBy(() => sut.MethodCall());
        /// </summary>
        /// <param name="exceptionType">Type of the exception.</param>
        /// <param name="method">The method.</param>
        /// <returns></returns>
        public static Exception ShouldBeThrownBy(this Type exceptionType, MethodThatThrows method)
        {
            Exception exception = null;
            try
            {
                method();
            }
            catch (Exception e)
            {
                Assert.AreEqual(exceptionType, e.GetType());
                exception = e;
            }
            if (exception == null)
            {
                Assert.Fail(string.Format("Expected {0} to be thrown.", exceptionType.FullName));
            }
            return exception;
        }

        /// <summary>
        /// Asserts that no exceptions should be thrown.
        /// </summary>
        /// <param name="workToPerform">
        /// The action that could possibly raise an exception.
        /// </param>
        public static void ShouldNotThrowAnyExceptions(this Action workToPerform)
        {
            workToPerform();
        }

        /// <summary>
        /// Asserts that no exceptions should be thrown.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="workToPerform">The function that could possibly raise an exception.</param>
        /// <returns></returns>
        public static T ShouldNotThrowAnyExceptions<T>(this Func<T> workToPerform)
        {
            return workToPerform();
        }

        ///// <summary>
        ///// Should the equal SQL date.
        ///// </summary>
        ///// <param name="actual">The actual.</param>
        ///// <param name="expected">The expected.</param>
        //public static void ShouldEqualSqlDate(this DateTime actual, DateTime expected)
        //{
        //    TimeSpan timeSpan = actual - expected;
        //    Assert.Less(Math.Abs(timeSpan.TotalMilliseconds), 3);
        //}

        ///// <summary>
        ///// The XmlElement should have an attributes that is equal to
        ///// </summary>
        ///// <param name="element">The element.</param>
        ///// <param name="attributeName">Name of the attribute.</param>
        ///// <param name="expected">The expected.</param>
        ///// <returns></returns>
        //public static object AttributeShouldEqual(this XmlElement element, string attributeName, object expected)
        //{
        //    Assert.IsNotNull(element, "The Element is null");

        //    string actual = element.GetAttribute(attributeName);
        //    Assert.AreEqual(expected, actual);
        //    return expected;
        //}

        ///// <summary>
        ///// Should the have child.
        ///// </summary>
        ///// <param name="element">The element.</param>
        ///// <param name="xpath">The xpath.</param>
        ///// <returns></returns>
        //public static XmlElement ShouldHaveChild(this XmlElement element, string xpath)
        //{
        //    var child = element.SelectSingleNode(xpath) as XmlElement;
        //    Assert.IsNotNull(child, "Should have a child element matching " + xpath);

        //    return child;
        //}

        ///// <summary>
        ///// Doeses the not have attribute.
        ///// </summary>
        ///// <param name="element">The element.</param>
        ///// <param name="attributeName">Name of the attribute.</param>
        ///// <returns></returns>
        //public static XmlElement DoesNotHaveAttribute(this XmlElement element, string attributeName)
        //{
        //    Assert.IsNotNull(element, "The Element is null");
        //    Assert.IsFalse(element.HasAttribute(attributeName), "Element should not have an attribute named " + attributeName);

        //    return element;
        //}

        /// <summary>
        /// The bytestream Should be same as.
        /// </summary>
        /// <param name="actual">The actual.</param>
        /// <param name="expected">The expected.</param>
        public static void ShouldBeSameAs(this byte[] actual, byte[] expected)
        {
            try
            {
                Assert.AreEqual(expected.Length, actual.Length, "Byte arrays have different lengths.");
                for (var i = 0; i < expected.Length; i++)
                {
                    Assert.AreEqual(expected[i], actual[i], "Byte value differs at position {0}.", i + 1);
                }
            }
            catch
            {
                DebugWrite(expected, "Expected");
                DebugWrite(actual, "Actual");
                DebugWriteIndexes(Math.Max(expected.Length, actual.Length));
                throw;
            }
        }

        /// <summary>
        /// The stream Should be same as.
        /// </summary>
        /// <param name="actual">The actual.</param>
        /// <param name="expected">The expected.</param>
        public static void ShouldBeSameAs(this Stream actual, Stream expected)
        {
            expected.Position = 0;
            actual.Position = 0;

            try
            {
                Assert.AreEqual(expected.Length, actual.Length, "Streams have different lengths.");
            }
            catch
            {
                DebugWrite(expected, "Expected");
                DebugWrite(actual, "Actual");
                DebugWriteIndexes(Math.Max((int)expected.Length, (int)actual.Length));
                throw;
            }

            var actualBuffer = new byte[actual.Length];
            var expectedBuffer = new byte[expected.Length];

            expected.Read(expectedBuffer, 0, (int)expected.Length);
            actual.Read(actualBuffer, 0, (int)actual.Length);

            actualBuffer.ShouldBeSameAs(expectedBuffer);
        }

        /// <summary>
        /// The stream Should be same as.
        /// </summary>
        /// <param name="actual">The actual.</param>
        /// <param name="expected">The expected.</param>
        /// <param name="resetPosition">if set to <c>true</c> [reset position].</param>
        public static void ShouldBeSameAs(this Stream actual, byte[] expected, bool resetPosition = false)
        {
            try
            {
                if (resetPosition) actual.Position = 0;

                for (var i = 0; i < expected.Length; i++)
                {
                    Assert.AreEqual(expected[i], actual.ReadByte(), "Byte value differs at position {0}.", i + 1);
                }
            }
            catch
            {
                DebugWrite(expected, "Expected");
                DebugWrite(actual, "Actual");
                DebugWriteIndexes(Math.Max(expected.Length, (int)actual.Length));
                throw;
            }
        }

        /// <summary>
        /// Debug write the stream
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <param name="category">The category.</param>
        private static void DebugWrite(Stream stream, string category)
        {
            Debug.Write(string.Format("{0,-10}: ", category));
            var currentPosition = stream.Position;
            stream.Position = 0;

            var b = stream.ReadByte();
            while (b >= 0)
            {
                Debug.Write(string.Format("0x{0:X2} ", b));
                b = stream.ReadByte();
            }

            stream.Position = currentPosition;
            Debug.WriteLine(string.Empty);
        }

        /// <summary>
        /// Debug write the byte array
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        /// <param name="category">The category.</param>
        private static void DebugWrite(byte[] bytes, string category)
        {
            Debug.Write(string.Format("{0,-10}: ", category));
            for (var i = 0; i < bytes.Length; i++)
            {
                Debug.Write(string.Format("0x{0:X2} ", bytes[i]));
            }
            Debug.WriteLine(string.Empty);
        }

        /// <summary>
        /// Debugs the write indexes.
        /// </summary>
        /// <param name="count">The count.</param>
        private static void DebugWriteIndexes(int count)
        {
            Debug.Write(string.Empty.PadRight(12));
            for (var i = 1; i <= count; i++)
            {
                Debug.Write(string.Format("{0,-4} ", i));
            }
            Debug.WriteLine(string.Empty);
        }

    }

    /// <summary>
    /// MethodThatThrows delegate
    /// </summary>
    public delegate void MethodThatThrows();

    /// <summary>
    /// Static gateway for building actions fluently
    /// </summary>
    public static class The
    {
        /// <summary>
        /// Returns the theAction
        /// </summary>
        /// <example>
        /// <![CDATA[
        /// The.Action(x => x.DoWork()).ShouldThrownException<TheException>();
        /// ]]>
        /// </example>
        /// <param name="theAction">The action.</param>
        /// <returns></returns>
        public static Action Action(Action theAction)
        {
            return theAction;
        }
    }
}
