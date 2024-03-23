using UnityEngine;
using Zenject;
public class TownHallStats : MonoBehaviour
{
    public static TownHallStatsUI TownHallStatsUI;
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
    private static float _maxHealth;
    public static float maxHealth{
        set{
            _maxHealth = value;
            OnStatsChange();
        }
        get{
            return _maxHealth;
        }
    }

    public static void OnStatsChange(){
        TownHallStatsUI.UpdateUI();
    }
}
