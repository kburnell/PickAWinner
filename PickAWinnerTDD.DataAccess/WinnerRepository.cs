using PickAWinnerTDD.Common.DataTransferObjects;
using PickAWinnerTDD.Common.Interfaces.Repository;
using PickAWinnerTDD.DataAccess.DBML;

namespace PickAWinnerTDD.DataAccess {

    public class WinnerRepository : IWinnerRepository {

        #region Implementation of IWinnerRepository

        public bool Insert(WinnerDTO winner) {
            Winner w = new Winner {AttendeeID = winner.AttendeeID, SponsorID = winner.SponsorID, SwagID = winner.SwagID, Name = winner.Name};
            using (DayOfDotNetDataContext dc = new DayOfDotNetDataContext()) {
                dc.Winners.InsertOnSubmit(w);
                dc.SubmitChanges();
            }
            return true;
        }

        public bool DeleteAll() {
            using (DayOfDotNetDataContext dc = new DayOfDotNetDataContext()) {
                dc.ExecuteCommand("Delete from Winner");
            }
            return true;
        }

        #endregion
    }
}