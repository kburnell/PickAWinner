using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PickAWinnerTDD.Common.DataTransferObjects;
using PickAWinnerTDD.Common.Interfaces.Service;
using PickAWinnerTDD.UnitTesting.Stubs;
using Should;

namespace PickAWinnerTDD.Service.Tests.Unit.Stubbing {
    [TestClass]
    public class SwagServiceTests {
        #region << Setup/Teardown >>

        [TestInitialize]
        public void TestInitialize() {
            StructureMapBootstrapperStub.BootstrapStructureMap();
        }

        #endregion

        #region << Tests >>

        [TestMethod]
        public void GetAll_ShouldReturn_NonNull_ListOf_SwagDTO() {
            //Act
            ISwagService service = new SwagService();
            IList<SwagDTO> swags = service.GetAll();
            //Assert
            swags.ShouldNotBeNull("Expected Not Null");
            Assert.IsInstanceOfType(swags, typeof (IList<SwagDTO>));
        }

        [TestMethod]
        public void GetAllBySponsor_ShouldReturn_NonNull_ListOf_SponsorDTO() {
            //Act
            ISwagService service = new SwagService();
            IList<SwagDTO> swags = service.GetAllBySponsor(11);
            //Assert
            swags.ShouldNotBeNull("Expected Not Null");
            Assert.IsInstanceOfType(swags, typeof (IList<SwagDTO>));
        }

        #endregion
    }
}