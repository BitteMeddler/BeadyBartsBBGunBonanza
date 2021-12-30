using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetBehavior : MonoBehaviour
{
    private float moveSpeed;
    private Vector3 direction;
    private float boundary = 8;
    public int pointValue;
    private GameController gameControllerScript;

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
            direction = Vector3.left;
            pointValue = 25;
            moveSpeed = 12f;
        }
        else if (gameObject.CompareTag("Tier1Target"))
        {
            direction = Vector3.right;
            pointValue = 5;
            moveSpeed = 5f;
        }
        else if (gameObject.CompareTag("Tier2Target"))
        {
            direction = Vector3.left;
            pointValue = 10;
            moveSpeed = 8f;
        }
        else if (gameObject.CompareTag("Tier3Target"))
        {
            direction = Vector3.right;
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
