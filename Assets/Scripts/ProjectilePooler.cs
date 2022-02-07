using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilePooler : MonoBehaviour
{
    public static ProjectilePooler SharedInstance;
    public GameObject projectileToPool;
    public int amountToPool;

    private List<GameObject> projectilePool;
    
    private void Awake()
    {
        SharedInstance = this;   
    }

    private void Start()
    {
        projectilePool = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < amountToPool; i ++)
        {
            tmp = Instantiate(projectileToPool);
            tmp.SetActive(false);
            projectilePool.Add(tmp);
        }
    }

    public GameObject GetPooledProjectile()
    {
        for(int i = 0; i < amountToPool; i ++)
        {
            if(!projectilePool[i].activeInHierarchy)
            {
                return projectilePool[i];
            }
        }
        return null;
    }
}
