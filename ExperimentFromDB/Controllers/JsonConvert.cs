using ExperimentFromDB.Models;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.IO;

namespace ExperimentFromDB.Controllers
{
    class JsonConvert
    {
        public void ConvertToJson(List<ExperimentDataWithMapping> data)
        {
            var serializer = new JavaScriptSerializer();
            var serializedResult = serializer.Serialize(data);

            WriteFile(serializedResult);
        }

        public void WriteFile(string serializedResult)
        {
            string strFilePathMain = "#####File_Path#####";

            if (File.Exists(strFilePathMain))
            {
                File.Delete(strFilePathMain);
            }
        
            { // Consider File Operation 1
                FileStream fs1 = new FileStream(strFilePathMain, FileMode.OpenOrCreate);
                StreamWriter str1 = new StreamWriter(fs1);
                str1.BaseStream.Seek(0, SeekOrigin.End);
                str1.Write(serializedResult);
                str1.Flush();
                str1.Close();
                fs1.Close();
                // Close the Stream then Individually you can access the file.
            }
        }
    }
}
