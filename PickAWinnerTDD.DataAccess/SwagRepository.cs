using System.Collections.Generic;
using System.Linq;
using PickAWinnerTDD.Common.DataTransferObjects;
using PickAWinnerTDD.Common.Interfaces.Repository;
using PickAWinnerTDD.DataAccess.DBML;

namespace PickAWinnerTDD.DataAccess {

    public class SwagRepository : ISwagRepository {

        #region Implementation of ISwagRepository

        public IList<SwagDTO> GetAll() {
            IList<SwagDTO> swags;
            using (var dc = new DayOfDotNetDataContext())
            {
                swags = (from x in dc.Swags
                            select new SwagDTO
                            {
                                SwagID = x.SwagID,
                                SponsorID = x.SponsorID,
                                Name = x.Name,
                                ImageLocation = x.ImageLocation,
                                Position = x.Position
                            }).ToList();
            }
            return swags;
        }

        public IList<SwagDTO> GetAllBySponsor(long sponsorID) {
            IList<SwagDTO> swags;
            using (var dc = new DayOfDotNetDataContext())
            {
                swags = (from x in dc.Swags
                         where x.SponsorID == sponsorID
                         select new SwagDTO
                         {
                             SwagID = x.SwagID,
                             SponsorID = x.SponsorID,
                             Name = x.Name,
                             ImageLocation = x.ImageLocation,
                             Position = x.Position
                         }).ToList();
            }
            return swags;
        }

        #endregion
    }
}