using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour{

    public static float damage;
    public float fireRate = 1f; // The number of shots per second
    public float nextShotTime = 0f;
    public GameObject enemiesOutRange;
    public GameObject enemiesInRange;
    public AutoFireProjectile autoFireProjectile;
    private void Awake() {
        autoFireProjectile = GetComponentInChildren<AutoFireProjectile>();           
    }

    public void Attack(){
        if (Time.time > nextShotTime)
        {
            nextShotTime = Time.time + 1f / fireRate;
            autoFireProjectile.ShootProjectile();
        }
    }

    public void SetUpProjectilePrefab(GameObject ProjectilePrefab){
        autoFireProjectile.projectile = ProjectilePrefab;
    }

}
