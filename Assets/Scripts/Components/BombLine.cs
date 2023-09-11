using UnityEngine;
using System.Collections;

public class BombLine : MonoBehaviour
{

    public GameObject BombPrefab;
    public int BombCount;
    public float BombSpacing;

    /// <summary>
    /// Spawn a line of instantiated BombPrefabs behind the player ship. There should be BombCount bombs placed with BombSpacing amount of space between them.
    /// </summary>
    /// <returns>An array containing all the bomb objects</returns>
    public GameObject[] SpawnBombs()
    {
        GameObject[] bombSpawns = new GameObject[BombCount]; //Declares an array of GameObjects with length == BombCount

        for(int i = 0; i < bombSpawns.Length; i++) //Runs a for loop that runs the same number of times as the length of the bombSpawns array
        {
            bombSpawns[i] = Instantiate(BombPrefab);  //Instantiates a BombPrefab at the array index i (0 - length of bombSpawns array)
            bombSpawns[i].transform.position = transform.position + (-transform.up * (BombSpacing * (i + 1))); //Sets the transfrom.position of the GameObject in index i to the
                                                                                                              //transform.position that this script is attatched to, added to the reverse facing
                                                                                                              //direction of the object to give it direction, then mulitplied by the BombSpacing float
                                                                                                              // * the array length + 1 to increase the spacing and distance of each subsequent bomb
        }


        return bombSpawns;
    }
    
}
