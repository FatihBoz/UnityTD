using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    public float destroyTime;
    
    void Start()
    {
        Destroy(this.gameObject,destroyTime);
    }

}
