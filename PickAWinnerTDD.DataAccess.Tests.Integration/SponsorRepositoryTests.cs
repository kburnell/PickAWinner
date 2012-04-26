using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PickAWinnerTDD.Common.DataTransferObjects;
using PickAWinnerTDD.Common.Interfaces.Repository;
using PickAWinnerTDD.DataAccess.DBML;
using Should;

namespace PickAWinnerTDD.DataAccess.Tests.Integration {

    /// <summary>
    /// Sponsor Repository Tests
    /// </summary>
    [TestClass]
    public class SponsorRepositoryTests {
        
        [TestMethod]
        public void GetAll_ShouldReturn_All_Sponsors_InThe_Database() {
            //Arrange
            int expectedCount;
            using (DayOfDotNetDataContext dc = new DayOfDotNetDataContext()) {
                expectedCount = (from x in dc.Sponsors select x).Count();
            }
            //Act
            ISponsorRepository repo = new SponsorRepository();
            IList<SponsorDTO> sponsors = repo.GetAll();
            //Assert
            sponsors.Count.ShouldEqual(expectedCount, "Wrong number of sponsors");
        }

        [TestMethod]
        public void GetAllThatProvidedSwag_ShouldReturn_All_Sponsors_InThe_Database_Where_ProvidedSwag_Equals_True() {
            //Arrange
            int expectedCount;
            using (DayOfDotNetDataContext dc = new DayOfDotNetDataContext()){
                expectedCount = (from x in dc.Sponsors where x.ProvidedSwag select x).Count();
            }
            //Act
            ISponsorRepository repo = new SponsorRepository();
            IList<SponsorDTO> sponsors = repo.GetAllThatProvidedSwag();
            //Assert
            sponsors.Count.ShouldEqual(expectedCount, "Wrong number of sponsors");
            (from x in sponsors where !x.ProvidedSwag select x).Count().ShouldEqual(0, "Expected 0 Sponsors that did not provide swag!");
        }

    }
}