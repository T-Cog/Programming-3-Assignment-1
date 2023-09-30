using UnityEngine;
using System.Collections;

public class HomingMissile : MonoBehaviour
{
    public float ForwardSpeed = 1;
    public float RotateSpeedInDeg = 45;

    // In Update, you should rotate and move the missile to rotate it towards the player.  It should move forward with ForwardSpeed and rotate at RotateSpeedInDeg.
    void Update()
    {
        Vector3 enemyPos = GameController.GetEnemyObject().transform.position;
        Vector3 enemyPosLocal = transform.InverseTransformPoint(enemyPos);

        float angle = Mathf.Atan2(enemyPosLocal.x, enemyPosLocal.y) * Mathf.Rad2Deg;
        float clampedAngle = Mathf.Clamp(angle, -RotateSpeedInDeg * Time.deltaTime, RotateSpeedInDeg * Time.deltaTime);

        Vector3 velocity = new Vector3(0, ForwardSpeed * Time.deltaTime, 0);
        Vector3 angularVelocity = new Vector3(0, 0, -clampedAngle);

        transform.Translate(velocity);
        transform.Rotate(angularVelocity);
    }
}
