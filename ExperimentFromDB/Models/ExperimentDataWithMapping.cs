namespace ExperimentFromDB.Models
{
    public class ExperimentDataWithMapping
    {
        public string TeamName { get; set; }
        public int TeamID { get; set; }
        public string ExperimentName { get; set; }
        public int ExperimentID { get; set; }
        public int ExperimentRunID { get; set; }
        public string Description { get; set; }
        public string StartDate { get; set; }
        public string TeamGroup { get; set; }
        public int IsNull { get; set; }
        public string LifeTime { get; set; }

        public ExperimentDataWithMapping() { }

        public ExperimentDataWithMapping(string teamName, int teamID, string experimentName, int experimentID, int experimentRunID, string description, string startDate, string teamGroup, int isNull, string lifeTime)
        {
            this.TeamName = teamName;
            this.TeamID = teamID;
            this.ExperimentName = experimentName;
            this.ExperimentID = experimentID;
            this.ExperimentRunID = experimentRunID;
            this.Description = description;
            this.StartDate = startDate;
            this.TeamGroup = teamGroup;
            this.IsNull = isNull;
            this.LifeTime = lifeTime;
        }
    }
}