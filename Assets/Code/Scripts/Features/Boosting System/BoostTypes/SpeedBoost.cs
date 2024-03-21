using System.Collections;
using System.Collections.Generic;
using BoostingSystem;
using UnityEngine;

public class SpeedBoost : Boost{
    public float SpeedCount;
    public override void ApplyBoost(GameObject Player)
    {
        Player.GetComponent<Player>().playerAttack.fireRate += SpeedCount;

        OnBoostEnd();
    }

    public override void OnBoostEnd()
    {
              
    }
}
