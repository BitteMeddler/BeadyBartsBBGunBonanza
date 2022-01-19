using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetXRotation : MonoBehaviour
{
    private SpawnManager spawnManagerScript;

    void Start()
    {
        spawnManagerScript = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    }

    void Update()
    {
        if (this.transform.position.y > spawnManagerScript.tierColliders[3].bounds.max.y + 1)
        {
            this.transform.localRotation = Quaternion.Euler(30, 0, 0);
        }
        else if (this.transform.position.y < spawnManagerScript.tierColliders[3].bounds.max.y + .2f)
        {
            this.transform.localRotation = Quaternion.Euler(-12, 0, 0);
        }

    }
}
