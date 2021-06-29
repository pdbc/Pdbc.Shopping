using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using Moq;
using Moq.AutoMock;
using NUnit.Framework;

namespace Pdbc.Shopping.Tests.Helpers
{
    /// <summary>
    /// Base class for AAA test fixture. 
    /// This test fixture provide auto mocking by default.
    /// When you want to create you own SUT override 'Create_subject_under_test'
    /// </summary>
    /// <remarks>
    /// More information about this class see:
    /// http://blog.jpboodhoo.com/BDDAAAStyleTestingAndRhinoMocks.aspx
    /// http://blog.jpboodhoo.com/CategoryView,category,Programming.aspx
    /// </remarks>
    /// <typeparam name="TSubject">The type of the sut.</typeparam>
    public abstract class ContextSpecification<TSubject> : BaseSpecification<TSubject> where TSubject : class
    {
        private AutoMocker _autoMocker;
        private const string MockeryNotInitialized = "Mockery is not initialized, did you forgot to call 'base.BaseSetup()' ";
        private Dictionary<string, object> _registeredPropertyDependencies;

        /// <summary>
        /// Gives access to the generated mock wrapper for the subject under test.
        /// </summary>
        /// <remarks>You can use this mock wrapper to configure the behavior or set expectations that need to be verified.</remarks>
        public Mock<TSubject> SUTWrapper { get; private set; }

        /// <summary>
        /// The main setup
        /// </summary>
        [SetUp]
        public override void BaseSetup()
        {
            _autoMocker = new AutoMocker();

            Establish_context();
            SUT = Create_subject_under_test();
            Because();
        }

        /// <summary>
        /// Dispose the local context of the test.
        /// </summary>        
        protected override void Dispose_context()
        {
            _autoMocker = null;
            _registeredPropertyDependencies = null;
            base.Dispose_context();
        }

        /// <summary>
        /// Create subject under tests
        /// </summary>
        /// <returns></returns>
        /// <exception cref="T:System.InvalidOperationException"> when BaseSetup is not called before this method is called.</exception>
        protected override TSubject Create_subject_under_test()
        {
            if (_autoMocker == null)
                throw new InvalidOperationException(MockeryNotInitialized);

            SUTWrapper = _autoMocker.GetMock<TSubject>();
            SUTWrapper.CallBase = true;
            var sut = SUTWrapper.Object;

            if (_registeredPropertyDependencies != null)
            {
                var classUnderTestType = sut.GetType();
                foreach (var propertyDependency in _registeredPropertyDependencies)
                {
                    var dependencyPropertySetMethod = classUnderTestType.GetProperty(propertyDependency.Key)?.GetSetMethod();
                    dependencyPropertySetMethod?.Invoke(sut, new[] { propertyDependency.Value });
                }
            }
            return sut;
        }

        /// <summary>
        /// Registers the property dependency.
        /// </summary>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="expression">The expression.</param>
        public void RegisterPropertyDependency<TProperty>(Expression<Func<TSubject, TProperty>> expression)
        {
            if (_registeredPropertyDependencies == null)
                _registeredPropertyDependencies = new Dictionary<string, object>();

            if (!(expression.Body is MemberExpression body)) return;

            // Work out the type from our expression tree.
            var propertyInfo = (PropertyInfo)body.Member;
            var propertyType = propertyInfo.PropertyType;

            // We know the property type now so
            // we can create a Stub of it using Mocks.
            var stub = _autoMocker.GetMock(propertyType);

            _registeredPropertyDependencies.Add(propertyInfo.Name, stub.Object);
        }

        /// <summary>
        /// Get a dependency (mock) on the SUT of the specified type
        /// </summary>
        /// <remarks>
        /// A mock is an object that we can set expectations on, and which will verify that the expected actions have indeed occurred.
        /// If you want to verify the behavior of the code under test, you will use a mock with the appropriate expectation, and verify that.
        /// </remarks>
        /// <typeparam name="TMock">The type of the mock.</typeparam>
        /// <param name="action"> An optional action to call to configure (expectancies on) the sub.</param>
        /// <returns>The created instance</returns>
        /// <exception cref="InvalidOperationException"> when BaseSetup is not called before this method is called.</exception>
        /// <exception cref="Exception">When the passed action throws an exception.</exception>
        public TMock Dependency<TMock>(Action<Mock<TMock>> action = null) where TMock : class
        {
            if (_autoMocker == null) throw new InvalidOperationException(MockeryNotInitialized);
            var mockWrapper = _autoMocker.GetMock<TMock>();
            action?.Invoke(mockWrapper);
            return mockWrapper.Object;
        }

        /// <summary>
        /// Get a mock wrapper for a dependency on the SUT of the specified type that you can use to setup and set expectancies.
        /// </summary>
        /// <remarks>
        /// The mock wrapper is an object that you can set expectations on, and which will verify that the expected actions have indeed occurred.
        /// If you want to verify the behavior of the code under test, you need to configure the wrapper with the appropriate expectations, and verify them.
        /// </remarks>
        /// <typeparam name="TMock">The type of the mock to create.</typeparam>
        /// <returns>A <see cref="Mock{TMock}"/> wrapper for the created instance</returns>
        /// <exception cref="InvalidOperationException"> when BaseSetup is not called before this method is called.</exception>
        public Mock<TMock> DependencyWrapper<TMock>() where TMock : class
        {
            if (_autoMocker == null) throw new InvalidOperationException(MockeryNotInitialized);
            var mockWrapper = _autoMocker.GetMock<TMock>();
            return mockWrapper;
        }


