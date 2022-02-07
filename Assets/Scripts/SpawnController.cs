using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public static SpawnController SharedInstance;
    public Vector3[] spawnLocations;

    private int numberOfTargets = 5;
    private int randomIndex;
    private float targetUpTime = 4.3f;

    private void Awake()
    {
        SharedInstance = this;
    }

    public void ActivateRandomTargets()
    {
        
    }

    IEnumerator WaitResetReactivate()
    {
        yield return new WaitForSeconds(targetUpTime);
        
    }
}
