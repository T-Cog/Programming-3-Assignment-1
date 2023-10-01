using UnityEngine;
using System.Collections;
using System;

public class ShipMotor : MonoBehaviour
{
    public float AccelerationTime = 1;
    public float DecelerationTime = 1;
    public float MaxSpeed = 1;
    bool moving = false;
    /// <summary>
    /// Move the ship using it's transform only based on the current input vector.
    /// </summary>
    /// <param name="input">The input from the player. The possible range of values for x and y are from -1 to 1.</param>
    public void HandleMovementInput( Vector2 input )
    {
        
        
        Vector3 verticalVelocity = new Vector3(0, MaxSpeed * (AccelerationTime * Time.deltaTime), 0);
        // Vector2 horizontalVelocity = new Vector2(MaxSpeed / (AccelerationTime * Time.deltaTime), 0);

        

        if (Input.GetKeyDown("up"))
            {
            moving = true;
           
            transform.position += new Vector3(0, 5 * Time.deltaTime, 0);
            }
        else
        {
            moving = false;
            transform.position = Vector2.zero;
        }
    }

    private void Update()
    {
        Debug.Log(moving);
    }

}

