using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TownHall : BuildingBase {
    public TownHalHeathlManger townHalHeathlManger;
    private void OnCollisionEnter(Collision other) {
        var obj = other.transform.gameObject;
        if (obj.CompareTag("Enemy")){
            obj.GetComponent<EnemyAI>().Die();
            townHalHeathlManger.OnHit(1.0f);
        }
    }

    public void DestroyTownHall(){
        Destroy(gameObject);
    }
}
