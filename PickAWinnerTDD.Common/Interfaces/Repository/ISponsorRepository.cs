using System.Collections.Generic;
using PickAWinnerTDD.Common.DataTransferObjects;

namespace PickAWinnerTDD.Common.Interfaces.Repository {

    /// <summary>
    /// Sponso Repository Methods Interface
    /// </summary>
    public interface ISponsorRepository {

        IList<SponsorDTO> GetAll();
        IList<SponsorDTO> GetAllThatProvidedSwag();

    }
}