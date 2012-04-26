using System;
using System.Collections.Generic;
using PickAWinnerTDD.Common;
using PickAWinnerTDD.Common.DataTransferObjects;
using PickAWinnerTDD.Common.Interfaces.Domain;
using PickAWinnerTDD.Common.Interfaces.Repository;

namespace PickAWinnerTDD.Domain {

    public class Attendee : IAttendee {

        #region << Private Fields >>
        
        private IAttendeeRepository _repository;

        #endregion

        #region << Constructors >>

        public Attendee() {
            _repository = new StructureMapDependencyResolver().GetConcreteInstanceOf<IAttendeeRepository>();
        }

        internal Attendee(IAttendeeRepository attendeeRepository) {
            _repository = attendeeRepository;
        }

        #endregion
        
        #region << Public Methods >>

        public IList<AttendeeDTO> GetAll() {
            return _repository.GetAll();
        }

        public IList<AttendeeDTO> GetAllEligible() {
            return _repository.GetAllEligible();
        }

        public bool SetHasWon(long attendeeID) {
            return _repository.SetHasWon(attendeeID);
        }

        public bool ResetAllHasWon() {
            return _repository.ResetAllHasWon();
        }

        public bool DeleteAll() {
            return _repository.DeleteAll();
        }

        public bool InsertAll(IList<AttendeeDTO> attendeeDtos) {
            return _repository.InsertAll(attendeeDtos);
        }

        #endregion

    }
}