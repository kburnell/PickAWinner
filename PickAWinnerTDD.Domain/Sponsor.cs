using System.Collections.Generic;
using PickAWinnerTDD.Common;
using PickAWinnerTDD.Common.DataTransferObjects;
using PickAWinnerTDD.Common.Interfaces.Domain;
using PickAWinnerTDD.Common.Interfaces.Repository;

namespace PickAWinnerTDD.Domain {
    public class Sponsor : ISponsor {

        #region << Private Fields >>
        
        private ISponsorRepository _repository;

        #endregion

        #region << Constructors >>

        public Sponsor() {
            _repository = new StructureMapDependencyResolver().GetConcreteInstanceOf<ISponsorRepository>();
        }

        internal Sponsor(ISponsorRepository repository) {
            _repository = repository;
        }

        #endregion

        public IList<SponsorDTO> GetAll() {
            return _repository.GetAll();
        }

        public IList<SponsorDTO> GetAllThatProvidedSwag() {
            return _repository.GetAllThatProvidedSwag();
        }
    }
}