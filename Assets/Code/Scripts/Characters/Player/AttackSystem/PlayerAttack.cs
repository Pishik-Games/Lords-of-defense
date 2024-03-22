using System.Collections;
using System.Collections.Generic;
using ModestTree;
using UnityEngine;

public class PlayerAttack : MonoBehaviour{

    public static float damage;

    private float _fireRate = 1;
    public float fireRate {
        set{
            _fireRate = value;
            playerAnimHandler.SetAttackSpeed(_fireRate);
            UpdateFireRateStat(_fireRate);
        }
        get{
            return _fireRate;
        }
    }
    private PlayerAnimHandler playerAnimHandler;
    public float nextShotTime = 0f;
    public GameObject enemiesOutRange;
    public GameObject enemiesInRange;
    public AutoFireProjectile autoFireProjectile;
    private void Awake() {
        autoFireProjectile = GetComponentInChildren<AutoFireProjectile>();
        playerAnimHandler = GetComponentInChildren<PlayerAnimHandler>();
    }

    public void Attack(){
        autoFireProjectile.CheckForForwardEnemes();
    }
    public void Shoot(){
        autoFireProjectile.ShootTowards();
    }

    public void SetUpProjectilePrefab(GameObject ProjectilePrefab){
        autoFireProjectile.projectile = ProjectilePrefab;
    }

    public void UpdateFireRateStat(float fireRate){
        playerStats.fireRate = fireRate;
    }

}
