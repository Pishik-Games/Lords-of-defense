using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoFire : MonoBehaviour
{
    GameObject Player;
    public float frequency = 1.0f;

    private float timeInterval = 0;

    public GameObject projectile;
    public GameObject enemiesOutRange;
    public GameObject enemiesInRange;
    private void Start() {
        Player = gameObject.transform.parent.gameObject;
    }

    public void ShootProjectile(){
        if (enemiesInRange.transform.childCount != 0)
        {
            ShootTowards(enemiesInRange.transform.GetChild(GetNearestIndex()).transform.position);
        }  
    }

    private void ShootTowards(Vector3 towards){
        Vector3 normalizedDirection = (towards - Player.transform.position).normalized;
        Player.transform.forward = new(normalizedDirection.x, 0, normalizedDirection.z);
        if ((Time.time - timeInterval) > frequency)
        {
            GameObject newProjectile = Instantiate(projectile, Player.transform.position, Quaternion.identity);
            Vector3 forwardDirection = Player.transform.forward;
            Quaternion additionalRotation = Quaternion.Euler(0f, 90f, 0f);
            Vector3 rotatedForward = additionalRotation * forwardDirection;
            newProjectile.transform.rotation = Quaternion.LookRotation(rotatedForward);

            timeInterval = Time.time;
        }
    }
    private int GetNearestIndex(){
        int nearestIndex = -1;
        float leastDistance = 0;

        for (int i = 0; i < enemiesInRange.transform.childCount; i++)
        {
            float computedDistance = Vector3.Distance(
                            Player.transform.position,
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.gameObject.transform.parent = enemiesInRange.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.gameObject.transform.parent = enemiesOutRange.transform;
        }
    }
}
