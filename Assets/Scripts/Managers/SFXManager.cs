using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    [Header("User Interface SFX")]
    [SerializeField] private AudioClip simpleButtonClickSF;
    [SerializeField] private AudioClip menuclickSF;

    [Header("In Game SFX")]
    [SerializeField] private AudioClip startBuildingSF;
    [SerializeField] private AudioClip towerCollapseSF;
    [SerializeField] private AudioClip towerConstructedSF;


    public void SimpleButtonClickSF()
    {
        PlaySF(simpleButtonClickSF);
    }

    public void MenuClickSF()
    {
        PlaySF(menuclickSF);
    }

    public void StartBuildingSF()
    {
        PlaySF(startBuildingSF);
    }

    public void TowerCollapseSF()
    {
        PlaySF(towerCollapseSF);
    }

    public void TowerConstructedSF()
    {
        PlaySF(towerConstructedSF);
    }


    void PlaySF(AudioClip clip)
    {
        if(SettingsMenu.sfxOn)
        {
            audioSource.PlayOneShot(clip);
        }
    }
}
