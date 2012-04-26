using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PickAWinnerTDD.Common.DataTransferObjects;
using PickAWinnerTDD.Common.Interfaces.Domain;
using PickAWinnerTDD.UnitTesting.Stubs;
using Should;

namespace PickAWinnerTDD.Domain.Tests.Integration {

    [TestClass]
    public class SwagTests {

        #region << Setup/Teardown >>

        [TestInitialize]
        public void TestInitialize(){
            StructureMapBootstrapperStub.BootstrapStructureMap();
        }

        #endregion

        #region << Tests >>

        [TestMethod]
        public void GetAll_ShouldReturn_NonNull_ListOf_SswagDTO() {
            //Act
            ISwag swag = new Swag();
            IList<SwagDTO> sponsors = swag.GetAll();
            //Assert
            sponsors.ShouldNotBeNull("Expected Not Null");
            Assert.IsInstanceOfType(sponsors, typeof (IList<SwagDTO>));
        }

        [TestMethod]
        public void GetAllBySponsor_ShouldReturn_NonNull_ListOf_SwagDTO() {
            //Act
            ISwag swag = new Swag();
            IList<SwagDTO> swags = swag.GetAllBySponsor(11);
            //Assert
            swags.ShouldNotBeNull("Expected Not Null");
            Assert.IsInstanceOfType(swags, typeof(IList<SwagDTO>));
        }

        
       #endregion
    }
}
