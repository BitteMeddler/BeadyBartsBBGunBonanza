using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMovement : MonoBehaviour
{
    private float moveSpeed = 5;
    public int pointValue;

    private float topBoundary;

    private Vector3 originalPosition;
    private GameController _gameController;

    private void Start()
    {
        originalPosition = transform.position;
        topBoundary = originalPosition.y + .45f;
        pointValue = 10;
        _gameController = GameController.SharedInstance;
    }

    void Update()
    {
        Movement();
    }

    public void Movement()
    {
        if (transform.position.y < topBoundary && _gameController.isGameActive)
        {
            transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
        }
        
    }

    public void OnDisable()
    {
        transform.position = originalPosition;
    }




}
