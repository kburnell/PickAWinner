using System.Collections.Generic;
using PickAWinnerTDD.Common.DataTransferObjects;
using PickAWinnerTDD.Common.Interfaces.Domain;

namespace PickAWinnerTDD.UnitTesting.Stubs.Domain {

    public class SponsorStub : ISponsor {

        private IList<SponsorDTO> _sponsors = new List<SponsorDTO>();

        public IList<SponsorDTO> GetAll() {
            return _sponsors;
        }

        public IList<SponsorDTO> GetAllThatProvidedSwag() {
            return _sponsors;
        }

    }
}