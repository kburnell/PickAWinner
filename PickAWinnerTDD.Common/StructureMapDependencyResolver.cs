using PickAWinnerTDD.Common.Interfaces.DependencyResolver;
using StructureMap;

namespace PickAWinnerTDD.Common {

    /// <summary>
    /// Class for resolving dependency's using StructureMap
    /// </summary>
    public class StructureMapDependencyResolver : IDependencyResolver {

        #region IDependencyResolver Members

        /// <summary>
        /// Returns a concrete instance of the
        /// supplied Interface
        /// </summary>
        /// <typeparam name="T">Interface of concrete instance to return</typeparam>
        /// <returns>Concrete instance of the supplied interface</returns>
        public T GetConcreteInstanceOf<T>() {
            return ObjectFactory.GetInstance<T>();
        }

        #endregion
    }
}