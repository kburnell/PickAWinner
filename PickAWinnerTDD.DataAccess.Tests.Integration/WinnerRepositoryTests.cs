using System.Linq;
using System.Transactions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PickAWinnerTDD.Common.DataTransferObjects;
using PickAWinnerTDD.Common.Interfaces.Repository;
using PickAWinnerTDD.DataAccess.DBML;
using Should;

namespace PickAWinnerTDD.DataAccess.Tests.Integration { 

    [TestClass]
    public class WinnerRepositoryTests {

        [TestMethod]
        public void Insert_ShouldAddARow_ToThe_Winner_Table_WithTheSuppliedValues() {
            using (new TransactionScope()) {
                //Arrange
                long attendeeID;
                long sponsorID;
                long swagID;
                string name = "Joe Smith";
                using (var dc = new DayOfDotNetDataContext()) {
                    attendeeID = (from x in dc.Attendees where x.IsEligible && !x.HasWon select x.AttendeeID).First();
                    sponsorID = (from x in dc.Sponsors where x.ProvidedSwag select x.SponsorID).First();
                    swagID = (from x in dc.Swags where x.SponsorID == sponsorID select x.SwagID).First();
                }
                WinnerDTO winner = new WinnerDTO {AttendeeID = attendeeID, SponsorID = sponsorID, SwagID = swagID, Name = name};
                //Act
                IWinnerRepository repo = new WinnerRepository();
                bool success = repo.Insert(winner);
                //Assert
                success.ShouldBeTrue("Expected Success To Be True");
                Winner retrievedWinner;
                using (var dc = new DayOfDotNetDataContext()) {
                    retrievedWinner = (from x in dc.Winners where x.AttendeeID == attendeeID select x).First();
                }
                retrievedWinner.AttendeeID.ShouldEqual(attendeeID, "Wrong AttendeeID");
                retrievedWinner.SponsorID.ShouldEqual(sponsorID, "Wrong SponsorID");
                retrievedWinner.SwagID.ShouldEqual(swagID, "Wrong SwagID");
                retrievedWinner.Name.ShouldEqual(name, "Wrong Name");
            }
        }

        [TestMethod]
        public void DeleteAll_ShouldRemoveAll_Winners_FromThe_Winner_Table() {
            //Arrange
            using (new TransactionScope()) {
                long attendeeID;
                long sponsorID;
                long swagID;
                string name = "Joe Smith";
                using (var dc = new DayOfDotNetDataContext()) {
                    attendeeID = (from x in dc.Attendees where x.IsEligible && !x.HasWon select x.AttendeeID).First();
                    sponsorID = (from x in dc.Sponsors where x.ProvidedSwag select x.SponsorID).First();
                    swagID = (from x in dc.Swags where x.SponsorID == sponsorID select x.SwagID).First();
                    dc.Winners.InsertOnSubmit(new Winner{AttendeeID = attendeeID, SponsorID = sponsorID, SwagID = swagID, Name = name});
                    dc.SubmitChanges();
                }
                //Act
                IWinnerRepository rep = new WinnerRepository();
                bool success = rep.DeleteAll();
                //Assert
                success.ShouldBeTrue("Expected Success To Be True");
                using (var dc = new DayOfDotNetDataContext()) {
                    (from x in dc.Winners select x).Count().ShouldEqual(0, "Expected 0 rows in Winner table");
                }
            }
        }

    }
}