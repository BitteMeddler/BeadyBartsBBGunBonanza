using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private float spawnPositionX;
    private float spawnPositionY;
    private float spawnPositionZ;
    
    private int targetIndex;

    public GameObject[] targets;
    public GameObject[] tiers;
    public BoxCollider[] tierColliders;
    //public GameObject birdBounder;
    //public BoxCollider birdBounds;

    private GameController gameControllerScript;

    private Vector3 spawnLocation;

    private void Start()
    {
        //birdBounds = birdBounder.GetComponent<BoxCollider>();

        tierColliders = new BoxCollider[tiers.Length];
        for (int i = 0; i < tiers.Length; i++)
        {
            tierColliders[i] = tiers[i].GetComponent<BoxCollider>();
        }
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
            spawnPositionY = (tierColliders[0].bounds.max.y);
            spawnPositionX = tierColliders[0].bounds.max.x;
            targetIndex = Random.Range(0, 3);
            Spawn(0, targetIndex);
        }

    }

    private void SpawnerOne()
    { 
        if (gameControllerScript.isGameActive)
        {
            spawnPositionY = (tierColliders[1].bounds.max.y);
            spawnPositionX = tierColliders[1].bounds.min.x;
            targetIndex = Random.Range(3, 6);
            Spawn(1, targetIndex);
        }
    }

    private void SpawnerTwo()
    {
        if (gameControllerScript.isGameActive)
        {
            spawnPositionY = (tierColliders[2].bounds.max.y);
            spawnPositionX = tierColliders[2].bounds.max.x;
            targetIndex = Random.Range(6, 9);
            Spawn(2, targetIndex);
        }
    }

    private void SpawnerThree()
    {
        if (gameControllerScript.isGameActive)
        {
            spawnPositionY = Random.Range(tierColliders[3].bounds.min.y, tierColliders[3].bounds.max.y);
            spawnPositionX = tierColliders[3].bounds.min.x;
            targetIndex = Random.Range(9, 12);
            Spawn(3, targetIndex);
        }
    }

    public void Spawn(int tierIndex, int targetIndex)
    {
        spawnPositionZ = Random.Range(tierColliders[tierIndex].bounds.min.z + .2f, tierColliders[tierIndex].bounds.max.z - .2f);


        spawnLocation = new Vector3(spawnPositionX, spawnPositionY, spawnPositionZ);
        this.transform.position = spawnLocation;

        Instantiate(targets[targetIndex], spawnLocation, targets[targetIndex].transform.rotation);
    }
}
