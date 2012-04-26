using System.Collections.Generic;
using PickAWinnerTDD.Common.DataTransferObjects;

namespace PickAWinnerTDD.Common.Interfaces.Domain {
    public interface ISponsor {
        IList<SponsorDTO> GetAll();
        IList<SponsorDTO> GetAllThatProvidedSwag();
    }
}