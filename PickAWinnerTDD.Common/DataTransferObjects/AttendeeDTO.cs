namespace PickAWinnerTDD.Common.DataTransferObjects {

    /// <summary>
    /// Attendee Data Transfer Object
    /// </summary>
    public class AttendeeDTO {

        public long AttendeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Company { get; set; }
        public bool HasWon { get; set; }
        public bool IsEligible { get; set; } 
        
    }
}