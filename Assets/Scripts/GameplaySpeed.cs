using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameplaySpeed : MonoBehaviour
{
    [SerializeField] private Button speedChangingButton;
    [SerializeField] private TextMeshProUGUI speedText;

    private readonly string defaultSpeedText = "1x";
    private readonly string highSpeedText = "2x";

    bool speedUp;

    private void Start()
    {
        speedChangingButton.onClick.AddListener(OnSpeedChangerButtonClicked);
    }


    void OnSpeedChangerButtonClicked()
    {
        speedUp = !speedUp;

        SpeedUpCheck();
    }


    void SpeedUpCheck()
    {
        if (speedUp)
            Time.timeScale = 2.0f;
        else
            Time.timeScale = 1.0f;

        UpdateButton();
    }


    void UpdateButton()
    {
        speedText.text = speedUp ? highSpeedText : defaultSpeedText;
    }


    private void OnEnable()
    {
        PauseMenu.OnPauseFinished += SpeedUpCheck;
    }

    private void OnDisable()
    {
        PauseMenu.OnPauseFinished -= SpeedUpCheck;
    }
}   
