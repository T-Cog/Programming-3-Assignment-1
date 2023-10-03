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
/*
        float verticalVelMag = Mathf.Sqrt(verticalVelocity.x * verticalVelocity.x + (verticalVelocity.y * verticalVelocity.y));
        float horizontalVelMag = Mathf.Sqrt(horizontalVelocity.x * horizontalVelocity.x + (horizontalVelocity.y * horizontalVelocity.y));

        float verticalMag = Mathf.Sqrt(transform.up.x * transform.up.x + (transform.up.y * transform.up.y));
        float horizontalMag = Mathf.Sqrt(transform.right.x * transform.right.x + (transform.right.y * transform.right.y));

        Vector3 verticalDir = verticalVelocity - transform.up;
        Vector3 horizontalDir = horizontalVelocity - transform.right; 

        Vector3 normalizedVertical = verticalDir / verticalMag;
        Vector3 normalizedHorizontal = horizontalDir / horizontalMag;
*/

        if (input.y > 0.1)
        {
            moving = true;

            currentSpeed += AccelerationTime * Time.deltaTime;
            currentSpeed = Mathf.Clamp(currentSpeed, 0, MaxSpeed);

           // transform.position += -normalizedVertical * currentSpeed * Time.deltaTime;
            transform.Translate(verticalVelocity);
            Debug.Log("Goin UP");
        }
        else if (input.y < -0.1)
        {
            moving = true;
            currentSpeed += AccelerationTime * Time.deltaTime;
            currentSpeed = Mathf.Clamp(currentSpeed, 0, MaxSpeed);

           // transform.position += normalizedVertical * currentSpeed * Time.deltaTime;
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

