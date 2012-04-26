using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PickAWinnerTDD.Common.DataTransferObjects;
using PickAWinnerTDD.Common.Interfaces.Repository;
using PickAWinnerTDD.DataAccess.DBML;
using Should;

namespace PickAWinnerTDD.DataAccess.Tests.Unit {

    /// <summary>
    /// Attendee Repository Tests
    /// </summary>
    [TestClass]
    public class AttendeeRepositoryTests {
        
        [TestMethod]
        public void GetAll_ShouldReturn_All_Attendees_InThe_Database() {
            //Arrange
            int expectedCount;
            using (DayOfDotNetDataContext dc = new DayOfDotNetDataContext()) {
                expectedCount = (from x in dc.Attendees select x).Count();
            }
            //Act
            IAttendeeRepository attendeeRepository = new AttendeeRepository();
            IList<AttendeeDTO> attendees = attendeeRepository.GetAll();
            //Assert
            attendees.Count.ShouldEqual(expectedCount);
        }
    }
}