using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionPrefabRelative : MonoBehaviour
{
    public GameObject Prefab;
    public Vector3 SpawnOffset;

    /// <summary>
    /// Instantiates the game object stored in the variable Prefab at SpawnOffset distance away from the player. The object is a 
    /// root object.
    /// </summary>
    /// <returns>The newly spawned object in the right position.</returns>
    public GameObject PositionPrefabAtRelativePosition()
    {
        GameObject newPrefab = Instantiate(Prefab); //Instantiates a Prefab object stored as newPrefab
        newPrefab.transform.position = (transform.position + SpawnOffset); //Adds the SpawnOffset to the transform of the object this script is attatched to and uses that value for the newPrefab transform

        return newPrefab;
    }
    
}
