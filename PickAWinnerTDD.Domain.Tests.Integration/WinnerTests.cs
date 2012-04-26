using System.Transactions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PickAWinnerTDD.Common.DataTransferObjects;
using PickAWinnerTDD.Common.Interfaces.Domain;
using PickAWinnerTDD.UnitTesting.Helpers;

namespace PickAWinnerTDD.Domain.Tests.Integration {

    [TestClass]
    public class WinnerTests {

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
                long attendeeID = new Attendee().GetAll()[0].AttendeeID;
                long sponsorID = new Sponsor().GetAllThatProvidedSwag()[0].SponsorID;
                long swagID = new Swag().GetAllBySponsor(sponsorID)[0].SwagID;
                //Act
                IWinner winner = new Winner();
                bool result = winner.Insert(new WinnerDTO{Name = "Joe Smith", SponsorID = sponsorID, SwagID = swagID, AttendeeID = attendeeID});
                //Assert
                Assert.IsInstanceOfType(result, typeof (bool));
            }
        }

        [TestMethod]
        public void DeleteAll_ShouldReturn_NonNull_Boolean() {
            using (new TransactionScope()) {
                //Act
                IWinner winner = new Winner();
                bool result = winner.DeleteAll();
                //Assert
                Assert.IsInstanceOfType(result, typeof (bool));
            }
        }

        #endregion
    }
}