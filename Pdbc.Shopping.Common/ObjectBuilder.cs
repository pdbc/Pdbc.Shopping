namespace Pdbc.Shopping.Common
{
    /// <summary>
    /// Interface for an object builder
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IObjectBuilder<out T> where T : class
    {
        /// <summary>
        /// Builds an object of type T
        /// </summary>
        /// <returns></returns>
        T Build();
    }

    /// <summary>
    /// Base implementation for an object builder
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class ObjectBuilder<T> : IObjectBuilder<T> where T : class
    {
        /// <summary>
        /// Performs an implicit conversion from <see cref="ObjectBuilder{T}"/> to the Typed object
        /// </summary>
        /// <param name="builder">The test data builder.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator T(ObjectBuilder<T> builder)
        {
            return builder?.Build();
        }

        /// <summary>
        /// Builds this instance.
        /// </summary>
        /// <returns></returns>
        public abstract T Build();
    }
}

