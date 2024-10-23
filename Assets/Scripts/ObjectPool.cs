using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject[] prefabs;
    [SerializeField] private int poolSize;
    [SerializeField] private Transform parentObj;

    private List<GameObject>[] pools;

    private void Start()
    {
        pools = new List<GameObject>[prefabs.Length];

        for (int i = 0; i < prefabs.Length; i++)
        {
            pools[i] = new List<GameObject>();

            for (int j = 0; j < poolSize; j++)
            {
                GameObject obj = Instantiate(prefabs[i],parentObj);
                obj.SetActive(false);
                pools[i].Add(obj);
            }
        }
    }

    public GameObject GetObjectFromPool(int poolIndex = 0)
    {
        foreach (GameObject obj in pools[poolIndex])
        {
            if (!obj.activeInHierarchy)
            {
                return obj;
            }
        }
        //if there is no inactive prefab in the pool, create new one.
        GameObject newObj = Instantiate(prefabs[poolIndex],parentObj);
        newObj.SetActive(false);
        pools[poolIndex].Add(newObj);
        return newObj;  
    }

    public void ReturnToPool(GameObject obj)
    {
        obj.SetActive(false);
    }
}
