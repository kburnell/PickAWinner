using System.Collections.Generic;
using PickAWinnerTDD.Common;
using PickAWinnerTDD.Common.DataTransferObjects;
using PickAWinnerTDD.Common.Interfaces.Domain;
using PickAWinnerTDD.Common.Interfaces.Service;

namespace PickAWinnerTDD.Service {

    public class AttendeeService : IAttendeeService {

        #region << Private Fields >>

        private readonly IAttendee _attendee;

        #endregion

        #region << Constructors >>

        public AttendeeService() {
            _attendee = new StructureMapDependencyResolver().GetConcreteInstanceOf<IAttendee>();
        }

        internal AttendeeService(IAttendee attendee) {
            _attendee = attendee;
        }

        #endregion

        #region IAttendeeService Members

        public IList<AttendeeDTO> GetAll() {
            return _attendee.GetAll();
        }

        public IList<AttendeeDTO> GetAllEligible() {
            return _attendee.GetAllEligible();
        }

        public bool SetHasWon(long attendeeID) {
            return _attendee.SetHasWon(attendeeID);
        }

        public bool ResetAllHasWon() {
            return _attendee.ResetAllHasWon();
        }

        public bool DeleteAll() {
            return _attendee.DeleteAll();
        }

        public bool InsertAll(IList<AttendeeDTO> attendeeDtos) {
            return _attendee.InsertAll(attendeeDtos);
        }

        #endregion
    }
}