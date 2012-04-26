using System.Collections.Generic;
using PickAWinnerTDD.Common.DataTransferObjects;
using PickAWinnerTDD.Common.Interfaces.Domain;

namespace PickAWinnerTDD.UnitTesting.Stubs.Domain {

    public class SwagStub : ISwag {

        private IList<SwagDTO> _swags = new List<SwagDTO>();

        public IList<SwagDTO> GetAll() {
            return _swags;
        }

        public IList<SwagDTO> GetAllBySponsor(long sponsorID) {
            return _swags;
        }
    }
}