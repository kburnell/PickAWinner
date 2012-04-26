using System.Collections.Generic;
using PickAWinnerTDD.Common.DataTransferObjects;

namespace PickAWinnerTDD.Common.Interfaces.Service {
    public interface ISwagService {
        IList<SwagDTO> GetAll();
        IList<SwagDTO> GetAllBySponsor(long sponsorID);
    }
}