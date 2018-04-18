using ExperimentFromDB.Models;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace ExperimentFromDB.Controllers
{
    class MappingUtils
    {
        public static List<ExperimentDataWithMapping> MappingTeamName(List<ExperimentData> dbData)
        {
            var experimentDataWithTeamMapping = new List<ExperimentDataWithMapping>();

            for (int i = 0; i < dbData.Count; i++)
            {
                var data = new ExperimentDataWithMapping();
                experimentDataWithTeamMapping.Add(data);

                //Calculate Lifetime
                string[] formats = {"MM/dd/yyyy","M/d/yyyy"};

                if (dbData[i].StartDate != string.Empty)
                {
                    string[] fullDate = dbData[i].StartDate.Split(' ');
                    string dateOnly = fullDate[0];
                    string starDate = DateTime.ParseExact(dateOnly, formats, CultureInfo.InvariantCulture, DateTimeStyles.None).ToString("MM/dd/yyyy");
                    string endDate = DateTime.Now.ToString("MM/dd/yyyy");
                    DateTime StartDate = DateTime.ParseExact(starDate, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                    DateTime EndDate = DateTime.ParseExact(endDate, "MM/dd/yyyy", CultureInfo.InvariantCulture);

                    double TotalDay = (EndDate - StartDate).TotalDays;
                    experimentDataWithTeamMapping[i].LifeTime = TotalDay.ToString() + " Days";
                }
                else
                {
                    experimentDataWithTeamMapping[i].LifeTime = "";
                }
                //
                
                //Catagorize teams
                if (dbData[i].TeamID == 34 || dbData[i].TeamID == 40 || dbData[i].TeamID == 41 || dbData[i].TeamID == 46 || dbData[i].TeamID == 49 || dbData[i].TeamID == 50 || dbData[i].TeamID == 52 ||
                    dbData[i].TeamID == 54 || dbData[i].TeamID == 55 || dbData[i].TeamID == 56 || dbData[i].TeamID == 2 || dbData[i].TeamID == 32 || dbData[i].TeamID == 33 || dbData[i].TeamID == 59 || dbData[i].TeamID == 61 || dbData[i].TeamID == 62)
                {
                    experimentDataWithTeamMapping[i].TeamGroup = "Apps";
                    experimentDataWithTeamMapping[i].TeamID = dbData[i].TeamID;
                    experimentDataWithTeamMapping[i].TeamName = dbData[i].TeamName;
                    experimentDataWithTeamMapping[i].ExperimentName = dbData[i].ExperimentName;
                    experimentDataWithTeamMapping[i].ExperimentID = dbData[i].ExperimentID;
                    experimentDataWithTeamMapping[i].ExperimentRunID = dbData[i].ExperimentRunID;
                    experimentDataWithTeamMapping[i].Description = dbData[i].Description;
                    experimentDataWithTeamMapping[i].StartDate = dbData[i].StartDate;

                    if (dbData[i].ExperimentName == null || dbData[i].ExperimentName == "")
                    {
                        experimentDataWithTeamMapping[i].IsNull = 0;
                    }
                    else
                    {
                        experimentDataWithTeamMapping[i].IsNull = 1;
                    }
                }
                else if (dbData[i].TeamID == 58 || dbData[i].TeamID == 36 || dbData[i].TeamID == 45 || dbData[i].TeamID == 47 || dbData[i].TeamID == 53 || dbData[i].TeamID == 5 || dbData[i].TeamID == 9 ||
                    dbData[i].TeamID == 11 || dbData[i].TeamID == 12 || dbData[i].TeamID == 15 || dbData[i].TeamID == 20 || dbData[i].TeamID == 21 || dbData[i].TeamID == 24 || dbData[i].TeamID == 25 || dbData[i].TeamID == 31)
                {
                    experimentDataWithTeamMapping[i].TeamGroup = "Back-End";
                    experimentDataWithTeamMapping[i].TeamID = dbData[i].TeamID;
                    experimentDataWithTeamMapping[i].TeamName = dbData[i].TeamName;
                    experimentDataWithTeamMapping[i].ExperimentName = dbData[i].ExperimentName;
                    experimentDataWithTeamMapping[i].ExperimentID = dbData[i].ExperimentID;
                    experimentDataWithTeamMapping[i].ExperimentRunID = dbData[i].ExperimentRunID;
                    experimentDataWithTeamMapping[i].Description = dbData[i].Description;
                    experimentDataWithTeamMapping[i].StartDate = dbData[i].StartDate;

                    if (dbData[i].ExperimentName == null || dbData[i].ExperimentName == "")
                    {
                        experimentDataWithTeamMapping[i].IsNull = 0;
                    }
                    else
                    {
                        experimentDataWithTeamMapping[i].IsNull = 1;
                    }
                }
                else if (dbData[i].TeamID == 18 || dbData[i].TeamID == 26 || dbData[i].TeamID == 28 || dbData[i].TeamID == 29)
                {
                    experimentDataWithTeamMapping[i].TeamGroup = "Content";
                    experimentDataWithTeamMapping[i].TeamID = dbData[i].TeamID;
                    experimentDataWithTeamMapping[i].TeamName = dbData[i].TeamName;
                    experimentDataWithTeamMapping[i].ExperimentName = dbData[i].ExperimentName;
                    experimentDataWithTeamMapping[i].ExperimentID = dbData[i].ExperimentID;
                    experimentDataWithTeamMapping[i].ExperimentRunID = dbData[i].ExperimentRunID;
                    experimentDataWithTeamMapping[i].Description = dbData[i].Description;
                    experimentDataWithTeamMapping[i].StartDate = dbData[i].StartDate;

                    if (dbData[i].ExperimentName == null || dbData[i].ExperimentName == "")
                    {
                        experimentDataWithTeamMapping[i].IsNull = 0;
                    }
                    else
                    {
                        experimentDataWithTeamMapping[i].IsNull = 1;
                    }
                }
                else if (dbData[i].TeamID == 16 || dbData[i].TeamID == 63)
                {
                    experimentDataWithTeamMapping[i].TeamGroup = "Others";
                    experimentDataWithTeamMapping[i].TeamID = dbData[i].TeamID;
                    experimentDataWithTeamMapping[i].TeamName = dbData[i].TeamName;
                    experimentDataWithTeamMapping[i].ExperimentName = dbData[i].ExperimentName;
                    experimentDataWithTeamMapping[i].ExperimentID = dbData[i].ExperimentID;
                    experimentDataWithTeamMapping[i].ExperimentRunID = dbData[i].ExperimentRunID;
                    experimentDataWithTeamMapping[i].Description = dbData[i].Description;
                    experimentDataWithTeamMapping[i].StartDate = dbData[i].StartDate;

                    if (dbData[i].ExperimentName == null || dbData[i].ExperimentName == "")
                    {
                        experimentDataWithTeamMapping[i].IsNull = 0;
                    }
                    else
                    {
                        experimentDataWithTeamMapping[i].IsNull = 1;
                    }
                }
                else
                {
                    experimentDataWithTeamMapping[i].TeamGroup = "Front-End";
                    experimentDataWithTeamMapping[i].TeamID = dbData[i].TeamID;
                    experimentDataWithTeamMapping[i].TeamName = dbData[i].TeamName;
                    experimentDataWithTeamMapping[i].ExperimentName = dbData[i].ExperimentName;
                    experimentDataWithTeamMapping[i].ExperimentID = dbData[i].ExperimentID;
                    experimentDataWithTeamMapping[i].ExperimentRunID = dbData[i].ExperimentRunID;
                    experimentDataWithTeamMapping[i].Description = dbData[i].Description;
                    experimentDataWithTeamMapping[i].StartDate = dbData[i].StartDate;

                    if (dbData[i].ExperimentName == null || dbData[i].ExperimentName == "")
                    {
                        experimentDataWithTeamMapping[i].IsNull = 0;
                    }
                    else
                    {
                        experimentDataWithTeamMapping[i].IsNull = 1;
                    }
                }
            }

            return experimentDataWithTeamMapping;
        }
    }
}
