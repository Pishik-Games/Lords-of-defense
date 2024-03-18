using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using Unity.VisualScripting;
using Zenject;

public class Player : MonoBehaviour {
    public PlayerHealth playerHealth;
    public PlayerAttack playerAttack;

    [Inject]
    public PlayerAnimHandler animHandler;

    public CharactersStats charactersStats;
    public float speed = 10.0f;
    public FloatingJoystick Joystick;


    private Vector3 moveDirection;

    private static bool playerIsMoving = false;

    private void Awake() {
        charactersStats = GetComponentInChildren<CharactersStatsHolder>().CharactersStat;
        Joystick = FindObjectOfType<FloatingJoystick>().GetComponent<FloatingJoystick>();


        
        SetUpPlayerHealth();
        SetUpPlayerAttack();

    }
    private void SetUpPlayerHealth(){
        playerHealth = gameObject.GetOrAddComponent<PlayerHealth>();
        playerHealth.playerScript = this;
        playerHealth.MaxHealth = charactersStats.maxHealth;
    }
    private void SetUpPlayerAttack(){
        playerAttack = gameObject.GetOrAddComponent<PlayerAttack>();
        PlayerAttack.damage = charactersStats.damage;
        playerAttack.SetUpProjectilePrefab(charactersStats.ProjectilePrefab);
    }

    private void Update(){
        
        if (GameStateManager.GameState == GameStateManager.GameStates.MainGameIsRunning){
            playerIsMoving = FloatingJoystick.isActive;
            if (!playerIsMoving){
                animHandler.isWalking = false;
                playerAttack.Attack();
            }else{
                animHandler.isWalking = true;
                animHandler.isAttacking = false;
                MoveAndTurn();
            }
        }
    }

    private void MoveAndTurn() {
        moveDirection = new Vector3(Joystick.Horizontal, 0, Joystick.Vertical);

        transform.Translate(speed * Time.deltaTime * moveDirection, Space.World);

        if (moveDirection != Vector3.zero ){ // && autoFire.enemiesInRange.Count <= 0
            transform.forward = moveDirection;
        }
    }


    private void OnTriggerExit(Collider other){
        if (other.gameObject.name == "World Border"){
            EditorApplication.ExitPlaymode();
        }
    }



    public void Die(){
        MatchManager.LoseGame();
        Destroy(this.gameObject);
    }

}
