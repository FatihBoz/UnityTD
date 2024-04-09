using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnlockLevels : MonoBehaviour
{
    public List<Button> levels = new();

    
    void Start()
    {
        
        for (int i = 0; i < LevelManager.lastUnlockedLevel; i++)
        {
            levels[i].interactable = true;
        }
        
    }
    


}
