using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DataPersistanceManager : MonoBehaviour 
{
    [SerializeField] private string fileName;

    private GameData gameData;
    public static DataPersistanceManager Instance { get; private set; }

    private List<IDataPersistance> dataPersistanceObjects;

    private FileDataHandler fileDataHandler;

    private bool dataLoaded = false;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
        Instance = this;
    }


    private void Start()
    {
        fileDataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
        dataPersistanceObjects = FindAllDataPersistanceObjects();
        if (!dataLoaded)
        {
            LoadGame();
            dataLoaded = true;
        }
        
    }


    public void NewGame()
    {
        this.gameData = new GameData();
    }

    public void SaveGame()
    {
        if(dataPersistanceObjects != null)
        {
            foreach (IDataPersistance dataPersistanceObj in dataPersistanceObjects)
            {
                dataPersistanceObj.SaveData(ref gameData);
            }
            fileDataHandler.Save(gameData);
        }
            
    }

    public void LoadGame()
    {
        
        gameData = fileDataHandler.Load();
        
        if (gameData == null)
        {
            print("buraya girmemesi lazým gibi");   
            NewGame();
        }

        
        foreach (IDataPersistance dataPersistanceObj in dataPersistanceObjects)
        {
            
            dataPersistanceObj.LoadData(gameData);
        }
    }



    private List<IDataPersistance> FindAllDataPersistanceObjects()
    {
        IEnumerable<IDataPersistance> dataPersistanceObjects = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistance>();

        return new List<IDataPersistance>(dataPersistanceObjects);
    }

    private void OnApplicationPause()
    {
        SaveGame();
        print("OnApplicationPause");
    }

    private void OnApplicationQuit()
    {
        SaveGame();
        print("OnApplicationQuit");
    }
}
