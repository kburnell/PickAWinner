namespace PickAWinnerTDD.Common.DataTransferObjects {

    /// <summary>
    /// Sponsor Data Transfer Object
    /// </summary>
    public class SponsorDTO {

        public long SponsorID { get; set; }
        public string Name { get; set; }
        public string ContactName { get; set; }
        public string ContactEmail { get; set; }
        public string SponsorshipLevel { get; set; }
        public string ImageLocation { get; set; }
        public bool ProvidedSwag { get; set; }
        public int Position { get; set; }
        
    }
}