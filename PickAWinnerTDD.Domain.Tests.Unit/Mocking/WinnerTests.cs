using Microsoft.VisualStudio.TestTools.UnitTesting;
using PickAWinnerTDD.Common.DataTransferObjects;
using PickAWinnerTDD.Common.Interfaces.Domain;
using PickAWinnerTDD.Common.Interfaces.Repository;
using Rhino.Mocks;

namespace PickAWinnerTDD.Domain.Tests.Unit.Mocking {

    [TestClass]
    public class WinnerTests {

        #region << Private Fields >>

        private MockRepository _mockRepository;
        private IWinnerRepository _mockRepo;

        #endregion

        #region << Setup/Teardown >>

        [TestInitialize]
        public void TestInitialize() {
            _mockRepository = new MockRepository();
            _mockRepo = _mockRepository.StrictMock<IWinnerRepository>();
        }

        [TestCleanup]
        public void TestCleanup() {
            _mockRepo = null;
        }

        #endregion

        #region << Tests >>

        [TestMethod]
        public void Insert_ShouldReturn_NonNull_Boolean() {
            //Arrange
            _mockRepo.Expect(x => x.Insert(new WinnerDTO())).IgnoreArguments().Return(true).Repeat.Once();
            _mockRepository.ReplayAll();
            //Act
            IWinner Winner = new Winner(_mockRepo);
            bool result = Winner.Insert(new WinnerDTO());
            //Assert
            _mockRepository.VerifyAll();
            Assert.IsInstanceOfType(result, typeof (bool));
        }

        [TestMethod]
        public void DeleteAll_ShouldReturn_NonNull_Boolean() {
            //Arrange
            _mockRepo.Expect(x => x.DeleteAll()).Return(true).Repeat.Once();
            _mockRepository.ReplayAll();
            //Act
            IWinner Winner = new Winner(_mockRepo);
            bool result = Winner.DeleteAll();
            //Assert
            _mockRepository.VerifyAll();
            Assert.IsInstanceOfType(result, typeof(bool));
        }

        
       #endregion
    }
}