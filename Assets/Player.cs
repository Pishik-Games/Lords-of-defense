using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Player : MonoBehaviour
{
    public float speed = 10.0f;
    public float frequency = 1.0f;

    public GameObject projectile;
    public GameObject enemiesOutRange;
    public GameObject enemiesInRange;
    public VariableJoystick variableJoystick;

    private Vector3 moveDirection;
    private float timeInterval = 0;

    private void Update()
    {
        MoveAndTurn();
        ShootProjectile();
    }

    private void MoveAndTurn()
    {
        /* // &&& No JoyStick &&&
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        moveDirection = new Vector3(horizontalInput, 0, verticalInput); */

        /* // &&& With JoyStick */
        moveDirection = new Vector3(variableJoystick.Horizontal, 0, variableJoystick.Vertical);

        transform.Translate(speed * Time.deltaTime * moveDirection, Space.World);

        if (moveDirection != Vector3.zero)
        {
            transform.forward = moveDirection;
        }
    }

    private void ShootProjectile()
    {
        if (enemiesInRange.transform.childCount != 0)
        {
            ShootTowards(enemiesInRange.transform.GetChild(GetNearestIndex()).transform.position);
        }  
    }

    private int GetNearestIndex()
    {
        int nearestIndex = -1;
        float leastDistance = 0;

        for (int i = 0; i < enemiesInRange.transform.childCount; i++)
        {
            float computedDistance = Vector3.Distance(
                            transform.position,
                            enemiesInRange.transform.GetChild(i).transform.position);
            if (leastDistance == 0)
            {
                leastDistance = computedDistance;
                nearestIndex = i;
            }
            else if (leastDistance > computedDistance)
            {
                leastDistance = computedDistance;
                nearestIndex = i;
            }
        }

        return nearestIndex;
    }

    private void ShootTowards(Vector3 towards)
    {
        // Face the direction of nearest enemy
        Vector3 normalizedDirection = (towards - transform.position).normalized;
        transform.forward = new(normalizedDirection.x, 0, normalizedDirection.z);

        // Shoot the projectle if enough time has passed
        if ((Time.time - timeInterval) > frequency)
        {
            // Instantiate the object
            GameObject newProjectile = Instantiate(projectile, transform.position, Quaternion.identity);

            // TODO: Set the scale, speed, and power of projectile

            // Get the forward direction of the current object
            Vector3 forwardDirection = transform.forward;

            // Rotate the forward direction by 90 degrees in the y-axis
            Quaternion additionalRotation = Quaternion.Euler(0f, 90f, 0f);
            Vector3 rotatedForward = additionalRotation * forwardDirection;

            // Set the rotation of the instantiated object to the rotated forward direction
            newProjectile.transform.rotation = Quaternion.LookRotation(rotatedForward);

            timeInterval = Time.time;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "World Border")
        {
            EditorApplication.ExitPlaymode();
        }
    }
}
