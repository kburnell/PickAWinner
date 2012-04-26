using System.Collections.Generic;
using PickAWinnerTDD.Common.DataTransferObjects;
using PickAWinnerTDD.Common.Interfaces.Repository;

namespace PickAWinnerTDD.UnitTesting.Stubs.DataAccess {

    public class SponsorRepositoryStub : ISponsorRepository {

        IList<SponsorDTO> _sponsorDtos = new List<SponsorDTO>();

        public IList<SponsorDTO> GetAll() {
            return _sponsorDtos;
        }

        public IList<SponsorDTO> GetAllThatProvidedSwag() {
            return _sponsorDtos;
        }

    }
}