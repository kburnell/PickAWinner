using PickAWinnerTDD.Common.DataTransferObjects;

namespace PickAWinnerTDD.Common.Interfaces.Service {
    public interface IWinnerService {
        bool Insert(WinnerDTO winner);
        bool DeleteAll();
    }
}