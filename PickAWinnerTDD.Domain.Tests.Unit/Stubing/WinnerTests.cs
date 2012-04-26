using Microsoft.VisualStudio.TestTools.UnitTesting;
using PickAWinnerTDD.Common.DataTransferObjects;
using PickAWinnerTDD.Common.Interfaces.Domain;
using PickAWinnerTDD.UnitTesting.Stubs;

namespace PickAWinnerTDD.Domain.Tests.Unit.Stubing {

    [TestClass]
    public class WinnerTests {

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
            IWinner winner = new Winner();
            bool result = winner.Insert(new WinnerDTO());
            //Assert
            Assert.IsInstanceOfType(result, typeof (bool));
        }

        [TestMethod]
        public void DeleteAll_ShouldReturn_NonNull_Boolean() {
            //Act
            IWinner winner = new Winner();
            bool result = winner.DeleteAll();
            //Assert
            Assert.IsInstanceOfType(result, typeof (bool));
        }

        #endregion
    }
}