using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour
{
    public static TargetController SharedInstance;

    public GameObject[] targets;
    private GameObject[] targetsToSpawn;

    private GameController gameControllerScript;

    private int numberOfTargets = 3;
    private int randomIndex;

    private void Awake()
    {
        SharedInstance = this;
    }

    private void Start()
    {
        ActivateRandomTargets();
    }

    private void Update()
    {
  
    }

    public void ActivateRandomTargets()
    {
        
        for (int i = 0; i < numberOfTargets; i++)
        {
            
            randomIndex = Random.Range(0, targets.Length);
            while (targets[randomIndex].activeSelf)
            {
                randomIndex = Random.Range(0, targets.Length);
            }
            targets[randomIndex].SetActive(true);
        }
        
        StartCoroutine("WaitAndReset");
    }

    IEnumerator WaitAndReset()
    {
        yield return new WaitForSeconds(3.5f);
        for (int i = 0; i < targets.Length; i++)
        {
            targets[i].SetActive(false);
        }
        ActivateRandomTargets();
    }

    

}
