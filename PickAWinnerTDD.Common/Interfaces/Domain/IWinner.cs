using PickAWinnerTDD.Common.DataTransferObjects;

namespace PickAWinnerTDD.Common.Interfaces.Domain {
    public interface IWinner {
        bool Insert(WinnerDTO winner);
        bool DeleteAll();
    }
}