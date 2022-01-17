using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] private Vector2 acceleration;
    [SerializeField] private Vector2 sensitivity;
    [SerializeField] private float maxHorizontalAngle;
    [SerializeField] private float maxVerticalAngleTop;
    [SerializeField] private float maxVerticalAngleBottom;
    [SerializeField] private float inputLagPeriod;

    private Vector2 velocity;
    private Vector2 rotation;
    private Vector2 lastInputEvent;
    private float inputLagTimer;

    private GameController gameManager;

    void Start()
    {
        gameManager = GameObject.Find("GameController").GetComponent<GameController>();
        velocity = Vector2.zero;
        inputLagTimer = 0;
        lastInputEvent = Vector2.zero;

        ResetPosition();
    }

    void Update()
    {
        LookAround();
    }

    private float ClampVerticalAngle(float angle)
    {
        if (!gameManager.isGameActive)
        {
            maxVerticalAngleTop = 0;
            maxVerticalAngleBottom = 0;
        }
        else
        {
            maxVerticalAngleTop = -13f;
            maxVerticalAngleBottom = 20f;
        }
        return Mathf.Clamp(angle, maxVerticalAngleTop, maxVerticalAngleBottom);
    }

    private float ClampHorizontalAngle(float angle)
    {
        if (!gameManager.isGameActive)
        {
            maxHorizontalAngle = 0;
        }
        else
        {
            maxHorizontalAngle = 30f;
        }
        return Mathf.Clamp(angle, -maxHorizontalAngle, maxHorizontalAngle);
    }

    private Vector2 GetInput()
    {
        inputLagTimer += Time.deltaTime;
        Vector2 input = new Vector2(
            Input.GetAxis("Mouse X"),
            Input.GetAxis("Mouse Y"));

        if ((Mathf.Approximately(0, input.x) && Mathf.Approximately(0, input.y)) == false || inputLagTimer >= inputLagPeriod)
        {
            lastInputEvent = input;
            inputLagTimer = 0;
        }

        return lastInputEvent;
    }

    private void LookAround()
    {
        Vector2 wantedVelocity = GetInput() * sensitivity;

        velocity = new Vector2(
            Mathf.MoveTowards(velocity.x, wantedVelocity.x, acceleration.x * Time.deltaTime),
            Mathf.MoveTowards(velocity.y, wantedVelocity.y, acceleration.y * Time.deltaTime));

        rotation += velocity * Time.deltaTime;
        rotation.y = ClampVerticalAngle(rotation.y);
        rotation.x = ClampHorizontalAngle(rotation.x);

        transform.localEulerAngles = new Vector3(rotation.y, rotation.x, 0);
    }

    private void ResetPosition()
    {
        //Centers mouselook at start
        Vector3 euler = transform.localEulerAngles;

        if (euler.x >= 180)
        {
            euler.x -= 360;
        }
        euler.x = ClampVerticalAngle(euler.x);
        transform.localEulerAngles = euler;

        rotation = new Vector2(euler.y, euler.x);
    }
}
