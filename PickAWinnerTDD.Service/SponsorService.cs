using System.Collections.Generic;
using PickAWinnerTDD.Common;
using PickAWinnerTDD.Common.DataTransferObjects;
using PickAWinnerTDD.Common.Interfaces.Domain;
using PickAWinnerTDD.Common.Interfaces.Service;

namespace PickAWinnerTDD.Service {

    public class SponsorService : ISponsorService {

        #region << Private Fields >>
        
        private ISponsor _sponsor;

        #endregion

        #region << Constructors >>

        public SponsorService() {
            _sponsor = new StructureMapDependencyResolver().GetConcreteInstanceOf<ISponsor>();
        }

        internal SponsorService(ISponsor sponsor) {
            _sponsor = sponsor;
        }

        #endregion

        public IList<SponsorDTO> GetAll() {
            return _sponsor.GetAll();
        }

        public IList<SponsorDTO> GetAllThatProvidedSwag() {
            return _sponsor.GetAllThatProvidedSwag();
        }

    }
}