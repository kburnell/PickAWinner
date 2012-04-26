using System.Collections.Generic;
using PickAWinnerTDD.Common.DataTransferObjects;
using PickAWinnerTDD.Common.Interfaces.Repository;

namespace PickAWinnerTDD.Domain.Tests.Unit.Stubing.Stubs.Repository {

    public class SwagRepositoryStub : ISwagRepository {

        IList<SwagDTO> _swagDtos = new List<SwagDTO>();

        public IList<SwagDTO> GetAll() {
            return _swagDtos;
        }

        public IList<SwagDTO> GetAllBySponsor(long sponsorID) {
            return _swagDtos;
        }

    }
}