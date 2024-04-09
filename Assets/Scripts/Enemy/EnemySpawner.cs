using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    #region[SerializeField]
    [Header("FLOATS")]
    [SerializeField]private float timeBetweenEnemies;
    [SerializeField]private float timeBetweenWaves;

    [Header("TEXT")]
    [SerializeField]private TextMeshProUGUI currentWaveCount;
    [SerializeField] private TextMeshProUGUI timeToStartUI;

    [Header("GAMEOBJECT")]
    [SerializeField] private GameObject timeCounterPanel;
    [SerializeField]private GameObject startWaveButton;
    [SerializeField] private GameObject winPanel;
    #endregion

    #region PRIVATE VARIABLES
    private float timeLeftToNextWave;
    private float timeLeftToNextEnemy = 0;
    private bool isSpawning;
    private int currentWave = 1;
    private int enemiesLeftToSpawn;
    #endregion

    private void Start()
    {
        timeLeftToNextWave = timeBetweenWaves;
        timeToStartUI.text = timeBetweenWaves.ToString();
    }

    private void Update()
    {
      
        if (!isSpawning)
        {
            if (timeLeftToNextWave <= 0)
            {
                StartWave();
            }
            else
            {
                CountTimeToNextWave();
            }
        }
        else
        {
            timeLeftToNextEnemy += Time.deltaTime;

            if (timeLeftToNextEnemy >= timeBetweenEnemies && enemiesLeftToSpawn > 0)
            {
                SpawnEnemy();
            }

            else if(enemiesLeftToSpawn == 0 && currentWave < LevelManager.main.totalWaveCount)
            {
                NextWave();
            }
            
        }
    }


    public void StartWaveImmediately()
    {
        timeLeftToNextWave = 0;

        startWaveButton.SetActive(false);

    }

    private void StartWave()
    {
        isSpawning = true;

        timeCounterPanel.SetActive(false);

        startWaveButton.SetActive(false);

        timeLeftToNextWave = timeBetweenWaves;

        if (currentWave >= LevelManager.main.totalWaveCount)
        {
            enemiesLeftToSpawn = 1;
        }
        else
        {
            enemiesLeftToSpawn = EnemyCountPerWave();
        }
    }



    void NextWave()
    {
        if (currentWave >= LevelManager.main.totalWaveCount)
        {
            return;
        }

        isSpawning = false;

        timeCounterPanel.SetActive(true);

        startWaveButton.SetActive(true);

        currentWave++;

        currentWaveCount.text = currentWave.ToString();
    }



    private void SpawnEnemy()
    {
        GameObject enemyPrefab;

        if (currentWave >= LevelManager.main.totalWaveCount)
        {
            enemyPrefab = LevelManager.main.enemyBossPrefab;
        }
        else if (currentWave >= LevelManager.main.totalWaveCount / 2 && LevelManager.main.enemyPrefabs.Count >= 2)
        {
             enemyPrefab = LevelManager.main.enemyPrefabs[1];
        }
        else
        {
            enemyPrefab = LevelManager.main.enemyPrefabs[0];
        }


        Instantiate(enemyPrefab, LevelManager.main.spawnPoint.position, Quaternion.identity);

        enemiesLeftToSpawn--;

        timeLeftToNextEnemy = 0;
    }


    void CountTimeToNextWave()
    {
        timeLeftToNextWave -= Time.deltaTime;

        timeToStartUI.text = Mathf.RoundToInt(timeLeftToNextWave).ToString();
    }


    private int EnemyCountPerWave()
    {
        return Mathf.RoundToInt(Mathf.Pow(currentWave, 0.75f) * 7f);
    }


}
