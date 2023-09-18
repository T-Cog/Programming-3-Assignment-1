using UnityEngine;
using System.Collections;

public class BombSpiral : MonoBehaviour
{
    public GameObject BombPrefab;
    [Range(5, 25)]
    public float SpiralAngleInDegrees = 10;
    public int BombCount = 10;
    public float StartRadius = 1;
    public float EndRadius = 3;
    private float currentRadius;
    private float placementAngle = 0;
    Vector3 shipPosition;
    Vector3 bombSpiralPosition;
    


    /// <summary>
    /// Spawns spirals of BombPrefab game objects around the player. Create BombCount number of bombs 
    /// around the player, with each bomb being spaced SpiralAngleInDegrees apart from the next. The spiral 
    /// starts at StartRadius away from the player and ends at EndRadius away from the player.
    /// </summary>
    /// <returns>An array of the spawned bombs</returns>
    public GameObject[] SpawnBombSpiral()
    {
        shipPosition = transform.position; //Sets the shipPosition to the position of the object this script is attatched to

        GameObject[] bombs = new GameObject[BombCount];

        for (int i = 0; i < bombs.Length; i++)
        {
            //Sets currentRadius to a linear interpolation between StartRadius and EndRadius,
            //using i as a modifier to divide by BombCount to give consistent increasing space between each bomb when setting bombSpiralPosition
            currentRadius = Mathf.Lerp(StartRadius, EndRadius, (float)i / BombCount);

            //Sets the bombSpiralPosition using the point on a circle formula
            bombSpiralPosition = new Vector3(shipPosition.x + Mathf.Cos(placementAngle * Mathf.Deg2Rad) * currentRadius,
                shipPosition.y + Mathf.Sin(placementAngle * Mathf.Deg2Rad) * currentRadius, 0); 

            bombs[i] = Instantiate(BombPrefab, bombSpiralPosition, Quaternion.identity); //Fills each index in the array with BombPrefab and spawns it at bombSpiralPosition with no rotation 

            placementAngle += SpiralAngleInDegrees; //Adds SpiralAngleInDegrees to the placement angle so the bombs are placed in a spiral and not a line
        }

        return bombs; //Returns bombs array
    }

}
