using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireAction : MonoBehaviour
{
    public delegate void FireGun();
    public static event FireGun onFired;

    private GunBehavior equippedGun;

    private GameController gameController;

    private void Start()
    {
        gameController = GameController.SharedInstance;
        equippedGun = GunBehavior.SharedInstance;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time > equippedGun.nextFire && gameController.isGameActive)
        {
            if(onFired != null)
            {
                onFired();
            }
        }
    }

}

