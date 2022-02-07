using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBehavior : MonoBehaviour
{
    public static GunBehavior SharedInstance;

    private float fireRate = .4f;
    public float nextFire;

    private AudioSource gunAudio;

    private void Awake()
    {
        SharedInstance = this;
    }

    private void Start()
    {
        gunAudio = GetComponent<AudioSource>();
    }

    private void OnEnable()
    {
        FireAction.onFired += GetNextFire;
    }

    private void OnDisable()
    {
        FireAction.onFired -= GetNextFire;
    }

    public void GetNextFire()
    {
        nextFire = Time.time + fireRate;
    }
}
