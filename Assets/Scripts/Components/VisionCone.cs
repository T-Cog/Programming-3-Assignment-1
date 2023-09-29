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
        Vector3 enemyToPlyr = player.position - transform.position;
        float distanceToPlayer = DistanceToPlayer();

        float transformUpMag = Mathf.Sqrt((transform.up.x * transform.up.x) + (transform.up.y * transform.up.y));

        float enemyPlyrDot = ((transform.up.x * enemyToPlyr.x) + (transform.up.y * enemyToPlyr.y) + (transform.up.z * enemyToPlyr.z) 
            / (transformUpMag / distanceToPlayer));

        float angle = Mathf.Acos(enemyPlyrDot / (transformUpMag * distanceToPlayer));

        bool isPlayerInVisionCone;
        if ( distanceToPlayer <= ViewDistance && angle * Mathf.Rad2Deg > 0 && angle * Mathf.Rad2Deg <= AngleSweepInDegrees)
        {
            isPlayerInVisionCone = true;
        }
        else
        {
            isPlayerInVisionCone = false;
        }

        return isPlayerInVisionCone;
    }
    
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
