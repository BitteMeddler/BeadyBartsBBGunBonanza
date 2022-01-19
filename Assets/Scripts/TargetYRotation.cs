using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetYRotation : MonoBehaviour
{
    private SpawnManager spawnManagerScript;

    void Start()
    {
        spawnManagerScript = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();   
    }

    void Update()
    {
        if (this.transform.position.z > spawnManagerScript.tierColliders[0].bounds.max.z -.2f)
        {
            this.transform.rotation = Quaternion.Euler(0, -116, 0);
        }
        else if (this.transform.position.z < spawnManagerScript.tierColliders[0].bounds.min.z + .2f)
        {
            this.transform.rotation = Quaternion.Euler(0, -64, 0);
        }
        
    }
}
