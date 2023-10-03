using UnityEngine;
using System.Collections;

public class HomingMissile : MonoBehaviour
{
    public float ForwardSpeed = 1;
    public float RotateSpeedInDeg = 45;

    // In Update, you should rotate and move the missile to rotate it towards the player.  It should move forward with ForwardSpeed and rotate at RotateSpeedInDeg.
    void Update()
    {
        Vector3 enemyPos = GameController.GetEnemyObject().transform.position; //Calls the GetEnemyObject method and stores the enemy's position
        Vector3 enemyPosLocal = transform.InverseTransformPoint(enemyPos); //Sets the enemyPos to local space, relative to the player

        float angle = Mathf.Atan2(enemyPosLocal.x, enemyPosLocal.y) * Mathf.Rad2Deg; //Stores an angle using the enemy's local position
        float clampedAngle = Mathf.Clamp(angle, -RotateSpeedInDeg * Time.deltaTime, RotateSpeedInDeg * Time.deltaTime); //Clamps the angle min and max to the value of RotateSpeedInDeg, modified by deltaTime 

        Vector3 velocity = new Vector3(0, ForwardSpeed * Time.deltaTime, 0); //Sets a velocity using ForwardSpeed modified by deltaTime
        Vector3 angularVelocity = new Vector3(0, 0, -clampedAngle); //Sets angularVelocity for rotation using clampedAngle to constrain rotation 

        transform.Translate(velocity); //Uses Translate to move the missile using velocity
        transform.Rotate(angularVelocity); //Uses Rotate to turn the missile using the contstrained rotation
    }
}
