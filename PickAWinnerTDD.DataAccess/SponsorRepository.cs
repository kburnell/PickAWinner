using System.Collections.Generic;
using System.Linq;
using PickAWinnerTDD.Common.DataTransferObjects;
using PickAWinnerTDD.Common.Interfaces.Repository;
using PickAWinnerTDD.DataAccess.DBML;

namespace PickAWinnerTDD.DataAccess {

    /// <summary>
    /// Attendee Repository
    /// </summary>
    public class SponsorRepository : ISponsorRepository {

        #region Implementation of ISponsorRepository

        public IList<SponsorDTO> GetAll() {
            IList<SponsorDTO> sponsors;
            using (var dc = new DayOfDotNetDataContext()) {
                sponsors = (from x in dc.Sponsors
                            select new SponsorDTO {
                                                      SponsorID = x.SponsorID,
                                                      Name = x.Name,
                                                      ContactName = x.ContactName,
                                                      ContactEmail = x.ContactEmail,
                                                      SponsorshipLevel = x.SponsorshipLevel,
                                                      ImageLocation = x.ImageLocation,
                                                      Position = x.Position,
                                                      ProvidedSwag = x.ProvidedSwag
                                                  }).ToList();
            }
            return sponsors;
        }

        /// <summary>
        /// Gets All Sponsors That Provided Swag
        /// </summary>
        /// <returns></returns>
        public IList<SponsorDTO> GetAllThatProvidedSwag() {
            IList<SponsorDTO> sponsors;
            using (var dc = new DayOfDotNetDataContext()) {
                sponsors = (from x in dc.Sponsors
                            where x.ProvidedSwag
                            select new SponsorDTO {
                                                      SponsorID = x.SponsorID,
                                                      Name = x.Name,
                                                      ContactName = x.ContactName,
                                                      ContactEmail = x.ContactEmail,
                                                      SponsorshipLevel = x.SponsorshipLevel,
                                                      ImageLocation = x.ImageLocation,
                                                      Position = x.Position,
                                                      ProvidedSwag = x.ProvidedSwag
                                                  }).ToList();
            }
            return sponsors;
        }

        #endregion
    }
}