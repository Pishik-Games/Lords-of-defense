using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

public class Player : MonoBehaviour , HitReaction{
    public float speed = 10.0f;

    public HealthManager playerHealthManager;
    public GameObject enemiesOutRange;
    public GameObject enemiesInRange;
    public Joystick Joystick;

    private Vector3 moveDirection;

    private AutoFire autoFire;

    private void Awake() {
        playerHealthManager =  gameObject.AddComponent<HealthManager>();
        autoFire = GetComponentInChildren<AutoFire>();
        Joystick = FindObjectOfType<Joystick>().GetComponent<Joystick>();
        // playerHealthManager.SetHealthManagerOnHit(() => {
        //     Debug.Log("Player Got Damage");
        //     Debug.Log("Health " + playerHealthManager.Health);
        //     if (playerHealthManager.Health <= 0){
        //         Die();
        //     }
        // });
    }

    private void Update()
    {
        Injuerd();
        MoveAndTurn();
        autoFire.ShootProjectile();
    }

    private void MoveAndTurn(){
        moveDirection = new Vector3(Joystick.Horizontal, 0, Joystick.Vertical);

        transform.Translate(speed * Time.deltaTime * moveDirection, Space.World);

        if (moveDirection != Vector3.zero && autoFire.enemiesInRange.Count <= 0)
        {
            transform.forward = moveDirection;
        }
    }


    private void OnTriggerExit(Collider other){
        if (other.gameObject.name == "World Border")
        {
            EditorApplication.ExitPlaymode();
        }
    }

    public void OnGetHit(){
        if(playerHealthManager.Health <= 0){
            Die();
        }
    }

    private void Injuerd()
    {

    }

    private void Die(){
        Destroy(gameObject);
    }

    public void OnHit(){
        playerHealthManager.Damage(1);
        Debug.Log("Player Heatlh:"+playerHealthManager.Health);
        OnGetHit();
    }
}
