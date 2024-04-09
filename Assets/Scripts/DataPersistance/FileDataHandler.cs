using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class FileDataHandler
{
    private string dataDirPath = "";
    private string dataFileName = "";

    public FileDataHandler(string dataDirPath,string dataFileName)
    {
        this.dataDirPath = dataDirPath;
        this.dataFileName = dataFileName;
    }

    public GameData Load()
    {
        //Path.Combine for different path seperators
        string fullPath = Path.Combine(dataDirPath, dataFileName);

        GameData loadedData = null;

        if (File.Exists(fullPath))
        {
            try
            {
                //load serialized data from the file
                string dataToLoad = "";
                using (FileStream stream = new(fullPath, FileMode.Open))
                {
                    using StreamReader reader = new(stream);
                    dataToLoad = reader.ReadToEnd();
                }
                //Deserialized the data back into the object
                loadedData = JsonUtility.FromJson<GameData>(dataToLoad);


            }
            catch(Exception e)
            {
                Debug.LogError("A problem popped up when trying to save game data: " + fullPath + "\n" + e);
            }
        }

        return loadedData;
    }

    public void Save(GameData data)
    {
        //Path.Combine for different path seperators
        string fullPath = Path.Combine(dataDirPath,dataFileName);  

        try
        {
            //Create the directory if it does not already exist. File will be written to that directory.
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));

            //Serialize the game data object into Json
            string dataToStore = JsonUtility.ToJson(data,true);

            //Write the serialized data to the file
            using FileStream stream = new(fullPath, FileMode.Create);
            using StreamWriter writer = new(stream);
            writer.Write(dataToStore);

        }
        catch(Exception e)
        {
            Debug.LogError("A problem popped up when trying to save game data: "+fullPath+"\n"+e);
        }
    }

}
