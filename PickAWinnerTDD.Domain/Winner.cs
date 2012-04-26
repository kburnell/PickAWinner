using System;
using PickAWinnerTDD.Common;
using PickAWinnerTDD.Common.DataTransferObjects;
using PickAWinnerTDD.Common.Interfaces.Domain;
using PickAWinnerTDD.Common.Interfaces.Repository;

namespace PickAWinnerTDD.Domain {

    public class Winner : IWinner {

        #region << Private Fields >>
        
        private IWinnerRepository _repository;

        #endregion

        #region << Constructors >>

        public Winner() {
            _repository = new StructureMapDependencyResolver().GetConcreteInstanceOf<IWinnerRepository>();
        }

        internal Winner(IWinnerRepository repository) {
            _repository = repository;
        }

        #endregion

        public bool Insert(WinnerDTO winner) {
            return _repository.Insert(winner);
        }

        public bool DeleteAll() {
            return _repository.DeleteAll();
        }
    }
}