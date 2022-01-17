using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBehavior : MonoBehaviour

{
    public GameObject[] targets;
    public GameObject[] tiers;
    private BoxCollider[] tierColliders;
    private SpawnManager spawnManagerScript;

    private float spawnPositionX;
    private float spawnPositionZ;

    private int targetIndex;

    private GameController gameControllerScript;

    private Vector3 spawnLocation;

    // Start is called before the first frame update
    void Start()
    {
        spawnManagerScript = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        InvokeRepeating("Spawner", 1f, 1.4f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnerZero()
    {
        if (gameControllerScript.isGameActive)
        {
            spawnPositionX = 7f;
            spawnPositionZ = 1.5f;
            targetIndex = Random.Range(0, 3);
            spawnManagerScript.Spawn(0, targetIndex);
        }

    }
}
