using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 10.0f;

    private Vector3 moveDirection;

    public GameObject projectile;

    void Update()
    {
        MoveAndTurn();
        ShootProjectile();
    }

    private void MoveAndTurn()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        moveDirection = new Vector3(horizontalInput, 0, verticalInput);

        transform.Translate(speed * Time.deltaTime * moveDirection, Space.World);

        if (moveDirection != Vector3.zero)
        {
            transform.forward = moveDirection;
        }
    }

    private void ShootProjectile()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Instantiate the object
            GameObject newProjectile = Instantiate(projectile, transform.position, Quaternion.identity);

            // Get the forward direction of the current object
            Vector3 forwardDirection = transform.forward;

            // Rotate the forward direction by 90 degrees in the y-axis
            Quaternion additionalRotation = Quaternion.Euler(0f, 90f, 0f);
            Vector3 rotatedForward = additionalRotation * forwardDirection;

            // Set the rotation of the instantiated object to the rotated forward direction
            newProjectile.transform.rotation = Quaternion.LookRotation(rotatedForward);
        }
    }
}
