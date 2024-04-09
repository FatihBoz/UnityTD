using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Heart : MonoBehaviour
{
    [SerializeField] private int maxHeartCount;
    [SerializeField] private TextMeshProUGUI heartText;

    int currentHeartCount;

    private void Start()
    {
        currentHeartCount = maxHeartCount;
        heartText.text = currentHeartCount.ToString();
    }

    public void EnemyPassed(GameObject enemy)
    {
        if (PauseMenu.instance.isPaused)
        {
            return;
        }

        if (enemy.CompareTag("boss"))
        {
            currentHeartCount = 1;
        }

        currentHeartCount--;
        heartText.text = currentHeartCount.ToString();

        if(IsFinished())
        {
            PauseMenu.instance.PauseGame();
            LevelManager.main.survivePanel.SetActive(true);
        }
    }

    public bool IsFinished()
    {
        return currentHeartCount <= 0;
    }

    public void LevelFailed()
    {
        LevelManager.main.survivePanel.SetActive(false);
        LevelManager.main.losePanel.SetActive(true);
        PauseMenu.instance.PauseGame();
    }

    public void IncreaseHeartCountByAd()
    {
        currentHeartCount += 2;
        heartText.text = currentHeartCount.ToString();
    }

}
