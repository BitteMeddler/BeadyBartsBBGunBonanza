using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastShoot : MonoBehaviour
{
    private float fireRate = .2f;
    private float nextFire;
    public Transform gunEnd;

    private Vector3 bbSpawnPosition;
    private GameController gameController;

    public ParticleSystem muzzleFlash;
    public ParticleSystem hitEffect;
    public GameObject bb;

    private Camera fpsCam;
    private AudioSource gunAudio;
    
    void Start()
    {
        fpsCam = GetComponentInParent<Camera>();
        gunAudio = GetComponent<AudioSource>();
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    void Update()
    {
        FireWeapon();    
    }

    public void FireWeapon()
    {
        if (Input.GetButtonDown("Fire1") && Time.time > nextFire && gameController.isGameActive)
        {
            nextFire = Time.time + fireRate;
            muzzleFlash.Emit(1);
            Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
            Transform gunEndPos = gunEnd.transform;
            RaycastHit hit;
            if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit))
            {
                hitEffect.transform.position = hit.point;
                hitEffect.transform.forward = hit.normal;
                hitEffect.Emit(1);
                SpawnBB(gunEndPos);
                TargetMovement target = hit.collider.GetComponent<TargetMovement>();
                if (target != null)
                {
                    gameController.ScoreTracker(target.pointValue);
                    Destroy(target.gameObject);
                }
            }

        }
    }

    public void SpawnBB(Transform gunEndPos)
    {
        bbSpawnPosition = new Vector3(gunEndPos.position.x, gunEndPos.position.y, gunEndPos.position.z);
        Instantiate(bb, bbSpawnPosition, this.transform.rotation);
    }
}
