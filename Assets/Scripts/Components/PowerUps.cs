using UnityEngine;
using System.Collections;

public class PowerUps : MonoBehaviour
{
    public GameObject PowerUpPrefab;
    public int PowerUpCount = 3;
    public float PowerUpRadius = 1;
    private float placementAngle;
    private float circumference = 360f;
    private Vector3 shipPosition;
    private Vector3 powerUpSpawnPoint;

    /// <summary>
    /// Spawn a circle of PowerUpCount power up prefabs stored in PowerUpPrefab, evenly spaced, around the player with a radius of PowerUpRadius
    /// </summary>
    /// <returns>An array of the spawned power ups, in counter clockwise order.</returns>
    public GameObject[] SpawnPowerUps()
    {
        shipPosition = transform.position; //Sets the shipPosition to the position of the object this script is attatched to
        placementAngle = circumference / PowerUpCount; //Sets the placement angle = to the valuue of the circumference divided by the PowerUpCount to keep spacing consistent if PowerUpCount is changed

        GameObject[] powerUpOrbit = new GameObject[PowerUpCount]; //Creates a GameObject array with length equal to the PowerUpCount

        for (int i = 0; i < powerUpOrbit.Length; i++)
        {
            powerUpOrbit[i] = Instantiate(PowerUpPrefab); //Fills each index in the array with a new PowerUpPrefab

            //Sets the X and Y powerUpSpawnPoint using the point on a circle formula
            //Multiplying the placementAngle by i acts as a modifier to consistently change the placement of powerups around the player
            float currentAngle = placementAngle * i * Mathf.Deg2Rad;
            float powerUpX = shipPosition.x + Mathf.Cos(currentAngle) * PowerUpRadius;
            float powerUpY = shipPosition.y + Mathf.Sin(currentAngle) * PowerUpRadius;
            powerUpSpawnPoint = new Vector3(powerUpX, powerUpY, 0); 

            powerUpOrbit[i].transform.position = powerUpSpawnPoint; //Sets the position of each index in the powerUpOrbit array equal to the current powerUpSpawnPoint

        }

        return powerUpOrbit; //Returns the powerUpOrbit array
    }
}
