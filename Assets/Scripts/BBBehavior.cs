using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BBBehavior : MonoBehaviour
{
    private float moveSpeed = 220f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed);   
    }
}
