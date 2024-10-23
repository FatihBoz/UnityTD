using System;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAttributes : MonoBehaviour
{
    public static Action<GameObject> OnEnemyDied;

    #region PUBLIC
    public float MS;
    public float maxHP;
    public float hpPowerScale;
    public float speedPowerScale;
    #endregion

    #region [SerializeField]
    [SerializeField] private Image img;
    [SerializeField] private Vector3 offSet;
    [SerializeField] private GameObject dieEffect;
    [SerializeField] private int goldGainedFromEnemy;
    #endregion

    #region PRIVATE

    private float currentHP;
    #endregion


    private void OnEnable()
    {
        SetDifficultyLevel();
        currentHP = maxHP;
        img.gameObject.SetActive(false); //Make health bar invisible
        RefreshHealthBar(maxHP,currentHP);

    }

    private void RefreshHealthBar(float maxHp , float currentHp)
    {
        img.fillAmount = currentHp / maxHp; 
    }


    public void TakeDamage(float dmgAmount)
    {
        if (currentHP == maxHP)
        {
            img.gameObject.SetActive(true);
        }

        currentHP -= dmgAmount;

        if (currentHP <= 0)
        {
            Currency.OnInGameCoinCollected?.Invoke(goldGainedFromEnemy);

            Instantiate(dieEffect,transform.position,Quaternion.identity);

            if (gameObject.CompareTag("boss"))
            {
                LevelManager.main.winPanel.SetActive(true);

                LevelManager.lastUnlockedLevel++;

                Destroy(gameObject);
                return;
            }

            OnEnemyDied?.Invoke(this.gameObject);
        }
        else
        {
            RefreshHealthBar(maxHP, currentHP);
        }
    }

    void SetDifficultyLevel()
    {
        switch (DifficultyManager.Instance.difficultyLevel)
        {
            case DifficultyManager.DifficultyLevels.Hard:
                maxHP += maxHP * hpPowerScale;
                MS += MS * speedPowerScale;
                break;
            case DifficultyManager.DifficultyLevels.Hell:
                maxHP += maxHP * hpPowerScale * 2;
                MS += MS * speedPowerScale * 2;
                break;
        }
    }


    private void Update()
    {
        img.transform.position = Camera.main.WorldToScreenPoint(transform.position + offSet);   //enemy health bar
    }

}
