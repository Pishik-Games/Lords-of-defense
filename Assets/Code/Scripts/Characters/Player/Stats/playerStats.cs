using UnityEngine;
using Zenject;

public class playerStats : MonoBehaviour
{
    public static PlayerStatsUI playerStatsUI;
    private static float _health;
    public static float health{
        set{
            _health = value;
            OnStatsChange();
        }
        get{
            return _health;
        }
    }
    private static float _fireRate;
    public static float fireRate{
        set{
            _fireRate = value;
            OnStatsChange();
        }
        get{
            return _fireRate;
        }
    }

    private static float _moveSpeed;
    public static float moveSpeed{
        set{
            _moveSpeed = value;
            OnStatsChange();
        }
        get{
            return _moveSpeed;
        }
    }


    public static void OnStatsChange(){
        playerStatsUI.UpdateUI();
    }
}