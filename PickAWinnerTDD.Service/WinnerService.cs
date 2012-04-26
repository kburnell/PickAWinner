using System;
using PickAWinnerTDD.Common;
using PickAWinnerTDD.Common.DataTransferObjects;
using PickAWinnerTDD.Common.Interfaces.Domain;
using PickAWinnerTDD.Common.Interfaces.Service;

namespace PickAWinnerTDD.Service {
    public class WinnerService : IWinnerService {

        #region << Private Fields >>

        private readonly IWinner _winner;

        #endregion

        #region << Constructors >>

        public WinnerService() {
            _winner = new StructureMapDependencyResolver().GetConcreteInstanceOf<IWinner>();
        }

        internal WinnerService(IWinner winner) {
            _winner = winner;
        }

        #endregion

        public bool Insert(WinnerDTO winner) {
            return _winner.Insert(winner);
        }

        public bool DeleteAll() {
            return _winner.DeleteAll();
        }
    }
}