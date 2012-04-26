using System;
using System.Collections.Generic;
using PickAWinnerTDD.Common.DataTransferObjects;
using PickAWinnerTDD.Common.Interfaces.Domain;

namespace PickAWinnerTDD.UnitTesting.Stubs.Domain {

    public class AttendeeStub : IAttendee {

        private IList<AttendeeDTO> _attendees = new List<AttendeeDTO>();

        public IList<AttendeeDTO> GetAll() {
            return _attendees;
        }

        public IList<AttendeeDTO> GetAllEligible() {
            return _attendees;
        }

        public bool SetHasWon(long attendeeID) {
            return true;
        }

        public bool ResetAllHasWon() {
            return true;
        }

        public bool DeleteAll() {
            return true;
        }

        public bool InsertAll(IList<AttendeeDTO> attendeeDtos) {
            return true;
        }
    }
}