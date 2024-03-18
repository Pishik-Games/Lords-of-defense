using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health{

    public Player playerScript;

    public override void OnHit(float damage){
        this.TakeDamage(damage);
    }

    public override void TakeDamage(float damageCount){
        base.TakeDamage(damageCount);

    }

    public void Heal(float healthCount){
        base.Heal(healthCount);

    }

    public override void OnDamageHandler(){
    }

    public override void OnHealHandler(){
    }

    public override void OnDieHandler(){
        playerScript.Die();
    }
}
