﻿using UnityEngine;
using System.Collections;

public class PowerUps : MonoBehaviour
{
    public GameObject PowerUpPrefab;
    public int PowerUpCount = 3;
    public float PowerUpRadius = 1;
    


    /// <summary>
    /// Spawn a circle of PowerUpCount power up prefabs stored in PowerUpPrefab, evenly spaced, around the player with a radius of PowerUpRadius
    /// </summary>
    /// <returns>An array of the spawned power ups, in counter clockwise order.</returns>
    public GameObject[] SpawnPowerUps()
    {
        Vector3 shipPosition = transform.position;


        GameObject[] PowerUpOrbit = new GameObject[PowerUpCount];

        for (int i = 0; i < PowerUpOrbit.Length; i++)
        {
            PowerUpOrbit[i] = Instantiate(PowerUpPrefab);

        }

        return null;
    }
}
