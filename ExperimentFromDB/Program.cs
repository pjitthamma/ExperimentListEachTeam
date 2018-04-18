using ExperimentFromDB.Controllers;
using ExperimentFromDB.Models;
using System.Collections.Generic;

namespace ExperimentFromDB
{
    class Program
    {
        static void Main(string[] args)
        {
            JsonConvert jsonFile = new JsonConvert();

            List<ExperimentData> experimentDataList = DatabaseUtils.GetExperimentFromDatabase();
            List<ExperimentDataWithMapping> experimentDataListWithTeamGroup = MappingUtils.MappingTeamName(experimentDataList);

            jsonFile.ConvertToJson(experimentDataListWithTeamGroup);
        }
    }
}
