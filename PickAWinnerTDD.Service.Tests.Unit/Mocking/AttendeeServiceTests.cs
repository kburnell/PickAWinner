using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PickAWinnerTDD.Common.DataTransferObjects;
using PickAWinnerTDD.Common.Interfaces.Domain;
using PickAWinnerTDD.Common.Interfaces.Service;
using PickAWinnerTDD.Domain;
using Rhino.Mocks;
using Should;

namespace PickAWinnerTDD.Service.Tests.Unit.Mocking {

    [TestClass]
    public class AttendeeServiceTests {

        #region << Private Fields >>

        private MockRepository _mockRepository;
        private IAttendee _mockAttendee;

        #endregion

        #region << Setup/Teardown >>

        [TestInitialize]
        public void TestInitialize() {
            _mockRepository = new MockRepository();
            _mockAttendee = _mockRepository.StrictMock<IAttendee>();
        }

        [TestCleanup]
        public void TestCleanup() {
            _mockAttendee = null;
        }

        #endregion

        #region << Tests >>

        [TestMethod]
        public void GetAll_ShouldReturn_NonNull_ListOf_AttendeeDTO() {
            //Arrange
            _mockAttendee.Expect(x => x.GetAll()).Return(new List<AttendeeDTO> ()).Repeat.Once();
            _mockRepository.ReplayAll();
            //Act
            IAttendeeService service = new AttendeeService(_mockAttendee);
            IList<AttendeeDTO> attendeeDtos = service.GetAll();
            //Assert
            _mockRepository.VerifyAll();
            attendeeDtos.ShouldNotBeNull("Expected AttendeeDTO List Not To Be Null");
            Assert.IsInstanceOfType(attendeeDtos, typeof(IList<AttendeeDTO>));
        }

        [TestMethod]
        public void GetAllEligible_ShouldReturn_NonNull_ListOf_AttendeeDTO() {
            //Arrange
            _mockAttendee.Expect(x => x.GetAllEligible()).Return(new List<AttendeeDTO>()).Repeat.Once();
            _mockRepository.ReplayAll();
            //Act
            IAttendeeService service = new AttendeeService(_mockAttendee);
            IList<AttendeeDTO> attendeeDtos = service.GetAllEligible();
            //Assert
            _mockRepository.VerifyAll();
            attendeeDtos.ShouldNotBeNull("Expected AttendeeDTO List Not To Be Null");
            Assert.IsInstanceOfType(attendeeDtos, typeof(IList<AttendeeDTO>));
        }

        [TestMethod]
        public void SetHasWon_ShouldReturn_NonNull_Boolean() {
            //Arrange
            const bool success = true;
            _mockAttendee.Expect(x => x.SetHasWon(1)).Return(success).Repeat.Once();
            _mockRepository.ReplayAll();
            //Act
            IAttendeeService service = new AttendeeService(_mockAttendee);
            bool returnSuccess = service.SetHasWon(1);
            //Assert
            _mockRepository.VerifyAll();
            Assert.IsInstanceOfType(returnSuccess, typeof(bool));
        }

        [TestMethod]
        public void ResetAllHasWon_ShouldReturn_NonNull_Boolean() {
            //Arrange
            const bool success = true;
            _mockAttendee.Expect(x => x.ResetAllHasWon()).Return(success).Repeat.Once();
            _mockRepository.ReplayAll();
            //Act
            IAttendeeService service = new AttendeeService(_mockAttendee);
            bool returnSuccess = service.ResetAllHasWon();
            //Assert
            _mockRepository.VerifyAll();
            Assert.IsInstanceOfType(returnSuccess, typeof(bool));
        }

        [TestMethod]
        public void DeleteAll_ShouldReturn_NonNull_Boolean() {
            //Arrange
            const bool success = true;
            _mockAttendee.Expect(x => x.DeleteAll()).Return(success).Repeat.Once();
            _mockRepository.ReplayAll();
            //Act
            IAttendeeService service = new AttendeeService(_mockAttendee);
            bool returnSuccess = service.DeleteAll();
            //Assert
            _mockRepository.VerifyAll();
            Assert.IsInstanceOfType(returnSuccess, typeof(bool));
        }

        [TestMethod]
        public void Insertll_ShouldReturn_NonNull_Boolean() {
            //Arrange
            const bool success = true;
            _mockAttendee.Expect(x => x.InsertAll(new List<AttendeeDTO>())).IgnoreArguments().Return(success).Repeat.Once();
            _mockRepository.ReplayAll();
            //Act
            IAttendeeService service = new AttendeeService(_mockAttendee);
            bool returnSuccess = service.InsertAll(new List<AttendeeDTO>());
            //Assert
            _mockRepository.VerifyAll();
            Assert.IsInstanceOfType(returnSuccess, typeof(bool));
        }

        #endregion

    }
}