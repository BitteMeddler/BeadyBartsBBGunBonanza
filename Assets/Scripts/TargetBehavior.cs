using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBehavior : MonoBehaviour
{
    private float moveSpeed;
    private float boundary = 8;
    public int pointValue;

    private Vector3 direction;

    private void Start()
    {
        InitializeTargetProperties();
    }

    void Update()
    {
        TargetMovement();
    }

    public void InitializeTargetProperties()
    {
        if (gameObject.CompareTag("Tier0Target"))
        {
            direction = Vector3.forward;
            pointValue = 25;
            moveSpeed = 12f;
        }
        else if (gameObject.CompareTag("Tier1Target"))
        {
            direction = Vector3.forward;
            pointValue = 5;
            moveSpeed = 5f;
        }
        else if (gameObject.CompareTag("Tier2Target"))
        {
            direction = Vector3.forward;
            pointValue = 10;
            moveSpeed = 8f;
        }
        else if (gameObject.CompareTag("Tier3Target"))
        {
            direction = Vector3.forward;
            pointValue = 50;
            moveSpeed = 16f;
        }
    }

    public void TargetMovement()
    {
        transform.Translate(direction * moveSpeed * Time.deltaTime);
        if (this.transform.position.x > boundary || this.transform.position.x < -boundary)
        {
            Destroy(this.gameObject);
        }
    }
}
