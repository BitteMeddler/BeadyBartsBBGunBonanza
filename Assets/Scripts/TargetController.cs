using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    public static TargetController SharedInstance;
    public GameObject[] targets;
    private GameObject[] targetsToSpawn;
    private int numberOfTargets = 3;
    private int randomIndex;

    private void Awake()
    {
        SharedInstance = this;
    }

    public void ActivateRandomTargets()
    {
        targetsToSpawn = new GameObject[numberOfTargets];
        for (int i = 0; i < numberOfTargets; i++)
        {
            
            randomIndex = Random.Range(0, targets.Length);
            while (targets[randomIndex].activeSelf)
            {
                randomIndex = Random.Range(0, targets.Length);
            }
            targetsToSpawn[i] = targets[randomIndex];
            targets[randomIndex].SetActive(true);
        }
        
        StartCoroutine("WaitResetReactivate");
    }

    IEnumerator WaitResetReactivate()
    {
        yield return new WaitForSeconds(5f);
        for (int i = 0; i < targetsToSpawn.Length; i++)
        {
            targetsToSpawn[i].SetActive(false);
        }
        ActivateRandomTargets();
    }
}
