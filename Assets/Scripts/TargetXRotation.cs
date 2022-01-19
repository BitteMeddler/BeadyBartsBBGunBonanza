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
        if (this.transform.position.y > spawnManagerScript.tierColliders[3].bounds.max.y)
        {
            this.transform.rotation = Quaternion.Euler(30, 90, 0);
        }
        else if (this.transform.position.y < spawnManagerScript.tierColliders[3].bounds.min.y)
        {
            this.transform.rotation = Quaternion.Euler(348, 90, 0);
        }

    }
}
