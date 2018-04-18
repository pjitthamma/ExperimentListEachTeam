using Agoda.Automata.DB;
using ExperimentFromDB.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace ExperimentFromDB.Controllers
{
    public class DatabaseUtils
    {
        public static List<ExperimentData> GetExperimentFromDatabase()
        {
            List<ExperimentData> experimentDataList = new List<ExperimentData>();
            try
            {
                DatabaseManager dbManager;
                string ServerName = "#####Database_Server#####";
                string DatabaseName = "#####Database_Name#####";
                string Username = "#####username#####";
                string Password = "#####password#####";

                dbManager = new DatabaseManager(ServerName, DatabaseName, Username, Password);
                dbManager.Connect();
                string sql_experiments_name = "#####Query_Script#####";

                DataTable ResultTableName = dbManager.Query(sql_experiments_name);

                if (ResultTableName != null && ResultTableName.Rows != null && ResultTableName.Rows.Count > 0)
                {
                    foreach (DataRow dtRow in ResultTableName.Rows)
                    {
                        experimentDataList.Add(new ExperimentData(dtRow["team_name"].ToString(), (int)dtRow["team_id"], dtRow["experiment_name"].ToString(), (int)dtRow["experiment_id"], (int)dtRow["experiment_run_id"], dtRow["description"].ToString(), dtRow["startdate"].ToString()));
                    }
                }

            }
            catch (Exception)
            {
                throw;
            }

            return experimentDataList;
        }
    }
}