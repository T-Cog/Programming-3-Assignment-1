using UnityEngine;
using System.Collections;

public class VectorToEnemy : MonoBehaviour
{

    /// <summary>
    /// Calculated vector from the player to enemy found by GameManager.GetEnemyObject
    /// </summary>
    /// <see cref="GameController.GetEnemyObject"/>
    /// <returns>The vector from the player to the enemy.</returns>
    public Vector3 GetVectorToEnemy()
    {
       
        Vector3 enemyVector = GameController.GetEnemyObject().transform.position;
        Vector3 resultVector = enemyVector - transform.position;

        return resultVector;
    }

    /// <summary>
    /// Calculates the distance from the player to the enemy returned by GameManager.GetEnemyObject.
    /// </summary>
    /// <see cref="GameController.GetEnemyObject"/>
    /// <returns>The scalar distance between the player and the enemy</returns>
    public float GetDistanceToEnemy()
    {
        Vector3 enemyDistanceVector = GetVectorToEnemy();

        float enemyDistSqrdX = Mathf.Pow(enemyDistanceVector.x, 2);
        float enemyDistSqrdY = Mathf.Pow(enemyDistanceVector.y, 2);
        float enemyDistSqrd = enemyDistSqrdX + enemyDistSqrdY;

        float distanceToEnemy = Mathf.Sqrt(enemyDistSqrd);

        return distanceToEnemy;
    }
    
}
