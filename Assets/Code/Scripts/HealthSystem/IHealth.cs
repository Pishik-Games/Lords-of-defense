using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

public abstract class Health : MonoBehaviour{
    public  float CurrentHealth;

    private float _MaxHealth;
    public  float MaxHealth{ set{
            _MaxHealth = value;
            CurrentHealth = MaxHealth;
        } get{
            return _MaxHealth;
        } }

    public virtual void TakeDamage(float damageCount){
        
        CurrentHealth -= damageCount;

        if (CurrentHealth <= MaxHealth - MaxHealth){
            OnDieHandler();
        }else{
            OnDamageHandler();
        }
    }
    public virtual void Heal(float healthCount){
        if (healthCount + CurrentHealth > MaxHealth){
            CurrentHealth = MaxHealth;
        }else{
            CurrentHealth += healthCount;
        }
        OnHealHandler();
    }
    public abstract void OnHealHandler();
    public abstract void OnDamageHandler();
    public abstract void OnDieHandler();
    public abstract void OnHit(float damage);
}