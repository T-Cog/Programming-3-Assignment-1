using UnityEngine;
using System.Collections;

public class VisionCone : MonoBehaviour
{

    public float AngleSweepInDegrees = 60;
    public float ViewDistance = 3;
    public Transform player;

    /// <summary>
    /// Calculates whether the player is inside the vision cone of an enemy as defined by the AngleSweepIndegrees
    /// and ViewDistance varilables. You may use any of the previous methods you have written.
    /// </summary>
    /// <see cref="GameController"/>
    /// <returns>Whether the player is within the enemy's vision cone.</returns>
    public bool IsPlayerInVisionCone()
    {
        Vector3 enemyToPlyr = player.position - transform.position; //Stores the vector from the enemy to the player
        float distanceToPlayer = DistanceToPlayer(); //Calls the Distance to player method

        float transformUpMag = Mathf.Sqrt((transform.up.x * transform.up.x) + (transform.up.y * transform.up.y)); //Caculates the magnitude of the enemy transform.up

        //Calculates the dot product of the vectors of transform.up and distance to the player
        float enemyPlyrDot = ((transform.up.x * enemyToPlyr.x) + (transform.up.y * enemyToPlyr.y) + (transform.up.z * enemyToPlyr.z) 
            / (transformUpMag / distanceToPlayer));

        float angle = Mathf.Acos(enemyPlyrDot / (transformUpMag * distanceToPlayer)); //Sets an angle between the player and enemy transform.up using the dot product

        //If statement used to check if the player is within ViewDistance of the enemy
        //and if the angle between the enemy and the player is greater than 0 to ensure they are in front of the enemy
        //and if the angle between the enemy and player is within the enemy's vision cone set by AngleSweepInDegrees
        if ( distanceToPlayer <= ViewDistance && angle * Mathf.Rad2Deg > 0 && angle * Mathf.Rad2Deg <= AngleSweepInDegrees)
        {
            return true; //Returns the method bool as true
        }
        else
        {
            return false; //Returns the method bool as false
        }
    }
    
    //Method used to calculate the magnitude from the enemy vector to the player vector
    public float DistanceToPlayer()
    {
        Vector3 enemyToPlyr = player.position - transform.position;

        float enemyToPlyrXsqrd = Mathf.Pow(enemyToPlyr.x, 2);
        float enemyToPlyrYsqrd = Mathf.Pow(enemyToPlyr.y, 2);
        float enemyToPlyrsqrd = enemyToPlyrXsqrd + enemyToPlyrYsqrd;

        float distanceToPlayer = Mathf.Sqrt(enemyToPlyrsqrd);

        return distanceToPlayer;
    }

}
