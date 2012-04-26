using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PickAWinnerTDD.Common.DataTransferObjects;
using PickAWinnerTDD.Common.Interfaces.Domain;
using PickAWinnerTDD.UnitTesting.Stubs;
using Should;

namespace PickAWinnerTDD.Domain.Tests.Unit.Stubing {

    [TestClass]
    public class AttendeeTests {

        #region << Setup/Teardown >>

        [TestInitialize]
        public void TestInitialize() {
            StructureMapBootstrapperStub.BootstrapStructureMap();
        }

        #endregion

        #region << Tests >>

        [TestMethod]
        public void GetAll_ShouldReturn_NonNull_ListOf_AttendeeDTO() {
            //Act
            IAttendee attendee = new Attendee();
            IList<AttendeeDTO> attendeeDtos = attendee.GetAll();
            //Assert
            attendeeDtos.ShouldNotBeNull("Expected AttendeeDTO List Not To Be Null");
            Assert.IsInstanceOfType(attendeeDtos, typeof (IList<AttendeeDTO>));
        }

        [TestMethod]
        public void GetAllEligible_ShouldReturn_NonNull_ListOf_AttendeeDTO() {
            //Act
            IAttendee attendee = new Attendee();
            IList<AttendeeDTO> attendeeDtos = attendee.GetAllEligible();
            //Assert
            attendeeDtos.ShouldNotBeNull("Expected AttendeeDTO List Not To Be Null");
            Assert.IsInstanceOfType(attendeeDtos, typeof(IList<AttendeeDTO>));
        }

        [TestMethod]
        public void SetHasWon_ShouldReturn_NonNull_Boolean() {
            //Act
            IAttendee attendee = new Attendee();
            bool returnSuccess = attendee.SetHasWon(1);
            //Assert
            Assert.IsInstanceOfType(returnSuccess, typeof (bool));
        }

        [TestMethod]
        public void ResetAllHasWon_ShouldReturn_NonNull_Boolean() {
            //Act
            IAttendee attendee = new Attendee();
            bool returnSuccess = attendee.ResetAllHasWon();
            //Assert
            Assert.IsInstanceOfType(returnSuccess, typeof(bool));
        }

        [TestMethod]
        public void DeleteAll_ShouldReturn_NonNull_Boolean() {
            //Act
            IAttendee attendee = new Attendee();
            bool returnSuccess = attendee.DeleteAll();
            //Assert
            Assert.IsInstanceOfType(returnSuccess, typeof(bool));
        }

        [TestMethod]
        public void InsertAll_ShouldReturn_NonNull_Boolean() {
            //Act
            IAttendee attendee = new Attendee();
            bool returnSuccess = attendee.InsertAll(new List<AttendeeDTO>());
            //Assert
            Assert.IsInstanceOfType(returnSuccess, typeof(bool));
        }

        #endregion

    }
}