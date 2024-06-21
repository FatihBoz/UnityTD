using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinPanel : MonoBehaviour
{
    [Header("GameObjects")]
    [SerializeField] private GameObject watchAdButton;
    [SerializeField] private GameObject adIsWatchedIcon;

    [Header("Resource Scales")]
    public float difficultyResourceScale = 0.4f;
    public float levelResourceScale = 0.5f;

    [Header("Colors")]
    public Color normalTextColor;
    public Color hardTextColor;
    public Color hellTextColor;

    [Header("Resource Texts")]
    [SerializeField] private TextMeshProUGUI goldText;
    [SerializeField] private TextMeshProUGUI woodText;
    [SerializeField] private TextMeshProUGUI stoneText;
    [SerializeField] private TextMeshProUGUI steelText;

    [Header("Other Texts")]
    [SerializeField] private TextMeshProUGUI difficultyText;



    #region PRIVATE
    private int level;

    private float currentDifficultyScale;

    private readonly int lowerBoundOfGold = 750;
    private readonly int upperBoundOfGold = 1050;

    private readonly int lowerBoundOfResource = 350;
    private readonly int upperBoundOfResource = 700;
    #endregion

    private void Start()
    {
        PauseMenu.instance.PauseGame();

        GameObject.FindGameObjectWithTag("AdsManager").GetComponent<LoadInterstitialAds>().ShowAd();

        DetermineLevel();
        DisplayDifficulty();
        GainResources(); 
    }


    void DetermineLevel()
    {
        level = SceneManager.GetActiveScene().buildIndex - 3;
    }



    void DisplayDifficulty()
    {
        //Determine and display the difficulty
        switch (DifficultyManager.Instance.difficultyLevel)
        {
            case DifficultyManager.DifficultyLevels.Normal:
                difficultyText.text = "Normal";
                difficultyText.color = normalTextColor;
                currentDifficultyScale = 0;
                break;

            case DifficultyManager.DifficultyLevels.Hard:
                difficultyText.text = "Hard";
                difficultyText.color = hardTextColor;
                currentDifficultyScale = difficultyResourceScale;
                break;

            case DifficultyManager.DifficultyLevels.Hell:
                difficultyText.text = "Hell";
                difficultyText.color = hellTextColor;
                currentDifficultyScale = difficultyResourceScale * 2;
                break;
        }
    }

    public void OnWatchAdButtonClick()
    {
        watchAdButton.SetActive(false);
        adIsWatchedIcon.SetActive(true);
    }


    public void GainResources()
    {
        GainGold();
        GainWood();
        GainStone();
        GainSteel();
    }

    void GainGold()
    {
        float gold = Random.Range(lowerBoundOfGold, upperBoundOfGold);
        //Get random base amount of gold

        gold += gold * level * levelResourceScale;
        //Scale it according to level

        gold += gold * currentDifficultyScale;
        //scale it according to difficulty

        goldText.text = gold.ToString();

        Resources.resources.GainGoldCoin((int)gold);
        //Gain resource
    }

    void GainWood()
    {
        float wood = Random.Range(lowerBoundOfResource, upperBoundOfResource);
        //Get random base amount of wood

        wood += wood * level * levelResourceScale;
        //Scale it according to level

        wood += wood * currentDifficultyScale;
        //scale it according to difficulty

        woodText.text = wood.ToString();

        Resources.resources.GainWood((int)wood);
        //Gain resource
    }

    void GainStone()
    {
        float stone = Random.Range(lowerBoundOfResource, upperBoundOfResource);
        //Get random base amount of stone

        stone += stone * level * levelResourceScale;
        //Scale it according to level

        stone += stone * currentDifficultyScale;
        //scale it according to difficulty

        stoneText.text = stone.ToString();

        Resources.resources.GainStone((int)stone);
        //Gain resource
    }

    void GainSteel()
    {
        float steel = Random.Range(lowerBoundOfResource, upperBoundOfResource);
        //Get random base amount of steel

        steel += steel * level * levelResourceScale;
        //Scale it according to level

        steel += steel * currentDifficultyScale;
        //scale it according to difficulty

        steelText.text = steel.ToString();

        Resources.resources.GainSteel((int)steel);
        //Gain resource
    }

}
