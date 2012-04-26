using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PickAWinnerTDD.Common.DataTransferObjects;
using PickAWinnerTDD.Common.Interfaces.Domain;
using PickAWinnerTDD.UnitTesting.Stubs;
using Should;

namespace PickAWinnerTDD.Domain.Tests.Integration {

    [TestClass]
    public class SponsorTests {

        #region << Setup/Teardown >>

        [TestInitialize]
        public void TestInitialize() {
            StructureMapBootstrapperStub.BootstrapStructureMap();
        }

        #endregion

        [TestMethod]
        public void GetAll_ShouldReturn_NonNull_ListOf_SponsorDTO() {
            //Act
            ISponsor sponsor = new Sponsor();
            IList<SponsorDTO> sponsors = sponsor.GetAll();
            //Assert
            sponsors.ShouldNotBeNull("Expected Not Null");
            Assert.IsInstanceOfType(sponsors, typeof (IList<SponsorDTO>));
        }

        [TestMethod]
        public void GetAllThatProvidedSwag_ShouldReturn_NonNull_ListOf_SponsorDTO() {
            //Act
            ISponsor sponsor = new Sponsor();
            IList<SponsorDTO> sponsors = sponsor.GetAllThatProvidedSwag();
            //Assert
            sponsors.ShouldNotBeNull("Expected Not Null");
            Assert.IsInstanceOfType(sponsors, typeof(IList<SponsorDTO>));
        }

    }
}