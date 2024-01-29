using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownHall : MonoBehaviour
{
    private int Health;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other) {
        var Obj = other.gameObject;
        if (Obj.CompareTag("Enemy")){
            Health -= 1;
            if (Health <= 0){
                
            }
        }
    }
}
