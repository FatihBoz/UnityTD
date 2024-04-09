using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour , IDataPersistance
{
    public static LevelManager main;
    public static int lastUnlockedLevel = 1;

    [Header("LIST")]
    public List<Transform> path;
    public List<GameObject> enemyPrefabs;
    public List<GameObject> towers;

    [Header("PANEL")]
    public GameObject winPanel;
    public GameObject losePanel;
    public GameObject survivePanel; 

    [Header("ANOTHER")]
    public Transform spawnPoint;
    public GameObject enemyBossPrefab;
    public int totalWaveCount;



    private void Awake()
    {
        main = this;
    }


    public void LoadData(GameData gameData)
    {
        lastUnlockedLevel = gameData.lastUnlockedLevel;
    }

    public void SaveData(ref GameData gameData)
    {
        gameData.lastUnlockedLevel = lastUnlockedLevel;
    }



}
