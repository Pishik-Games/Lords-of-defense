using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health{

    public Player playerScript;
    void Start()
    {
        UpdateHealthStat();
    }
    public override void OnHit(float damage){
        this.TakeDamage(damage);
    }

    public override void TakeDamage(float damageCount){
        base.TakeDamage(damageCount);
        UpdateHealthStat();

    }

    public override void Heal(float healthCount){
        base.Heal(healthCount);
        UpdateHealthStat();
    }

    public override void OnDamageHandler(){
    }

    public override void OnHealHandler(){
    }

    public override void OnDieHandler(){
        playerScript.Die();
    }

    public void UpdateHealthStat(){
        playerStats.health = GetCurrentHealth();
        playerStats.maxHealth = GetMaxHealthCount();
    }
}
