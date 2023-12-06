using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public interface HitReaction{
    public void OnHit();
}
public class HealthManager : MonoBehaviour
{
    public HealthManager(callBack _onHit){
        OnHit = _onHit;
    }
    public void SetHealthManagerOnHit(callBack _onHit){
        OnHit = _onHit;
    }
    public callBack OnHit;
    public delegate void callBack();
    private int MaxHealth = 100;
    private int _health;
    
    public int Health{
        set{
            _health = value;
        }
        get{ 
            return _health; 
        }
    }
    public void Awake() {
        MaxHealth = 100;
        Health = MaxHealth;
    }

    public void Damage(int damage){
        Health = Health - damage;
        Debug.Log("damage " + damage);
        if (OnHit != null){
            OnHit();
        }
    }

    public void Heal(int heal){
        if (heal + Health <= MaxHealth){
            Health = MaxHealth;
        }else{
            Health += heal;
        }
    }
}
