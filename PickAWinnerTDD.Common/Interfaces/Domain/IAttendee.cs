﻿using System.Collections.Generic;
using PickAWinnerTDD.Common.DataTransferObjects;

namespace PickAWinnerTDD.Common.Interfaces.Domain
{
    public interface IAttendee {

        IList<AttendeeDTO> GetAll();
        IList<AttendeeDTO> GetAllEligible();
        bool SetHasWon(long attendeeID);
        bool ResetAllHasWon();
        bool DeleteAll();
        bool InsertAll(IList<AttendeeDTO> attendeeDtos);

    }
}
