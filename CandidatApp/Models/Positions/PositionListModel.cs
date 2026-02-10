namespace CandidatApp.Models.Positions
{
    public class PositionListModel
    {
        public string Name { get; set; }
        public DateOnly? DatePosted { get; set; }
        public string Status { get; set; }
        public int NumberOfApplications { get; set; }
    }
}
