using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PickAWinnerTDD.Common.DataTransferObjects;
using PickAWinnerTDD.Common.Interfaces.Domain;
using PickAWinnerTDD.Common.Interfaces.Repository;
using Rhino.Mocks;
using Should;

namespace PickAWinnerTDD.Domain.Tests.Unit.Mocking {
    [TestClass]
    public class SwagTests {

        #region << Private Fields >>

        private MockRepository _mockRepository;
        private ISwagRepository _mockRepo;

        #endregion

        #region << Setup/Teardown >>

        [TestInitialize]
        public void TestInitialize() {
            _mockRepository = new MockRepository();
            _mockRepo = _mockRepository.StrictMock<ISwagRepository>();
        }

        [TestCleanup]
        public void TestCleanup() {
            _mockRepo = null;
        }

        #endregion

        #region << Tests >>

        [TestMethod]
        public void GetAll_ShouldReturn_NonNull_ListOf_SwagDTO() {
            //Arrange
            _mockRepo.Expect(x => x.GetAll()).Return(new List<SwagDTO>()).Repeat.Once();
            _mockRepository.ReplayAll();
            //Act
            ISwag swag = new Swag(_mockRepo);
            IList<SwagDTO> swags = swag.GetAll();
            //Assert
            _mockRepository.VerifyAll();
            swags.ShouldNotBeNull("Expected Not Null");
            Assert.IsInstanceOfType(swags, typeof (IList<SwagDTO>));
        }

        [TestMethod]
        public void GetAllBySponsor_ShouldReturn_NonNull_ListOf_SponsorDTO() {
            //Arrange
            _mockRepo.Expect(x => x.GetAllBySponsor(1)).Return(new List<SwagDTO>()).Repeat.Once();
            _mockRepository.ReplayAll();
            //Act
            ISwag swag = new Swag(_mockRepo);
            IList<SwagDTO> swags = swag.GetAllBySponsor(1);
            //Assert
            _mockRepository.VerifyAll();
            swags.ShouldNotBeNull("Expected Not Null");
            Assert.IsInstanceOfType(swags, typeof(IList<SwagDTO>));
        }

        
       #endregion
    }
}