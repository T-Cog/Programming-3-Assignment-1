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
       
        Vector3 enemyVector = GameController.GetEnemyObject().transform.position; //Calls GetEnemyObject to retrieve the enemy transform position and stores it as a vector
        Vector3 resultVector = enemyVector - transform.position; //Subtracts the position vector of the object this script is attatched to from the enemyVector and stores the result 

        return resultVector;
    }

    /// <summary>
    /// Calculates the distance from the player to the enemy returned by GameManager.GetEnemyObject.
    /// </summary>
    /// <see cref="GameController.GetEnemyObject"/>
    /// <returns>The scalar distance between the player and the enemy</returns>
    public float GetDistanceToEnemy()
    {
        Vector3 enemyDistanceVector = GetVectorToEnemy(); //Calls GetVectorToEnemy and stores the returned vector

        float enemyDistSqrdX = Mathf.Pow(enemyDistanceVector.x, 2); //Squares the x value of enemyDistanceVector and stores the result
        float enemyDistSqrdY = Mathf.Pow(enemyDistanceVector.y, 2); //Squares the y value of enemyDistanceVector and stores the result
        float enemyDistSqrd = enemyDistSqrdX + enemyDistSqrdY; //Adds the squared values and stores the result

        float distanceToEnemy = Mathf.Sqrt(enemyDistSqrd); //Calculates the square root of enemyDistSqrd and stores the value

        return distanceToEnemy;
    }
    
}
