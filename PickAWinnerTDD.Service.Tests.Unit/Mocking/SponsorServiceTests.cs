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
    public class SponsorServiceTests {

        #region << Private Fields >>

        private MockRepository _mockRepository;
        private ISponsor _mockDomain;

        #endregion

        #region << Setup/Teardown >>

        [TestInitialize]
        public void TestInitialize() {
            _mockRepository = new MockRepository();
            _mockDomain = _mockRepository.StrictMock<ISponsor>();
        }

        [TestCleanup]
        public void TestCleanup() {
            _mockDomain = null;
        }

        #endregion

        #region << Tests >>

        [TestMethod]
        public void GetAll_ShouldReturn_NonNull_ListOf_SponsorDTO() {
            //Arrange
            _mockDomain.Expect(x => x.GetAll()).Return(new List<SponsorDTO>()).Repeat.Once();
            _mockRepository.ReplayAll();
            //Act
            ISponsorService service = new SponsorService(_mockDomain);
            IList<SponsorDTO> sponsors = service.GetAll();
            //Assert
            _mockRepository.VerifyAll();
            sponsors.ShouldNotBeNull("Expected Not Null");
            Assert.IsInstanceOfType(sponsors, typeof (IList<SponsorDTO>));
        }

        [TestMethod]
        public void GetAllThatProvidedSwag_ShouldReturn_NonNull_ListOf_SponsorDTO() {
            //Arrange
            _mockDomain.Expect(x => x.GetAllThatProvidedSwag()).Return(new List<SponsorDTO>()).Repeat.Once();
            _mockRepository.ReplayAll();
            //Act
            ISponsorService service = new SponsorService(_mockDomain);
            IList<SponsorDTO> sponsors = service.GetAllThatProvidedSwag();
            //Assert
            _mockRepository.VerifyAll();
            sponsors.ShouldNotBeNull("Expected Not Null");
            Assert.IsInstanceOfType(sponsors, typeof(IList<SponsorDTO>));
        }

        
       #endregion
    }
}