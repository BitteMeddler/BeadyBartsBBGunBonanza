using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateProjectile : MonoBehaviour
{
    private Vector3 projectileSpawnPosition;
    public Transform gunEnd;

    void OnEnable()
    {
        FireAction.onFired += SpawnProjectile;   
    }
    private void OnDisable()
    {
        FireAction.onFired -= SpawnProjectile;
    }

    public void SpawnProjectile()
    {
        GameObject projectile = ProjectilePooler.SharedInstance.GetPooledProjectile();
        projectileSpawnPosition = new Vector3(gunEnd.position.x, gunEnd.position.y, gunEnd.position.z);
        if (projectile != null)
        {
            projectile.transform.position = projectileSpawnPosition;
            projectile.transform.rotation = this.transform.rotation;
            projectile.SetActive(true);
        }
    }
}
