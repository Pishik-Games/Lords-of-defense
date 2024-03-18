using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

public class AutoFireProjectile : MonoBehaviour
{

    [Inject]
    public PlayerAnimHandler animHandler;
    private GameObject Player;
    public float frequency = 1.0f;

    private float range;
    public float Range
    {
        set
        {
            range = value;
            transform.localScale = new Vector3(range, range, range);
        }
        get { return range; }
    }


    private float LastShotTime = 0;

    public GameObject projectile;
    public List<GameObject> enemiesInRange;

    public static bool isTargetSelectedByPlayer;
    public static GameObject SelectedObjByPlayer;

    public void Awake()
    {
        Range = transform.localScale.x;
    }
    private void Start(){
        Player = gameObject.transform.parent.gameObject;
    }
    public void ShootProjectile(){
        if (enemiesInRange.Count > 0){
            animHandler.isAttacking = true;
            var Enemy = (isTargetSelectedByPlayer == true) ? GetTarget() : GetNearestTarget();

            try{
                if(Enemy==null)return;
                WatchTowards(Enemy.transform.position);
                if ((Time.time - LastShotTime) > frequency){
                    if (Physics.Raycast(Player.transform.position, Player.transform.forward, out RaycastHit hit)){
                        if (hit.transform.gameObject.CompareTag("Enemy")){
                            ShootTowards();
                            LastShotTime = Time.time;
                        }
                    }
                }
            }catch (System.Exception e){
                Debug.LogError(e.ToString());
                if (Enemy.gameObject == null){
                    enemiesInRange.Remove(Enemy);
                }
            }
        }else{
            animHandler.isAttacking = false;
        }
    }

    private void ShootTowards(){
        GameObject newProjectile = Instantiate(projectile, Player.transform.position, Quaternion.identity);

        var projectileScripts = newProjectile.GetComponent<Projectile>();
        projectileScripts.damage = PlayerAttack.damage;

        Vector3 forwardDirection = Player.transform.forward;
        Quaternion additionalRotation = Quaternion.Euler(0f, 90f, 0f);
        Vector3 rotatedForward = additionalRotation * forwardDirection;
        newProjectile.transform.rotation = Quaternion.LookRotation(rotatedForward);
    }
    private void WatchTowards(Vector3 towards){
        Vector3 normalizedDirection = (towards - Player.transform.position).normalized;
        Player.transform.forward = new(normalizedDirection.x, 0, normalizedDirection.z);
    }

    private GameObject GetTarget(){
        if (SelectedObjByPlayer != null && enemiesInRange.Contains(SelectedObjByPlayer)){
            Debug.Log(" return SelectedObjByPlayer");
            return SelectedObjByPlayer;
        }
        Debug.Log("DeselectPlayerTarget");
        DeselectPlayerTarget();
        return GetNearestTarget();
    }
    float leastDistance = float.MaxValue;
    private GameObject GetNearestTarget(){

        int nearestIndex = 0;

        // Loop through the enemies in range
        for (int i = 0; i < enemiesInRange.Count - 1; i++){
            
            // Check if the enemy at the current index is null
            if (enemiesInRange[i] == null){
                    enemiesInRange.RemoveAt(i);
                    i--;
                    continue;
                }

            // Calculate the distance between the player and the current enemy
            float distance = Vector3.Distance(Player.transform.position, enemiesInRange[i].transform.position);

            // Update the nearest index and least distance if the current distance is smaller
            if (distance < leastDistance){
                    leastDistance = distance;
                    nearestIndex = i;
                }
            }
        if (enemiesInRange[nearestIndex] != null)
            return enemiesInRange[nearestIndex];
        return enemiesInRange[0];
    }


    private void OnTriggerEnter(Collider other){
        if (other.CompareTag("Enemy")){
            var Enemy = other.gameObject;
            enemiesInRange.Add(Enemy);
        }
    }

    private void OnTriggerExit(Collider other){
        if (other.CompareTag("Enemy")){
            var Enemy = other.gameObject;
            enemiesInRange.Remove(Enemy);
        }
    }

    public static void SetPlayerTarget(GameObject enemy){
        Debug.Log(" isTargetSelectedByPlayer = true");
        isTargetSelectedByPlayer = true;
        SelectedObjByPlayer = enemy;
    }
    public static void DeselectPlayerTarget(){
        Debug.Log(" isTargetSelectedByPlayer = false");
        isTargetSelectedByPlayer = false;
        SelectedObjByPlayer = null;
    }
}
