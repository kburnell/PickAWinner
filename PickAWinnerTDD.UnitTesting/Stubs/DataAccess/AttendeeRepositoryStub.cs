using System;
using System.Collections.Generic;
using PickAWinnerTDD.Common.DataTransferObjects;
using PickAWinnerTDD.Common.Interfaces.Repository;

namespace PickAWinnerTDD.UnitTesting.Stubs.DataAccess {

    public class AttendeeRepositoryStub : IAttendeeRepository {

        IList<AttendeeDTO> _attendeeDtos = new List<AttendeeDTO>();

        public IList<AttendeeDTO> GetAll() {
            return _attendeeDtos;
        }

        public IList<AttendeeDTO> GetAllEligible() {
            return _attendeeDtos;
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