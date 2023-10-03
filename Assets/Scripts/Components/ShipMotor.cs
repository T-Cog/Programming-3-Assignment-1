using UnityEngine;
using System.Collections;
using System;

public class ShipMotor : MonoBehaviour
{
    public float AccelerationTime = 1;
    public float DecelerationTime = 1;
    public float MaxSpeed = 5;
    private float currentSpeed;
    bool moving = false;
    /// <summary>
    /// Move the ship using it's transform only based on the current input vector.
    /// </summary>
    /// <param name="input">The input from the player. The possible range of values for x and y are from -1 to 1.</param>
    public void HandleMovementInput( Vector2 input )
    {

        Vector3 verticalVelocity = new Vector3(0, currentSpeed * Time.deltaTime, 0);
        Vector3 horizontalVelocity = new Vector3(currentSpeed * Time.deltaTime, 0, 0);


        if (input.y > 0.1)
        {
            moving = true;

            currentSpeed += AccelerationTime * Time.deltaTime;
            currentSpeed = Mathf.Clamp(currentSpeed, 0, MaxSpeed);

            transform.Translate(verticalVelocity);
            Debug.Log("Goin UP");
        }
        else if (input.y < -0.1)
        {
            moving = true;
            currentSpeed += AccelerationTime * Time.deltaTime;
            currentSpeed = Mathf.Clamp(currentSpeed, 0, MaxSpeed);

            transform.Translate(-verticalVelocity);
            Debug.Log("Goin DOWN");
        }
        else if (input.x > 0.1)
        {
            moving = true;
            transform.Translate(horizontalVelocity);
            Debug.Log("Goin RIGHT");
        }
        else if (input.x < -0.1)
        {
            moving = true;
            transform.Translate(-horizontalVelocity);
            Debug.Log("Goin LEFT");
        }
        else
        {
            moving = false;

            currentSpeed = 0;
            transform.Translate(Vector3.zero);
            Debug.Log("Stop");
        }
    }

    private void Update()
    {
        Debug.Log(moving);
    }

}

