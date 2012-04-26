using Microsoft.VisualStudio.TestTools.UnitTesting;
using PickAWinnerTDD.Common.DataTransferObjects;
using PickAWinnerTDD.Common.Interfaces.Domain;
using PickAWinnerTDD.Common.Interfaces.Repository;
using PickAWinnerTDD.Common.Interfaces.Service;
using PickAWinnerTDD.Domain;
using Rhino.Mocks;

namespace PickAWinnerTDD.Service.Tests.Unit.Mocking {

    [TestClass]
    public class WinnerTests {

        #region << Private Fields >>

        private MockRepository _mockRepository;
        private IWinner _mockDomain;

        #endregion

        #region << Setup/Teardown >>

        [TestInitialize]
        public void TestInitialize() {
            _mockRepository = new MockRepository();
            _mockDomain = _mockRepository.StrictMock<IWinner>();
        }

        [TestCleanup]
        public void TestCleanup() {
            _mockDomain = null;
        }

        #endregion

        #region << Tests >>

        [TestMethod]
        public void Insert_ShouldReturn_NonNull_Boolean() {
            //Arrange
            _mockDomain.Expect(x => x.Insert(new WinnerDTO())).IgnoreArguments().Return(true).Repeat.Once();
            _mockRepository.ReplayAll();
            //Act
            IWinnerService service = new WinnerService(_mockDomain);
            bool result = service.Insert(new WinnerDTO());
            //Assert
            _mockRepository.VerifyAll();
            Assert.IsInstanceOfType(result, typeof (bool));
        }

        [TestMethod]
        public void DeleteAll_ShouldReturn_NonNull_Boolean() {
            //Arrange
            _mockDomain.Expect(x => x.DeleteAll()).Return(true).Repeat.Once();
            _mockRepository.ReplayAll();
            //Act
            IWinnerService service = new WinnerService(_mockDomain);
            bool result = service.DeleteAll();
            //Assert
            _mockRepository.VerifyAll();
            Assert.IsInstanceOfType(result, typeof(bool));
        }

        
       #endregion
    }
}