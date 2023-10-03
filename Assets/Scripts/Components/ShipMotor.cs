using UnityEngine;
using System.Collections;
using System;

public class ShipMotor : MonoBehaviour
{
    public float AccelerationTime = 1;
    public float DecelerationTime = 1;
    public float MaxSpeed = 5;
    Vector2 velocity = Vector2.zero;

    /// <summary>
    /// Move the ship using it's transform only based on the current input vector.
    /// </summary>
    /// <param name="input">The input from the player. The possible range of values for x and y are from -1 to 1.</param>
    public void HandleMovementInput( Vector2 input )
    {
        Camera cam = GameController.GetCamera(); //Calls the GetCamera Method and stores it
        Vector2 relativeCamInput = cam.transform.TransformPoint(input); //Changes the input to be relative to the camera in local space
        
        Vector2 acceleration = relativeCamInput * (MaxSpeed / AccelerationTime); //Sets acceleration relative to camera input using rise over run

        //if statement that begins deceleration if there is no inpu
        if (input == Vector2.zero) 
        {
            Vector2 normalizedVel = Normalize(velocity); //Normalizes and stores velocity
            acceleration = -normalizedVel * (MaxSpeed / DecelerationTime); //Sets acceleration relative to normalized velocity using rise over run to keep acceleration consistent
        }
        velocity += acceleration * Time.deltaTime; //Adds acceleration value to velocity in deltaTime
        velocity = Vector2.ClampMagnitude(velocity, MaxSpeed); //Clamps the Vector to cap at MaxSpeed
        transform.position += (Vector3)velocity * Time.deltaTime; //Adds the velocity to the velocity vector in deltaTime
    }


    //Method to normalize vectors
    private Vector2 Normalize(Vector2 v)
    {
        float magnitude = Magnitude(v);

        if (magnitude != 0)
        {
            return v/magnitude;
        }

        return v;
    }

    //Method to find the magnitutde of vectors
    private float Magnitude(Vector2 v)
    {

        return Mathf.Sqrt(v.x * v.x + v.y * v.y);
    }
}

