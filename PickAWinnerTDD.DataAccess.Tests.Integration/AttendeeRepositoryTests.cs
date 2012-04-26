using System.Collections.Generic;
using System.Linq;
using System.Transactions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PickAWinnerTDD.Common.DataTransferObjects;
using PickAWinnerTDD.Common.Interfaces.Repository;
using PickAWinnerTDD.DataAccess.DBML;
using Should;

namespace PickAWinnerTDD.DataAccess.Tests.Integration {
    /// <summary>
    /// Attendee Repository Tests
    /// </summary>
    [TestClass]
    public class AttendeeRepositoryTests {
        [TestMethod]
        public void GetAll_ShouldReturn_All_Attendees_InThe_Database() {
            //Arrange
            int expectedCount;
            using (var dc = new DayOfDotNetDataContext()) {
                expectedCount = (from x in dc.Attendees select x).Count();
            }
            //Act
            IAttendeeRepository attendeeRepository = new AttendeeRepository();
            IList<AttendeeDTO> attendees = attendeeRepository.GetAll();
            //Assert
            attendees.Count.ShouldEqual(expectedCount, "Wrong number of attendess");
        }

        [TestMethod]
        public void GetAllEligible_ShouldReturn_All_Attendess_InThe_Database_Where_IsEligible_Equals_True() {
            //Arrange
            int expectedCount;
            using (var dc = new DayOfDotNetDataContext()) {
                expectedCount = (from x in dc.Attendees where x.IsEligible select x).Count();
            }
            //Act
            IAttendeeRepository attendeeRepository = new AttendeeRepository();
            IList<AttendeeDTO> attendees = attendeeRepository.GetAllEligible();
            //Assert
            attendees.Count.ShouldEqual(expectedCount, "Wrong number of attendess");
            (from x in attendees where !x.IsEligible select x).Count().ShouldEqual(0, "Expected 0 Non-Eligible Attendees");
        }

        [TestMethod]
        public void SetHasWon_ShouldSetThe_HasWon_Flag_To_True_OnThe_Attendee_WithTheSpecified_AttendeeID() {
            //Arrange
            long attendeeID;
            using (new TransactionScope()) {
                using (var dc = new DayOfDotNetDataContext()) {
                    Attendee attendee = (from x in dc.Attendees where x.IsEligible && !x.HasWon select x).FirstOrDefault();
                    attendee.HasWon = true;
                    attendeeID = attendee.AttendeeID;
                    dc.SubmitChanges();
                }
                //Act
                IAttendeeRepository repo = new AttendeeRepository();
                bool successful = repo.SetHasWon(attendeeID);
                //Assert
                successful.ShouldBeTrue("Expected True");
                using (var dc = new DayOfDotNetDataContext()) {
                    (from x in dc.Attendees where x.AttendeeID == attendeeID select x.HasWon).FirstOrDefault().ShouldBeTrue("Expected True");
                }
            }
        }

        [TestMethod]
        public void ResetAllHasWon_ShouldSetThe_HasWon_Flag_To_False_OnAll_Attendees() {
            //Arrange
            using (new TransactionScope()) {
                using (var dc = new DayOfDotNetDataContext()) {
                    Attendee attendee = (from x in dc.Attendees where x.IsEligible && !x.HasWon select x).FirstOrDefault();
                    attendee.HasWon = true;
                    dc.SubmitChanges();
                }
                //Act
                IAttendeeRepository repo = new AttendeeRepository();
                bool successful = repo.ResetAllHasWon();
                //Assert
                successful.ShouldBeTrue("Expected True");
                using (var dc = new DayOfDotNetDataContext()) {
                    (from x in dc.Attendees where x.HasWon select x).Count().ShouldEqual(0, "Expected 0 HasWon == True");
                }
            }
        }

        [TestMethod]
        public void DeleteAll_ShouldDelete_All_Attendees(){
             //Arrange
            using (new TransactionScope()) {
                //Act
                IAttendeeRepository repo = new AttendeeRepository();
                bool successful = repo.DeleteAll();
                //Assert
                successful.ShouldBeTrue("Expected True");
                using (var dc = new DayOfDotNetDataContext()) {
                    (from x in dc.Attendees select x).Count().ShouldEqual(0, "Expected 0 Attendees");
                }
            }
        }

        [TestMethod]
        public void InsertAll_ShouldInsertAllTheSupplied_Attendees() {
            //Arrange
            AttendeeDTO attendee1 = new AttendeeDTO {FirstName = "FName1", LastName = "LName1", Company = "Company1", Email = "LNam1@Company1.com", IsEligible = true, HasWon = true};
            AttendeeDTO attendee2 = new AttendeeDTO {FirstName = "FName2", LastName = "LName2", Company = "Company2", Email = "LNam2@Company2.com", IsEligible = false, HasWon = false};
            IList<AttendeeDTO> attendees = new List<AttendeeDTO>{attendee1,attendee2};
            using (new TransactionScope()) {
                using (var dc = new DayOfDotNetDataContext()) {
                    dc.ExecuteCommand("Delete from Winner");
                    dc.ExecuteCommand("Delete from Attendee");
                }
                //Act
                IAttendeeRepository repo = new AttendeeRepository();
                bool successful = repo.InsertAll(attendees);
                //Assert
                successful.ShouldBeTrue("Expected True");
                using (var dc = new DayOfDotNetDataContext()) {
                    (from x in dc.Attendees select x).Count().ShouldEqual(2, "Expected 2 Attendees");
                }
            }
        }
    }
}