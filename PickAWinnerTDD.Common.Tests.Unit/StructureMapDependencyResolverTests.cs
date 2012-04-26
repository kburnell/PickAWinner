using Microsoft.VisualStudio.TestTools.UnitTesting;
using PickAWinnerTDD.Common.Interfaces.DependencyResolver;
using PickAWinnerTDD.Common.Interfaces.Repository;
using PickAWinnerTDD.UnitTesting.Stubs;
using PickAWinnerTDD.UnitTesting.Stubs.DataAccess;

namespace PickAWinnerTDD.Common.Tests.Unit {

    [TestClass]
    public class StructureMapDependencyResolverTests {

        [TestInitialize]
        public void TestInitialize() {
            StructureMapBootstrapperStub.BootstrapStructureMap();
        }

        [TestMethod]
        public void GetConcreteInstanceOf_ShouldReturn_AttendeeRepositoryStub_WhenPassed_IAttendeeRepository() {
            //Arrange
            IDependencyResolver dependencyResolver = new StructureMapDependencyResolver();
            //Act
            var myRepo = dependencyResolver.GetConcreteInstanceOf<IAttendeeRepository>();
            //Assert
            Assert.IsInstanceOfType(myRepo, typeof(AttendeeRepositoryStub));
        }
    }
}