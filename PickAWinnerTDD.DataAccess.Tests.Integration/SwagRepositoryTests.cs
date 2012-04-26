using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PickAWinnerTDD.Common.DataTransferObjects;
using PickAWinnerTDD.Common.Interfaces.Repository;
using PickAWinnerTDD.DataAccess.DBML;
using Should;

namespace PickAWinnerTDD.DataAccess.Tests.Integration {

    [TestClass]
    public class SwagRepositoryTests {
        
        [TestMethod]
        public void GetAll_Should_Return_All_Swags_From_The_Database() {
            //Arrange
            int expectedCount;
            using (DayOfDotNetDataContext dc = new DayOfDotNetDataContext()){
                expectedCount = (from x in dc.Swags select x).Count();
            }
            //Act
            ISwagRepository repo = new SwagRepository();
            IList<SwagDTO> swags = repo.GetAll();
            //Assert
            swags.Count.ShouldEqual(expectedCount, "Wrong number of Swags");
        }

        [TestMethod]
        public void GetAllBySponsor_Should_Return_All_Swags_ForTheSpecified_Sponsor_From_The_Database() {
            //Arrange
            int expectedCount;
            long sponsorID;
            using (DayOfDotNetDataContext dc = new DayOfDotNetDataContext()) {
                sponsorID = (from x in dc.Sponsors where x.ProvidedSwag select x.SponsorID).FirstOrDefault();
                expectedCount = (from x in dc.Swags where x.SponsorID == sponsorID select x).Count();
            }
            //Act
            ISwagRepository repo = new SwagRepository();
            IList<SwagDTO> swags = repo.GetAllBySponsor(sponsorID);
            //Assert
            swags.Count.ShouldEqual(expectedCount, "Wrong number of Swags");
            (from x in swags select x.SponsorID).Distinct().Count().ShouldEqual(1, "Expected 1 Distinct SponsorId");
            swags[0].SponsorID.ShouldEqual(sponsorID, "Wrong SponsorID");
        }

    }
}