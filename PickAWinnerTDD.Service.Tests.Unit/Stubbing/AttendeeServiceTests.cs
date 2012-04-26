using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PickAWinnerTDD.Common.DataTransferObjects;
using PickAWinnerTDD.Common.Interfaces.Service;
using PickAWinnerTDD.UnitTesting.Stubs;
using Should;

namespace PickAWinnerTDD.Service.Tests.Unit.Stubbing {
    [TestClass]
    public class AttendeeServiceTests {
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
            IAttendeeService service = new AttendeeService();
            IList<AttendeeDTO> attendeeDtos = service.GetAll();
            //Assert
            attendeeDtos.ShouldNotBeNull("Expected AttendeeDTO List Not To Be Null");
            Assert.IsInstanceOfType(attendeeDtos, typeof (IList<AttendeeDTO>));
        }

        [TestMethod]
        public void GetAllEligible_ShouldReturn_NonNull_ListOf_AttendeeDTO() {
            //Act
            IAttendeeService service = new AttendeeService();
            IList<AttendeeDTO> attendeeDtos = service.GetAllEligible();
            //Assert
            attendeeDtos.ShouldNotBeNull("Expected AttendeeDTO List Not To Be Null");
            Assert.IsInstanceOfType(attendeeDtos, typeof (IList<AttendeeDTO>));
        }

        [TestMethod]
        public void SetHasWon_ShouldReturn_NonNull_Boolean() {
            //Act
            IAttendeeService service = new AttendeeService();
            bool returnSuccess = service.SetHasWon(1);
            //Assert
            Assert.IsInstanceOfType(returnSuccess, typeof (bool));
        }

        [TestMethod]
        public void ResetAllHasWon_ShouldReturn_NonNull_Boolean() {
            IAttendeeService service = new AttendeeService();
            bool returnSuccess = service.ResetAllHasWon();
            //Assert
            Assert.IsInstanceOfType(returnSuccess, typeof (bool));
        }

        [TestMethod]
        public void DeleteAll_ShouldReturn_NonNull_Boolean() {
            //Act
            IAttendeeService service = new AttendeeService();
            bool returnSuccess = service.DeleteAll();
            //Assert
            Assert.IsInstanceOfType(returnSuccess, typeof (bool));
        }

        [TestMethod]
        public void InsertAll_ShouldReturn_NonNull_Boolean() {
            //Act
            IAttendeeService service = new AttendeeService();
            bool returnSuccess = service.InsertAll(new List<AttendeeDTO>());
            //Assert
            Assert.IsInstanceOfType(returnSuccess, typeof(bool));
        }

        #endregion
    }
}