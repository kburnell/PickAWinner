using System.Collections.Generic;
using PickAWinnerTDD.Common;
using PickAWinnerTDD.Common.DataTransferObjects;
using PickAWinnerTDD.Common.Interfaces.Domain;
using PickAWinnerTDD.Common.Interfaces.Repository;

namespace PickAWinnerTDD.Domain {

    public class Swag : ISwag {

        #region << Private Fields >>
        
        private ISwagRepository _repository;

        #endregion

        #region << Constructors >>

        public Swag() {
            _repository = new StructureMapDependencyResolver().GetConcreteInstanceOf<ISwagRepository>();
        }

        internal Swag(ISwagRepository repository) {
            _repository = repository;
        }

        #endregion

        public IList<SwagDTO> GetAll() {
            return _repository.GetAll();
        }

        public IList<SwagDTO> GetAllBySponsor(long sponsorID) {
            return _repository.GetAllBySponsor(sponsorID);
        }
    }
}