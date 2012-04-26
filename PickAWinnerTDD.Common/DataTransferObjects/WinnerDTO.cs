namespace PickAWinnerTDD.Common.DataTransferObjects {

    /// <summary>
    /// Winner Data Transfer Object
    /// </summary>
    public class WinnerDTO {
        public long WinnerID { get; set; }
        public long AttendeeID { get; set; }
        public long SponsorID { get; set; }
        public long SwagID { get; set; }
        public string Name { get; set; }
    }
}