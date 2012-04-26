using PickAWinnerTDD.Common.DataTransferObjects;
using PickAWinnerTDD.Common.Interfaces.Repository;

namespace PickAWinnerTDD.UnitTesting.Stubs.DataAccess {

    public class WinnerRepositoryStub : IWinnerRepository {

        public bool Insert(WinnerDTO winner) {
            return true;
        }

        public bool DeleteAll() {
            return true;
        }
    }
}