        /// <summary>
        /// Get a stub of the specified type, optionally specifying an action to configure the stub.
        /// </summary>
        /// <remarks>
        /// If you want just to pass a value that may need to act in a certain way, but isn't the focus of this test, you will use a stub. A stub's properties will automatically behave like normal properties, and you can't set expectations on them.
        /// IMPORTANT: A stub will never cause a test to fail. 
        /// </remarks>
        /// <typeparam name="TStub">The type of the stub.</typeparam>
        /// <param name="action"> An optional action to call to configure (expectancies on) the sub.</param>
        /// <returns>The created instance</returns>
        /// <exception cref="System.NotImplementedException">When this method is called.</exception>
        [Obsolete("Moq has no separate method to create stubs. Use the Dependency<TMock> method instead.  If you don't configure expectations in the action, the returned object is automatically a stub.", true)]
        public TStub DependencyAsStub<TStub>(Action<Mock<TStub>> action = null) where TStub : class
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Create a dependency for the SUT and register it in the container
        /// </summary>
        /// <typeparam name="TMock">The type of the mock.</typeparam>
        /// <returns>The created instance</returns>
        /// <exception cref="System.InvalidOperationException"> when BaseSetup is not called before this method is called.</exception>
        public TMock DependencyAsPartial<TMock>(params object[] parameters) where TMock : class
        {
            if (_autoMocker == null) throw new InvalidOperationException(MockeryNotInitialized);
            var mockWrapper = new Mock<TMock>(parameters) { CallBase = true };
            _autoMocker.Use(mockWrapper.Object);

            return mockWrapper.Object;
        }

        /// <summary>
        /// Create a dependency for the SUT and register it in the container
        /// </summary>
        /// <typeparam name="TMock">The type of the mock.</typeparam>
        /// <param name="action"> An action to call to configure (expectancies on) the sub.</param>
        /// <param name="parameters">The parameters to pass to the constructor</param>
        /// <returns>The created instance</returns>
        /// <exception cref="InvalidOperationException"> when BaseSetup is not called before this method is called.</exception>
        /// <exception cref="Exception">When the passed action throws an exception.</exception>
        public TMock DependencyAsPartial<TMock>(Action<Mock<TMock>> action, params object[] parameters) where TMock : class
        {
            if (_autoMocker == null) throw new InvalidOperationException(MockeryNotInitialized);
            var mockWrapper = new Mock<TMock>(parameters) { CallBase = true };
            action?.Invoke(mockWrapper);
            _autoMocker.Use(mockWrapper.Object);
            return mockWrapper.Object;
        }

        /// <summary>
        /// Create a mock wrapper for a dependency for the SUT and register it in the container
        /// </summary>
        /// <typeparam name="TMock">The type of the mock.</typeparam>
        /// <param name="parameters">The parameters to pass to the constructor</param>
        /// <returns>A <see cref="Mock{TMock}"/> wrapper for the created instance</returns>
        /// <exception cref="InvalidOperationException"> when BaseSetup is not called before this method is called.</exception>
        /// <remarks>
        /// The mock wrapper is an object that you can set expectations on, and which will verify that the expected actions have indeed occurred.
        /// If you want to verify the behavior of the code under test, you need to configure the wrapper with the appropriate expectations, and verify them.
        /// </remarks>
        public Mock<TMock> DependencyWrapperAsPartial<TMock>(params object[] parameters) where TMock : class
        {
            if (_autoMocker == null) throw new InvalidOperationException(MockeryNotInitialized);
            var mockWrapper = new Mock<TMock>(parameters) { CallBase = true };
            _autoMocker.Use(mockWrapper.Object);
            return mockWrapper;
        }

        /// <summary>
        /// Captures <paramref name="instance"/> as the object to provide <typeparamref name="TService"/> for mocking.
        /// </summary>
        /// <typeparam name="TService">The type of the service.</typeparam>
        /// <param name="instance">The instance.</param>
        /// <exception cref="T:System.InvalidOperationException"> when BaseSetup is not called before this method is called.</exception>
        public void Register<TService>(TService instance)
        {
            if (_autoMocker == null) throw new InvalidOperationException(MockeryNotInitialized);
            _autoMocker.Use(instance);
        }

        /// <summary>
        /// Captures <paramref name="instance"/> as the object to provide the type for mocking.
        /// </summary>
        /// <param name="serviceType">The type.</param>
        /// <param name="instance">The instance.</param>
        /// <exception cref="T:System.InvalidOperationException"> when BaseSetup is not called before this method is called.</exception>
        public void Register(Type serviceType, object instance)
        {
            if (_autoMocker == null) throw new InvalidOperationException(MockeryNotInitialized);
            _autoMocker.Use(serviceType, instance);
        }

    }
}