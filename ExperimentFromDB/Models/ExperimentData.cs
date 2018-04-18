namespace ExperimentFromDB.Models
{
    public class ExperimentData
    {
        public string TeamName { get; set; }
        public int TeamID { get; set; }
        public string ExperimentName { get; set; }
        public int ExperimentID { get; set; }
        public int ExperimentRunID { get; set; }
        public string Description { get; set; }
        public string StartDate { get; set; }

        public ExperimentData(string teamName, int teamID, string experimentName, int experimentID, int experimentRunID, string description, string startDate)
        {
            this.TeamName = teamName;
            this.TeamID = teamID;
            this.ExperimentName = experimentName;
            this.ExperimentID = experimentID;
            this.ExperimentRunID = experimentRunID;
            this.Description = description;
            this.StartDate = startDate;
        }
    }
}