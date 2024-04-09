using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public static bool musicOn = true;
    public static bool sfxOn = true;

    [SerializeField] private GameObject settingsPanel;

    [SerializeField] private Button sfxOnOffButton;
    [SerializeField] private Button musicOnOffButton;
    [SerializeField] private Image musicIcon;

    [SerializeField] private List<Sprite> sfxButtonOnOffSprites;   //[0] --> red button , [1] --> green button
    [SerializeField] private List<Sprite> musicButtonOnOffSprites;  //[0] = red button, [1] = green button , [2] = musicOff icon , [3] = musicOn icon. 


    private bool isExpanded;

    private void Start()
    {
        CheckAtStart();
    }


    public void OnSettingsButtonClick()
    {
        isExpanded = !isExpanded;
        settingsPanel.SetActive(isExpanded);
    }


    public void OnSfxButtonClick()
    {

        switch (sfxOn)
        {
            case true:
                TurnOffSFX();
                break;

            case false:
                TurnOnSFX();
                break;
        }
    }

    public void OnMusicButtonClick()
    {
        switch (musicOn)
        {
            case true:
                TurnOffMusic();
                break;

            case false:
                TurnOnMusic();
                break;
        }


    }


    void CheckAtStart()
    {
        switch (sfxOn)
        {
            case true:
                TurnOnSFX();
                break;

            case false:
                TurnOffSFX();
                break;
        }

        switch (musicOn)
        {
            case true:
                TurnOnMusic();
                break;

            case false:
                TurnOffMusic();
                break;
        }
    }



    void TurnOffMusic()
    {
        musicOn = false;
        musicOnOffButton.image.sprite = musicButtonOnOffSprites[0];
        musicIcon.sprite = musicButtonOnOffSprites[2];
        musicIcon.SetNativeSize();

        if (AudioSource() != null)
        {
            AudioSource().mute = true;
        }
        
    }

    void TurnOnMusic()
    {
        musicOn = true;
        musicOnOffButton.image.sprite = musicButtonOnOffSprites[1];
        musicIcon.sprite = musicButtonOnOffSprites[3];
        musicIcon.SetNativeSize();

        if (AudioSource() != null)
        {
            AudioSource().mute = false;
        }
    }

    void TurnOffSFX()
    {
        sfxOn = false;
        sfxOnOffButton.image.sprite = sfxButtonOnOffSprites[0];
    }

    void TurnOnSFX()
    {
        sfxOn = true;
        sfxOnOffButton.image.sprite = sfxButtonOnOffSprites[1];
    }

    AudioSource AudioSource()
    {
        return AudioManager.instance.GetAudioSource();
    }

}
