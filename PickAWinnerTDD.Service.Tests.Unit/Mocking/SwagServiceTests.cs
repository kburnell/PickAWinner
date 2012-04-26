using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PickAWinnerTDD.Common.DataTransferObjects;
using PickAWinnerTDD.Common.Interfaces.Domain;
using PickAWinnerTDD.Common.Interfaces.Repository;
using PickAWinnerTDD.Common.Interfaces.Service;
using PickAWinnerTDD.Domain;
using Rhino.Mocks;
using Should;

namespace PickAWinnerTDD.Service.Tests.Unit.Mocking {
    [TestClass]
    public class SwagServiceTests {

        #region << Private Fields >>

        private MockRepository _mockRepository;
        private ISwag _mockDomain;

        #endregion

        #region << Setup/Teardown >>

        [TestInitialize]
        public void TestInitialize() {
            _mockRepository = new MockRepository();
            _mockDomain = _mockRepository.StrictMock<ISwag>();
        }

        [TestCleanup]
        public void TestCleanup() {
            _mockDomain = null;
        }

        #endregion

        #region << Tests >>

        [TestMethod]
        public void GetAll_ShouldReturn_NonNull_ListOf_SwagDTO() {
            //Arrange
            _mockDomain.Expect(x => x.GetAll()).Return(new List<SwagDTO>()).Repeat.Once();
            _mockRepository.ReplayAll();
            //Act
            ISwagService service = new SwagService(_mockDomain);
            IList<SwagDTO> swags = service.GetAll();
            //Assert
            _mockRepository.VerifyAll();
            swags.ShouldNotBeNull("Expected Not Null");
            Assert.IsInstanceOfType(swags, typeof (IList<SwagDTO>));
        }

        [TestMethod]
        public void GetAllBySponsor_ShouldReturn_NonNull_ListOf_SponsorDTO() {
            //Arrange
            _mockDomain.Expect(x => x.GetAllBySponsor(11)).Return(new List<SwagDTO>()).Repeat.Once();
            _mockRepository.ReplayAll();
            //Act
            ISwagService service = new SwagService(_mockDomain);
            IList<SwagDTO> swags = service.GetAllBySponsor(11);
            //Assert
            _mockRepository.VerifyAll();
            swags.ShouldNotBeNull("Expected Not Null");
            Assert.IsInstanceOfType(swags, typeof(IList<SwagDTO>));
        }

        
       #endregion
    }
}