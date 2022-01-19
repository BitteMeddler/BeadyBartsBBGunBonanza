using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMovement : MonoBehaviour
{
    private float moveSpeed;
    private float boundary = 8;
    public int pointValue;

    private void Start()
    {
        InitializeTargetProperties();
    }

    void Update()
    {
        Movement();
    }

    public void InitializeTargetProperties()
    {
        if (gameObject.CompareTag("Tier0Target"))
        {
            pointValue = 25;
            moveSpeed = 12f;
        }
        else if (gameObject.CompareTag("Tier1Target"))
        {
            pointValue = 5;
            moveSpeed = 5f;
        }
        else if (gameObject.CompareTag("Tier2Target"))
        {
            pointValue = 10;
            moveSpeed = 8f;
        }
        else if (gameObject.CompareTag("Tier3Target"))
        {
            pointValue = 50;
            moveSpeed = 4f;
        }
    }

    public void Movement()
    {
        
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        if (this.transform.position.x > boundary || this.transform.position.x < -boundary)
        {
            Destroy(this.gameObject);
        }
    }

    
}
