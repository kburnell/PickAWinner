namespace PickAWinnerTDD.Common.Interfaces.DependencyResolver{

    /// <summary>
    /// Interface for implementations of Dependency Resolver
    /// <remarks>
    /// This interface adds a layer of abstraction when we
    /// resolve dependencies.  It will allow us to swap out
    /// out IoC framework with minimal impact on our code.
    /// </remarks>
    /// </summary>
    public interface IDependencyResolver
    {

        /// <summary>
        /// Returns a concrete instance of the
        /// supplied Interface
        /// </summary>
        /// <typeparam name="T">Interface of concrete instance to return</typeparam>
        /// <returns>Concrete instance of the supplied interface</returns>
        T GetConcreteInstanceOf<T>();
    }
}