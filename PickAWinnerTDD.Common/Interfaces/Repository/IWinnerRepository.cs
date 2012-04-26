using PickAWinnerTDD.Common.DataTransferObjects;

namespace PickAWinnerTDD.Common.Interfaces.Repository {

    /// <summary>
    /// Winner Repository
    /// </summary>
    public interface IWinnerRepository {

        bool Insert(WinnerDTO winner);
        bool DeleteAll();

    }
}