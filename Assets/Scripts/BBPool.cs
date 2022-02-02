using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BBPool : MonoBehaviour
{
    public static BBPool SharedInstance;
    private List<GameObject> pooledBBs;
    public GameObject bbToPool;
    private int amountToPool;

    private void Awake()
    {
        SharedInstance = this;   
    }

    private void Start()
    {
        pooledBBs = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < amountToPool; i ++)
        {
            tmp = Instantiate(bbToPool);
            tmp.SetActive(false);
            pooledBBs.Add(tmp);
        }
    }

    public GameObject GetPooledBB()
    {
        for(int i = 0; i < amountToPool; i ++)
        {
            if(!pooledBBs[i].activeInHierarchy)
            {
                return pooledBBs[i];
            }
        }
        return null;
    }
}
