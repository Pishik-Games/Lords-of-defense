using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownHalHeathlManger : Health{
    public TownHall townHallScript;

    private void Awake() {
        this.MaxHealth = 1000;
    }
    void Start(){
        UpdateHealthStat();
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

    public override void OnDieHandler(){
        townHallScript.DestroyTownHall();
        MatchManager.LoseGame();
    }

    public override void OnHealHandler(){

    }

    public override void OnHit(float damage){
        this.TakeDamage(damage);
    }
    public void UpdateHealthStat(){
        TownHallStats.health = GetCurrentHealth();
        TownHallStats.maxHealth = GetMaxHealthCount();
    }
}
