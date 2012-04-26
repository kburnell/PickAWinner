using System.Transactions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PickAWinnerTDD.Common.DataTransferObjects;
using PickAWinnerTDD.Common.Interfaces.Service;
using PickAWinnerTDD.UnitTesting.Helpers;

namespace PickAWinnerTDD.Service.Tests.Integration {

    [TestClass]
    public class WinnerServiceTests {

        #region << Setup/Teardown >>

        [TestInitialize]
        public void TestInitialize() {
            StructureMapBootstrapper.BootstrapStructureMap();
        }

        #endregion

        #region << Tests >>

        [TestMethod]
        public void Insert_ShouldReturn_NonNull_Boolean() {
            using (new TransactionScope()) {
                //Arrange
                long attendeeID = new AttendeeService().GetAll()[0].AttendeeID;
                long sponsorID = new SponsorService().GetAllThatProvidedSwag()[0].SponsorID;
                long swagID = new SwagService().GetAllBySponsor(sponsorID)[0].SwagID;
                //Act
                IWinnerService service = new WinnerService();
                bool result = service.Insert(new WinnerDTO {AttendeeID = attendeeID, SponsorID = sponsorID, SwagID = swagID, Name = "Big Winner",});
                //Assert
                Assert.IsInstanceOfType(result, typeof (bool));
            }
        }

        [TestMethod]
        public void DeleteAll_ShouldReturn_NonNull_Boolean() {
            using (new TransactionScope()) {
                //Act
                IWinnerService service = new WinnerService();
                bool result = service.DeleteAll();
                //Assert
                Assert.IsInstanceOfType(result, typeof (bool));
            }
        }

        #endregion
    }
}