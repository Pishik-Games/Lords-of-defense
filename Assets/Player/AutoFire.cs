using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoFire : MonoBehaviour
{
    public bool isShooting = false;
    private GameObject Player;
    public float frequency = 1.0f;

    private float LastShotTime = 0;

    public GameObject projectile;
    public List<GameObject> enemiesOutRange;
    public List<GameObject> enemiesInRange;
    private void Start() {
        Player = gameObject.transform.parent.gameObject;
    }

    public void ShootProjectile(){
        if (!(enemiesInRange.Count <= 0) ){

            isShooting = true;
            if ((Time.time - LastShotTime) > frequency){
                var TargetIndex = GetNearestIndex();
                if (TargetIndex >= 0){
                    try{
                        var Enemy = enemiesInRange[TargetIndex];
                        ShootTowards(Enemy.transform.position);
                    }
                    catch (System.Exception){
                        enemiesInRange.RemoveAt(TargetIndex);
                    }  
                }

                LastShotTime = Time.time;
            }
        }  else{
            isShooting = false;
        }
    }

    private void ShootTowards(Vector3 towards){
        Vector3 normalizedDirection = (towards - Player.transform.position).normalized;
        Player.transform.forward = new(normalizedDirection.x, 0, normalizedDirection.z);
            GameObject newProjectile = Instantiate(projectile, Player.transform.position, Quaternion.identity);
            Vector3 forwardDirection = Player.transform.forward;
            Quaternion additionalRotation = Quaternion.Euler(0f, 90f, 0f);
            Vector3 rotatedForward = additionalRotation * forwardDirection;
            newProjectile.transform.rotation = Quaternion.LookRotation(rotatedForward);
    }
    private int GetNearestIndex(){
        int nearestIndex = -1;
        float leastDistance = 0;

        for (int i = 0; i < enemiesInRange.Count; i++){
            var Enemy = enemiesInRange[i];
            if (Enemy == null){
                enemiesInRange.Remove(enemiesInRange[i]);
                continue;
            }
            float Distance = Vector3.Distance(
                            Player.transform.position,
                            enemiesInRange[i].transform.position);
            if (leastDistance == 0){
                leastDistance = Distance;
                nearestIndex = i;
            }
            else if (leastDistance > Distance){
                leastDistance = Distance;
                nearestIndex = i;
            }
        }
        if (true)
        {
            
        }
        Debug.Log(nearestIndex);
        return nearestIndex;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy")){
            var Enemy = other.gameObject;
            enemiesInRange.Add(Enemy);
            enemiesOutRange.Remove(Enemy);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            var Enemy = other.gameObject;
            enemiesInRange.Remove(Enemy);
            enemiesOutRange.Add(Enemy);
        }
    }
}
