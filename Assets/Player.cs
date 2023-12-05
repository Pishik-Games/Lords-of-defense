using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

public class Player : MonoBehaviour
{
    public float speed = 10.0f;
    public float frequency = 1.0f;

    public HealthManager playerHealthManager;

    public GameObject projectile;
    public GameObject enemiesOutRange;
    public GameObject enemiesInRange;
    public VariableJoystick variableJoystick;

    private Vector3 moveDirection;
    private float timeInterval = 0;

    private void Awake() {
        playerHealthManager =  gameObject.AddComponent<HealthManager>();
        playerHealthManager.SetHealthManagerOnHit(() => {
            Debug.Log("Player Got Damage");
            Debug.Log("Health " + playerHealthManager.Health);
            if (playerHealthManager.Health <= 0){
                Die();
            }
        });
    }

    private void Update()
    {
        Injuerd();
        MoveAndTurn();
        ShootProjectile();
    }

    private void MoveAndTurn(){
        moveDirection = new Vector3(variableJoystick.Horizontal, 0, variableJoystick.Vertical);

        transform.Translate(speed * Time.deltaTime * moveDirection, Space.World);

        if (moveDirection != Vector3.zero)
        {
            transform.forward = moveDirection;
        }
    }

    private void ShootProjectile(){
        if (enemiesInRange.transform.childCount != 0)
        {
            ShootTowards(enemiesInRange.transform.GetChild(GetNearestIndex()).transform.position);
        }  
    }

    private int GetNearestIndex(){
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

    private void ShootTowards(Vector3 towards){
        Vector3 normalizedDirection = (towards - transform.position).normalized;
        transform.forward = new(normalizedDirection.x, 0, normalizedDirection.z);
        if ((Time.time - timeInterval) > frequency)
        {
            GameObject newProjectile = Instantiate(projectile, transform.position, Quaternion.identity);
            Vector3 forwardDirection = transform.forward;
            Quaternion additionalRotation = Quaternion.Euler(0f, 90f, 0f);
            Vector3 rotatedForward = additionalRotation * forwardDirection;
            newProjectile.transform.rotation = Quaternion.LookRotation(rotatedForward);

            timeInterval = Time.time;
        }
    }

    private void OnTriggerExit(Collider other){
        if (other.gameObject.name == "World Border")
        {
            EditorApplication.ExitPlaymode();
        }
    }

    public void OnGetHit(){
    }

    private void Injuerd()
    {

    }

    private void Die(){
        Destroy(gameObject);
    }
}
