using System;
using System.Collections.Generic;
using PickAWinnerTDD.Common;
using PickAWinnerTDD.Common.DataTransferObjects;
using PickAWinnerTDD.Common.Interfaces.Domain;
using PickAWinnerTDD.Common.Interfaces.Service;

namespace PickAWinnerTDD.Service {
    public class SwagService : ISwagService {

        #region << Private Fields >>

        private readonly ISwag _swag;

        #endregion

        #region << Constructors >>

        public SwagService() {
            _swag = new StructureMapDependencyResolver().GetConcreteInstanceOf<ISwag>();
        }

        internal SwagService(ISwag swag) {
            _swag = swag;
        }

        #endregion

        public IList<SwagDTO> GetAll() {
            return _swag.GetAll();
        }

        public IList<SwagDTO> GetAllBySponsor(long sponsorID) {
            return _swag.GetAllBySponsor(sponsorID);
        }
    }
}