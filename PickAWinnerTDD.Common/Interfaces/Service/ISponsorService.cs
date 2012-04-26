using System.Collections.Generic;
using PickAWinnerTDD.Common.DataTransferObjects;

namespace PickAWinnerTDD.Common.Interfaces.Service {
    public interface ISponsorService {
        IList<SponsorDTO> GetAll();
        IList<SponsorDTO> GetAllThatProvidedSwag();
    }
}