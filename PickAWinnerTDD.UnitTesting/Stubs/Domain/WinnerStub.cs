using PickAWinnerTDD.Common.DataTransferObjects;
using PickAWinnerTDD.Common.Interfaces.Domain;

namespace PickAWinnerTDD.UnitTesting.Stubs.Domain {
    public class WinnerStub : IWinner {

        public bool Insert(WinnerDTO winner) {
            return true;
        }

        public bool DeleteAll() {
            return true;
        }
    }
}