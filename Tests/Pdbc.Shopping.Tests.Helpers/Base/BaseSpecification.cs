using NUnit.Framework;

namespace Pdbc.Shopping.Tests.Helpers
{
    ///<summary>
    /// Base class for simple test fixtures
    ///</summary>
    public abstract class BaseSpecification
    {

        /// <summary>
        /// TestFixtureSetup
        /// </summary>
        [OneTimeSetUp]
        public void TestFixtureSetup()
        {
            Establish_context_before_all_specifications();
        }

        /// <summary>
        /// TestFixtureTeardown
        /// </summary>
        [OneTimeTearDown]
        public void TestFixtureTeardown()
        {
            Dispose_context_after_all_specifications();
        }


        /// <summary>
        /// The main setup
        /// </summary>
        [SetUp]
        public virtual void BaseSetup()
        {
            Establish_context();
            Initialize_subject_under_test();
            Because();
        }

        /// <summary>
        /// The main teardown
        /// </summary>
        [TearDown]
        public virtual void BaseTeardown()
        {
            Dispose_context();
        }


        /// <summary>
        /// Establish the contexts where every test is running in
        /// </summary>
        protected virtual void Establish_context() { }

        /// <summary>
        /// Establish the contexts where all test are running in
        /// </summary>
        protected virtual void Establish_context_before_all_specifications() { }


        /// <summary>
        /// Initialize the SUT
        /// </summary>
        protected virtual void Initialize_subject_under_test() { }

        /// <summary>
        /// Perform here the action on the sut to be tested
        /// </summary>
        protected virtual void Because() { }

        /// <summary>
        /// Dispose the local context of the test.
        /// </summary>
        protected virtual void Dispose_context() { }


        /// <summary>
        /// Dispose the global contexts of all test.
        /// </summary>
        protected virtual void Dispose_context_after_all_specifications() { }

    }

    /// <summary>
    /// Base class for test fixtures on a Subject Under Test (SUT)
    /// </summary>
    public abstract class BaseSpecification<TSubject> : BaseSpecification where TSubject : class
    {
        /// <summary>
        /// The main setup
        /// </summary>
        [SetUp]
        public override void BaseSetup()
        {
            Establish_context();
            SUT = Create_subject_under_test();
            Because();
        }

        /// <summary>
        /// Create subject under tests
        /// </summary>
        /// <returns></returns>
        protected abstract TSubject Create_subject_under_test();

        /// <summary>
        /// Gets the SUT.
        /// </summary>
        /// <value>The SUT.</value>
        protected TSubject SUT { get; set; }
    }
}