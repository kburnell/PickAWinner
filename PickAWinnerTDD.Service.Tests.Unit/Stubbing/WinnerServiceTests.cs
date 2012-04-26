using Microsoft.VisualStudio.TestTools.UnitTesting;
using PickAWinnerTDD.Common.DataTransferObjects;
using PickAWinnerTDD.Common.Interfaces.Service;
using PickAWinnerTDD.UnitTesting.Stubs;

namespace PickAWinnerTDD.Service.Tests.Unit.Stubbing {
    [TestClass]
    public class WinnerServiceTests {

        #region << Setup/Teardown >>

        [TestInitialize]
        public void TestInitialize() {
            StructureMapBootstrapperStub.BootstrapStructureMap();
        }

        #endregion

        #region << Tests >>

        [TestMethod]
        public void Insert_ShouldReturn_NonNull_Boolean() {
            //Act
            IWinnerService service = new WinnerService();
            bool result = service.Insert(new WinnerDTO());
            //Assert
            Assert.IsInstanceOfType(result, typeof (bool));
        }

        [TestMethod]
        public void DeleteAll_ShouldReturn_NonNull_Boolean() {
            //Act
            IWinnerService service = new WinnerService();
            bool result = service.DeleteAll();
            //Assert
            Assert.IsInstanceOfType(result, typeof (bool));
        }

        #endregion
    }
}