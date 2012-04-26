using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PickAWinnerTDD.Common.DataTransferObjects;
using PickAWinnerTDD.Common.Interfaces.Domain;
using PickAWinnerTDD.Common.Interfaces.Repository;
using Rhino.Mocks;
using Should;

namespace PickAWinnerTDD.Domain.Tests.Unit.Mocking {
    [TestClass]
    public class SponsorTests {

        #region << Private Fields >>

        private MockRepository _mockRepository;
        private ISponsorRepository _mockRepo;

        #endregion

        #region << Setup/Teardown >>

        [TestInitialize]
        public void TestInitialize() {
            _mockRepository = new MockRepository();
            _mockRepo = _mockRepository.StrictMock<ISponsorRepository>();
        }

        [TestCleanup]
        public void TestCleanup() {
            _mockRepo = null;
        }

        #endregion

        #region << Tests >>

        [TestMethod]
        public void GetAll_ShouldReturn_NonNull_ListOf_SponsorDTO() {
            //Arrange
            _mockRepo.Expect(x => x.GetAll()).Return(new List<SponsorDTO>()).Repeat.Once();
            _mockRepository.ReplayAll();
            //Act
            ISponsor sponsor = new Sponsor(_mockRepo);
            IList<SponsorDTO> sponsors = sponsor.GetAll();
            //Assert
            _mockRepository.VerifyAll();
            sponsors.ShouldNotBeNull("Expected Not Null");
            Assert.IsInstanceOfType(sponsors, typeof (IList<SponsorDTO>));
        }

        [TestMethod]
        public void GetAllThatProvidedSwag_ShouldReturn_NonNull_ListOf_SponsorDTO() {
            //Arrange
            _mockRepo.Expect(x => x.GetAllThatProvidedSwag()).Return(new List<SponsorDTO>()).Repeat.Once();
            _mockRepository.ReplayAll();
            //Act
            ISponsor sponsor = new Sponsor(_mockRepo);
            IList<SponsorDTO> sponsors = sponsor.GetAllThatProvidedSwag();
            //Assert
            _mockRepository.VerifyAll();
            sponsors.ShouldNotBeNull("Expected Not Null");
            Assert.IsInstanceOfType(sponsors, typeof(IList<SponsorDTO>));
        }

        
       #endregion
    }
}