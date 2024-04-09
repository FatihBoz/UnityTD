using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyManager : MonoBehaviour
{
    public static DifficultyManager Instance;

    public DifficultyLevels difficultyLevel;

    [SerializeField] private List<Sprite> difficultyLevelSprites;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        difficultyLevel = DifficultyLevels.Normal;
    }

    public void OnDifficultyButtonPressed(Button button)
    {
        // Change difficulty    
        switch (difficultyLevel)
        {
            case DifficultyLevels.Normal:
                SetDifficulty(DifficultyLevels.Hard,button);
                break;
            case DifficultyLevels.Hard:
                SetDifficulty(DifficultyLevels.Hell, button);
                break;
            case DifficultyLevels.Hell:
                SetDifficulty(DifficultyLevels.Normal, button);
                break;
        }
    }


    private void SetDifficulty(DifficultyLevels level , Button difficultyButton)
    {
        difficultyLevel = level;
        // Change button sprite based on difficulty level
        int spriteIndex = (int)difficultyLevel;
        difficultyButton.image.sprite = difficultyLevelSprites[spriteIndex];
        difficultyButton.image.SetNativeSize();
    }



    public enum DifficultyLevels
    {
        Normal,
        Hard,
        Hell
    }

}
