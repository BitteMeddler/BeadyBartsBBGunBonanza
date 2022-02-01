using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMovement : MonoBehaviour
{
    private float moveSpeed = 5;
    public int pointValue;

    private float topBoundary;

    public TargetController _targetController;
    public GameController _gameController;
    public Vector3 originalPosition;

    private void Start()
    {
        _targetController = TargetController.SharedInstance;
        _gameController = GameController.SharedInstance;
        originalPosition = transform.position;
        topBoundary = originalPosition.y + .45f;
        pointValue = 10;
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
