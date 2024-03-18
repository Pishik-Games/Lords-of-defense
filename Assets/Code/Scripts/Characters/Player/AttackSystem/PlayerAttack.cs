using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour{

    public static float damage;
    public GameObject enemiesOutRange;
    public GameObject enemiesInRange;

    public AutoFireProjectile autoFireProjectile;
    private void Awake() {
        autoFireProjectile = GetComponentInChildren<AutoFireProjectile>();           
    }

    public void Attack(){
        autoFireProjectile.ShootProjectile();
    }

    public void SetUpProjectilePrefab(GameObject ProjectilePrefab){
        autoFireProjectile.projectile = ProjectilePrefab;
    }

}
