using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Text;
using System.Security.Cryptography;
using System.Data;
using Valve.Newtonsoft.Json;
using System.Text.RegularExpressions;


//using NewtonSoft.Json;




[Serializable]
public class JsonSaver
{
    
        // default filename
    private static readonly string _filename = "saveData1.sav";
    private static readonly string fileName = UserData.playerName + ".csv";

    

    // returns filename with fullpath
    public static string GetSaveFilename()
    {
        return Application.persistentDataPath + "/" + _filename;
    }

    public static string GetSaveUserFilename()
    {

       
        return Application.persistentDataPath + "/" + fileName;
    }


    // convert the SaveData to JSON format and write to disk
    public void Save(SaveData data)
    {
        // reset the hash value
        data.sessionData.hashValue = String.Empty;

        // convert the data to a JSON-formatted string
        string json = JsonUtility.ToJson(data);

        

        // generate a hash value as a hexidecimal string and store in SaveData 
        data.sessionData.hashValue = GetSHA256(json);

        // convert the data to JSON again (to add the hash string)
        json = JsonUtility.ToJson(data);

        // reference to filename with full path
        string saveFilename = GetSaveFilename();

        // create the file
        FileStream filestream = new FileStream(saveFilename, FileMode.Create);

        // open file, write to file and close file
        using (StreamWriter writer = new StreamWriter(filestream))
        {
            writer.Write(json);
        }
    }

    //aimen
    //saving user data
    public void SaveUserData(UserDataRecording data)
    {
        string saveFilename = GetSaveUserFilename();

        
        string json = JsonConvert.SerializeObject(data);
        Debug.Log("json : " + json);
       

        DataTable dt = new DataTable();
        dt = JsonStringToDataTable(json);
        ToCSV(dt, saveFilename);

    }
        // load the data from disk and overwrite the contents of SaveData object
        public bool Load(SaveData data)
        {
            // reference to filename
            string loadFilename = GetSaveFilename();

        //MonoBehaviour.print(loadFilename);
            // only run if we find the filename on disk
            if (File.Exists(loadFilename))
            {
                // open the file and prepare to read
                using (StreamReader reader = new StreamReader(loadFilename))
                {
                    // read the file as a string
                    string json = reader.ReadToEnd();

                    // verify the data using the hash value
                    if (CheckData(json))
                    {
                        // read the data and overwrite the save data if the hash is valid
                        JsonUtility.FromJsonOverwrite(json, data);
                    }
                    // hash is invalid
                    else
                    {
                        Debug.LogWarning("JSONSAVER Load: invalid hash.  Aborting file read...");
                    }
                }
                return true;
            }
            return false;
        }

        // verifies if a save file has a valid hash
        private bool CheckData(string json)
        {
            // create a temporary SaveData object to store the data
            SaveData tempSaveData = new SaveData();

            // read the data into the temp SaveData object
            JsonUtility.FromJsonOverwrite(json, tempSaveData);

            // grab the saved hash value and reset
            string oldHash = tempSaveData.sessionData.hashValue;
            tempSaveData.sessionData.hashValue = String.Empty;

            // generate a temporary JSON file with the hash reset to empty
            string tempJson = JsonUtility.ToJson(tempSaveData);

            // calculate the hash 
            string newHash = GetSHA256(tempJson);

            // return whether the old and new hash values match
            return (oldHash == newHash);
        }

        // deletes the save file from disk (useful for testing)
        public void Delete()
        {
            File.Delete(GetSaveFilename());
        }

        // converts an array of bytes into a hexidecimal string 
        public string GetHexStringFromHash(byte[] hash)
        {
            // placeholder string
            string hexString = String.Empty;

            // convert each byte to a two-digit hexidecimal number and add to placeholder
            foreach (byte b in hash)
            {
                hexString += b.ToString("x2");
            }

            // return the concatenated hexidecimal string
            return hexString;
        }
     
        // converts a string into a SHA256 hash value
        private string GetSHA256(string text)
        {
            // convert the text into an array of bytes
            byte[] textToBytes = Encoding.UTF8.GetBytes(text);

            // create a temporary SHA256Managed instance
            SHA256Managed mySHA256 = new SHA256Managed();

            // calculate the hash value as an array of bytes
            byte[] hashValue = mySHA256.ComputeHash(textToBytes);

            // convert to a hexidecimal string and return
            return GetHexStringFromHash(hashValue);
        }

    //converts and return json string to datatable 
    public DataTable JsonStringToDataTable(string jsonString)
    {
        DataTable dt = new DataTable();

        //removing unnecessary data from json and converting to an array
        string[] jsonStringArray = Regex.Split(jsonString.Replace("[", "").Replace("]", ""), "},{");
        string firstIndexValue = jsonStringArray[0];
        string[] firstindexArray = Regex.Split(firstIndexValue, "{");
        jsonStringArray[0] = firstindexArray[2];
        
        //list of column names of datatable
        List<string> ColumnsName = new List<string>();
        foreach (string jSA in jsonStringArray)
        {
            string[] jsonStringData = Regex.Split(jSA.Replace("{", "").Replace("}", ""), ",");
            foreach (string ColumnsNameData in jsonStringData)
            {
                try
                {
                    int idx = ColumnsNameData.IndexOf(":");
                    string ColumnsNameString = ColumnsNameData.Substring(0, idx - 1).Replace("\"", "");
                    if (!ColumnsName.Contains(ColumnsNameString))
                    {
                        ColumnsName.Add(ColumnsNameString);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(string.Format("Error Parsing Column Name : {0}", ColumnsNameData));
                }
            }
            break;
        }
        foreach (string AddColumnName in ColumnsName)
        {
            dt.Columns.Add(AddColumnName);
        }

        //inserting data in each datarow against columns
        foreach (string jSA in jsonStringArray)
        {
            string[] RowData = Regex.Split(jSA.Replace("{", "").Replace("}", ""), ",");
            DataRow nr = dt.NewRow();
            foreach (string rowData in RowData)
            {
                try
                {
                    int idx = rowData.IndexOf(":");
                    string RowColumns = rowData.Substring(0, idx - 1).Replace("\"", "");
                    string RowDataString = rowData.Substring(idx + 1).Replace("\"", "");
                    nr[RowColumns] = RowDataString;
                }
                catch (Exception ex)
                {
                    continue;
                }
            }
            dt.Rows.Add(nr);
        }
        return dt;
    }

    //Store datatable to csv file at specific path
    public void ToCSV(DataTable dtDataTable, string strFilePath)
    {
        StreamWriter sw = new StreamWriter(strFilePath, false);
        //headers    
        for (int i = 0; i < dtDataTable.Columns.Count; i++)
        {
            sw.Write(dtDataTable.Columns[i]);
            if (i < dtDataTable.Columns.Count - 1)
            {
                sw.Write(",");
            }
        }
        sw.Write(sw.NewLine);
        foreach (DataRow dr in dtDataTable.Rows)
        {
            for (int i = 0; i < dtDataTable.Columns.Count; i++)
            {
                if (!Convert.IsDBNull(dr[i]))
                {
                    string value = dr[i].ToString();
                    if (value.Contains(","))
                    {
                        value = String.Format("\"{0}\"", value);
                        sw.Write(value);
                    }
                    else
                    {
                        sw.Write(dr[i].ToString());
                    }
                }
                if (i < dtDataTable.Columns.Count - 1)
                {
                    sw.Write(",");
                }
            }
            sw.Write(sw.NewLine);
        }
        sw.Close();
    }

}




