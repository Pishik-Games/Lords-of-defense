using System.Collections;
using System.Collections.Generic;
using BoostingSystem;
using UnityEngine;

public class HealingBoost : Boost{
    public float healCount;
    public override void ApplyBoost(GameObject Player)
    {
        Player.GetComponent<Health>().Heal(healCount);

        OnBoostEnd();
    }

    public override void OnBoostEnd()
    {
              
    }
}
