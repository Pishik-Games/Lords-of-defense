using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public GameObject PlayerToFollow;
    private Vector3 LastPlayerPos;

    public int OffsetY = 30;
    public int OffsetZ = -15;
    // Start is called before the first frame update
    void Start()
    {
        LastPlayerPos = Vector3.zero;
        PlayerToFollow = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameStateManager.GameState == GameStateManager.GameStates.MainGameIsRunning)
        {
            followPlayer();
        }
    }

    private void followPlayer(){
        if (LastPlayerPos != PlayerToFollow.transform.position){
                LastPlayerPos = PlayerToFollow.transform.position;
                var pos = new Vector3(PlayerToFollow.transform.position.x ,
                    PlayerToFollow.transform.position.y + OffsetY,
                        PlayerToFollow.transform.position.z + OffsetZ);
                transform.position = pos;
        }
        
    }
}
