using System.Collections.Generic;
using System.Transactions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PickAWinnerTDD.Common.DataTransferObjects;
using PickAWinnerTDD.Common.Interfaces.Service;
using PickAWinnerTDD.UnitTesting.Helpers;
using Should;

namespace PickAWinnerTDD.Service.Tests.Integration {

    [TestClass]
    public class AttendeeServiceTests {

        #region << Setup/Teardown >>

        [TestInitialize]
        public void TestInitialize() {
            StructureMapBootstrapper.BootstrapStructureMap();
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
            Assert.IsInstanceOfType(attendeeDtos, typeof(IList<AttendeeDTO>));
        }

        [TestMethod]
        public void GetAllEligible_ShouldReturn_NonNull_ListOf_AttendeeDTO() {
            //Act
            IAttendeeService service = new AttendeeService();
            IList<AttendeeDTO> attendeeDtos = service.GetAllEligible();
            //Assert
            attendeeDtos.ShouldNotBeNull("Expected AttendeeDTO List Not To Be Null");
            Assert.IsInstanceOfType(attendeeDtos, typeof(IList<AttendeeDTO>));
        }

        [TestMethod]
        public void SetHasWon_ShouldReturn_NonNull_Boolean() {
            using (new TransactionScope()) {
                //Act
                IAttendeeService service = new AttendeeService();
                bool returnSuccess = service.SetHasWon(1);
                //Assert
                Assert.IsInstanceOfType(returnSuccess, typeof (bool));
            }
        }

        [TestMethod]
        public void ResetAllHasWon_ShouldReturn_NonNull_Boolean() {
            using (new TransactionScope()) {
                //Act
                IAttendeeService service = new AttendeeService();
                bool returnSuccess = service.ResetAllHasWon();
                //Assert
                Assert.IsInstanceOfType(returnSuccess, typeof (bool));
            }
        }

        [TestMethod]
        public void DeleteAll_ShouldReturn_NonNull_Boolean() {
            using (new TransactionScope()) {
                //Act
                IAttendeeService service = new AttendeeService();
                bool returnSuccess = service.DeleteAll();
                //Assert
                Assert.IsInstanceOfType(returnSuccess, typeof (bool));
            }
        }

        [TestMethod]
        public void InsertAll_ShouldReturn_NonNull_Boolean() {
            //Arrange
            IList<AttendeeDTO> attendeeDtos = new List<AttendeeDTO> { new AttendeeDTO { FirstName = "FName", LastName = "LName", Company = "Company", Email = "email@email.com", IsEligible = true, HasWon = true } };
            using (new TransactionScope())
            {
                //Act
                IAttendeeService service = new AttendeeService();
                bool returnSuccess = service.InsertAll(attendeeDtos);
                //Assert
                Assert.IsInstanceOfType(returnSuccess, typeof(bool));
            }
        }

        #endregion

    }
}