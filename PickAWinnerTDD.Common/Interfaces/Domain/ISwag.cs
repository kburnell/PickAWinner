using System.Collections.Generic;
using PickAWinnerTDD.Common.DataTransferObjects;

namespace PickAWinnerTDD.Common.Interfaces.Domain {
    public interface ISwag {
        IList<SwagDTO> GetAll();
        IList<SwagDTO> GetAllBySponsor(long sponsorID);
    }
}