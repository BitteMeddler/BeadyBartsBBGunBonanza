using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BBBehavior : MonoBehaviour
{
    private float moveSpeed = 250f;

    void Start()
    {
        Destroy(this.gameObject, 2);   
    }

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);   
    }
}
