using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PickAWinnerTDD.Common.DataTransferObjects;
using PickAWinnerTDD.Common.Interfaces.Domain;
using PickAWinnerTDD.Common.Interfaces.Repository;
using Rhino.Mocks;
using Should;

namespace PickAWinnerTDD.Domain.Tests.Unit.Mocking {

    [TestClass]
    public class AttendeeTests {

        #region << Private Fields >>

        private MockRepository _mockRepository;
        private IAttendeeRepository _mockRepo;

        #endregion

        #region << Setup/Teardown >>

        [TestInitialize]
        public void TestInitialize() {
            _mockRepository = new MockRepository();
            _mockRepo = _mockRepository.StrictMock<IAttendeeRepository>();
        }

        [TestCleanup]
        public void TestCleanup() {
            _mockRepo = null;
        }

        #endregion

        #region << Tests >>

        [TestMethod]
        public void GetAll_ShouldReturn_NonNull_ListOf_AttendeeDTO() {
            //Arrange
            _mockRepo.Expect(x => x.GetAll()).Return(new List<AttendeeDTO> ()).Repeat.Once();
            _mockRepository.ReplayAll();
            //Act
            IAttendee attendee = new Attendee(_mockRepo);
            IList<AttendeeDTO> attendeeDtos = attendee.GetAll();
            //Assert
            _mockRepository.VerifyAll();
            attendeeDtos.ShouldNotBeNull("Expected AttendeeDTO List Not To Be Null");
            Assert.IsInstanceOfType(attendeeDtos, typeof(IList<AttendeeDTO>));
        }

        [TestMethod]
        public void GetAllEligible_ShouldReturn_NonNull_ListOf_AttendeeDTO() {
            //Arrange
            _mockRepo.Expect(x => x.GetAllEligible()).Return(new List<AttendeeDTO>()).Repeat.Once();
            _mockRepository.ReplayAll();
            //Act
            IAttendee attendee = new Attendee(_mockRepo);
            IList<AttendeeDTO> attendeeDtos = attendee.GetAllEligible();
            //Assert
            _mockRepository.VerifyAll();
            attendeeDtos.ShouldNotBeNull("Expected AttendeeDTO List Not To Be Null");
            Assert.IsInstanceOfType(attendeeDtos, typeof(IList<AttendeeDTO>));
        }

        [TestMethod]
        public void SetHasWon_ShouldReturn_NonNull_Boolean() {
            //Arrange
            const bool success = true;
            _mockRepo.Expect(x => x.SetHasWon(1)).Return(success).Repeat.Once();
            _mockRepository.ReplayAll();
            //Act
            IAttendee attendee = new Attendee(_mockRepo);
            bool returnSuccess = attendee.SetHasWon(1);
            //Assert
            _mockRepository.VerifyAll();
            Assert.IsInstanceOfType(returnSuccess, typeof(bool));
        }

        [TestMethod]
        public void ResetAllHasWon_ShouldReturn_NonNull_Boolean() {
            //Arrange
            const bool success = true;
            _mockRepo.Expect(x => x.ResetAllHasWon()).Return(success).Repeat.Once();
            _mockRepository.ReplayAll();
            //Act
            IAttendee attendee = new Attendee(_mockRepo);
            bool returnSuccess = attendee.ResetAllHasWon();
            //Assert
            _mockRepository.VerifyAll();
            Assert.IsInstanceOfType(returnSuccess, typeof(bool));
        }

        [TestMethod]
        public void DeleteAll_ShouldReturn_NonNull_Boolean() {
            //Arrange
            const bool success = true;
            _mockRepo.Expect(x => x.DeleteAll()).Return(success).Repeat.Once();
            _mockRepository.ReplayAll();
            //Act
            IAttendee attendee = new Attendee(_mockRepo);
            bool returnSuccess = attendee.DeleteAll();
            //Assert
            _mockRepository.VerifyAll();
            Assert.IsInstanceOfType(returnSuccess, typeof(bool));
        }

        [TestMethod]
        public void InsertsAll_ShouldReturn_NonNull_Boolean() {
            //Arrange
            const bool success = true;
            _mockRepo.Expect(x => x.InsertAll(new List<AttendeeDTO>())).IgnoreArguments().Return(success).Repeat.Once();
            _mockRepository.ReplayAll();
            //Act
            IAttendee attendee = new Attendee(_mockRepo);
            bool returnSuccess = attendee.InsertAll(new List<AttendeeDTO>());
            //Assert
            _mockRepository.VerifyAll();
            Assert.IsInstanceOfType(returnSuccess, typeof(bool));
        }

        #endregion

    }
}