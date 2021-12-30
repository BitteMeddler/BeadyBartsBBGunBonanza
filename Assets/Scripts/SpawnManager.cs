using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] targets;

    private int targetIndex;

    private BoxCollider tierCollider;
    private GameController gameControllerScript;

    private float spawnPositionX;
    private float spawnPositionZ;

    private Vector3 spawnLocation;

    private void Start()
    {
        gameControllerScript = GameObject.Find("GameController").GetComponent<GameController>();
        InvokeRepeating("SpawnerZero", 1f, 1.4f);
        InvokeRepeating("SpawnerOne", .2f, 1f);
        InvokeRepeating("SpawnerTwo", .5f, 1.2f);
        InvokeRepeating("SpawnerThree", .8f, 1.5f);
    }

    private void SpawnerZero()
    {
        if (gameControllerScript.isGameActive)
        {
            spawnPositionX = 7f;
            spawnPositionZ = 1.5f;
            targetIndex = Random.Range(0, 3);
            Spawn("Tier0", targetIndex);
        }

    }

    private void SpawnerOne()
    { 
        if (gameControllerScript.isGameActive)
        {
            spawnPositionX = -7f;
            spawnPositionZ = 2.5f;
            targetIndex = Random.Range(3, 6);
            Spawn("Tier1", targetIndex);
        }
    }

    private void SpawnerTwo()
    {
        if (gameControllerScript.isGameActive)
        {
            spawnPositionX = 7f;
            spawnPositionZ = 3.5f;
            targetIndex = Random.Range(6, 9);
            Spawn("Tier2", targetIndex);
        }
    }

    private void SpawnerThree()
    {
        if (gameControllerScript.isGameActive)
        {
            spawnPositionX = -7f;
            spawnPositionZ = 4.5f;
            targetIndex = Random.Range(9, 12);
            Spawn("Tier3", targetIndex);
        }
    }

    private void Spawn(string tierNumber, int targetIndex)
    {
        tierCollider = GameObject.Find(tierNumber).GetComponent<BoxCollider>();

        float yPosition = ((this.transform.localScale.y / 2) + tierCollider.bounds.max.y);
        spawnLocation = new Vector3(spawnPositionX, yPosition, spawnPositionZ);
        this.transform.position = spawnLocation;


        Instantiate(targets[targetIndex], spawnLocation, targets[targetIndex].transform.rotation);
    }
    

}
