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
        shipPosition = transform.position;
        placementAngle = circumference / PowerUpCount;

        GameObject[] powerUpOrbit = new GameObject[PowerUpCount];

        for (int i = 0; i < powerUpOrbit.Length; i++)
        {

            powerUpSpawnPoint = new Vector3 (shipPosition.x + Mathf.Cos(placementAngle * i * Mathf.Deg2Rad)  * PowerUpRadius, 
                shipPosition.y + Mathf.Sin(placementAngle * i * Mathf.Deg2Rad) * PowerUpRadius, 0);

            powerUpOrbit[i] = Instantiate(PowerUpPrefab, powerUpSpawnPoint, Quaternion.identity);

        }

        return powerUpOrbit;
    }
}
