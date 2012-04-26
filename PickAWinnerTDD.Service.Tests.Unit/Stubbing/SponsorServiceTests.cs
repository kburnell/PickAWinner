using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PickAWinnerTDD.Common.DataTransferObjects;
using PickAWinnerTDD.Common.Interfaces.Service;
using PickAWinnerTDD.UnitTesting.Stubs;
using Should;

namespace PickAWinnerTDD.Service.Tests.Unit.Stubbing {
    [TestClass]
    public class SponsorServiceTests {
        #region << Setup/Teardown >>

        [TestInitialize]
        public void TestInitialize() {
            StructureMapBootstrapperStub.BootstrapStructureMap();
        }

        #endregion

        #region << Tests >>

        [TestMethod]
        public void GetAll_ShouldReturn_NonNull_ListOf_SponsorDTO() {
            //Act
            ISponsorService service = new SponsorService();
            IList<SponsorDTO> sponsors = service.GetAll();
            //Assert
            sponsors.ShouldNotBeNull("Expected Not Null");
            Assert.IsInstanceOfType(sponsors, typeof (IList<SponsorDTO>));
        }

        [TestMethod]
        public void GetAllThatProvidedSwag_ShouldReturn_NonNull_ListOf_SponsorDTO() {
            //Act
            ISponsorService service = new SponsorService();
            IList<SponsorDTO> sponsors = service.GetAllThatProvidedSwag();
            //Assert
            sponsors.ShouldNotBeNull("Expected Not Null");
            Assert.IsInstanceOfType(sponsors, typeof (IList<SponsorDTO>));
        }

        #endregion
    }
}