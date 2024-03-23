using System.Collections;
using System.Collections.Generic;
using BoostingSystem;
using UnityEngine;

public class RangeBoost : Boost{
    public float rangeCount;
    public override void ApplyBoost(GameObject Player)
    {
        Player.GetComponentInChildren<AutoFireProjectile>().range += rangeCount;

        OnBoostEnd();
    }

    public override void OnBoostEnd()
    {
              
    }
}
