using System;
using System.Collections.Generic;
using System.Linq;
using PickAWinnerTDD.Common.DataTransferObjects;
using PickAWinnerTDD.Common.Interfaces.Repository;
using PickAWinnerTDD.DataAccess.DBML;

namespace PickAWinnerTDD.DataAccess {

    /// <summary>
    /// Attendee Repository
    /// </summary>
    public class AttendeeRepository : IAttendeeRepository {

        public IList<AttendeeDTO> GetAll() {
            IList<AttendeeDTO> attendeeDTOList;
            using (var dc = new DayOfDotNetDataContext()) {
                attendeeDTOList = (from x in dc.Attendees
                                   select new AttendeeDTO {
                                                              AttendeeID = x.AttendeeID,
                                                              FirstName = x.FirstName,
                                                              LastName = x.LastName,
                                                              Email = x.Email,
                                                              Company = x.Company,
                                                              HasWon = x.HasWon,
                                                              IsEligible = x.IsEligible
                                                          }).ToList();
            }
            return attendeeDTOList;
        }

        public IList<AttendeeDTO> GetAllEligible() {
            IList<AttendeeDTO> attendeeDTOList;
            using (var dc = new DayOfDotNetDataContext()) {
                attendeeDTOList = (from x in dc.Attendees
                                   where x.IsEligible
                                   select new AttendeeDTO {
                                                              AttendeeID = x.AttendeeID,
                                                              FirstName = x.FirstName,
                                                              LastName = x.LastName,
                                                              Email = x.Email,
                                                              Company = x.Company,
                                                              HasWon = x.HasWon,
                                                              IsEligible = x.IsEligible
                                                          }).ToList();
            }
            return attendeeDTOList;
        }

        public bool SetHasWon(long attendeeID) {
            using (var dc = new DayOfDotNetDataContext()) {
                Attendee attendee = (from x in dc.Attendees where x.AttendeeID == attendeeID select x).FirstOrDefault();
                if (attendee == null) return false;
                attendee.HasWon = true;
                dc.SubmitChanges();
            }
            return true;
        }

        public bool ResetAllHasWon() {
            using (var dc = new DayOfDotNetDataContext()) {
                dc.ExecuteCommand("Update Attendee Set HasWon = 'false'");
            }
            return true;
        }

        public bool DeleteAll() {
            using (var dc = new DayOfDotNetDataContext()) {
                dc.ExecuteCommand("Delete from Winner");
                dc.ExecuteCommand("Delete from Attendee");
            }
            return true;
        }

        public bool InsertAll(IList<AttendeeDTO> attendeeDtos) {
            IList<Attendee> attendees = (from x in attendeeDtos select new Attendee {
                                                                                        FirstName = x.FirstName,
                                                                                        LastName = x.LastName,
                                                                                        Company = x.Company,
                                                                                        Email = x.Email,
                                                                                        HasWon = x.HasWon,
                                                                                        IsEligible = x.IsEligible
                                                                                    }).ToList();
            using (var dc = new DayOfDotNetDataContext()) {
                dc.Attendees.InsertAllOnSubmit(attendees);
                dc.SubmitChanges();
            }
            return true;
        }

    }
}