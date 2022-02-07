using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetProperties : MonoBehaviour
{
    private float moveSpeed = 5;
    public int pointValue = 10;

    private float topBoundary;

    private Vector3 originalPosition;
    private GameController _gameController;

    private void Start()
    {
        _gameController = GameController.SharedInstance;
        originalPosition = transform.position;
        topBoundary = originalPosition.y + .45f;
    }

    void Update()
    {
        if (transform.position.y < topBoundary && _gameController.isGameActive)
        {
            transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
        }
    }

    private void OnDisable()
    {
        transform.position = originalPosition;
    }

}

