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
        Camera cam = GameController.GetCamera();
        Vector2 relativeCamInput = cam.transform.TransformPoint(input);
        
        Vector2 acceleration = relativeCamInput * (MaxSpeed / AccelerationTime);

        if (input == Vector2.zero)
        {
            Vector2 normalizedVel = Normalize(velocity);
            acceleration = -normalizedVel * (MaxSpeed / DecelerationTime);
        }
        velocity += acceleration * Time.deltaTime;
        velocity = Vector2.ClampMagnitude(velocity, MaxSpeed);
        transform.position += (Vector3)velocity * Time.deltaTime;
    }


    private Vector2 Normalize(Vector2 v)
    {
        float magnitude = Magnitude(v);

        if (magnitude != 0)
        {
            return v/magnitude;
        }

        return v;
    }

    private float Magnitude(Vector2 v)
    {

        return Mathf.Sqrt(v.x * v.x + v.y * v.y);
    }
}

