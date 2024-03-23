using UnityEngine.UI;
using UnityEngine;
using ModestTree;
public class TownHallStatsUI : MonoBehaviour
{
    
    public Image healthBar;


    private void Awake()
    {
        Image[] imagesBars = GetComponentsInChildren<Image>();
        foreach (var bar in imagesBars)
        {
            switch (bar.gameObject.name)
            {
                case "healthBar" : healthBar = bar; break;
                //case "fireRateBar" : fireRateBar = bar; break;
                //case "RangeBar" : RangeBar = bar; break;
                //case "moveSpeedImage" : moveSpeedImage = Image; break;
            }
        } 
        UpdateUI(); 
    }

    public void UpdateUI()
    {
        UpdateHealthUI();
    }

    public void UpdateHealthUI(){
        var health = TownHallStats.health;
        var maxHealth = TownHallStats.maxHealth;    
        healthBar.fillAmount = Mathf.Clamp01(health / maxHealth);
    }
}