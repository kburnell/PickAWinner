using System.Collections.Generic;
using PickAWinnerTDD.Common.DataTransferObjects;

namespace PickAWinnerTDD.Common.Interfaces.Repository {
    public interface ISwagRepository {
        IList<SwagDTO> GetAll();
        IList<SwagDTO> GetAllBySponsor(long sponsorID);
    }
}