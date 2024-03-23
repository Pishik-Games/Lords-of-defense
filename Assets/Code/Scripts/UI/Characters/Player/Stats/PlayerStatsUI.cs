using UnityEngine.UI;
using UnityEngine;

public class PlayerStatsUI : MonoBehaviour
{
    
    public Text healthText;
    public Image healthBar;
    public Text fireRateText;
    public Text RangeText;
    //public Text moveSpeedText;
    // Reference other UI components as needed


    private void Awake()
    {
        Text[] texts = GetComponentsInChildren<Text>();
        foreach (var text in texts)
        {
            switch (text.gameObject.name)
            {
                case "healthText" : healthText = text; break;
                case "fireRateText" : fireRateText = text; break;
                case "RangeText" : RangeText = text; break;
                    //case "moveSpeedText" : moveSpeedText = text; break;
            }
        } 
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
        fireRateText.text = playerStats.fireRate.ToString("0.0");
        RangeText.text = playerStats.range.ToString("0.0");
        //moveSpeedText.text = playerStats.moveSpeed.ToString();
        // Update other UI components as needed
    }

    public void UpdateHealthUI(){
        var health = playerStats.health;
        var maxHealth = playerStats.maxHealth;
        healthText.text = health.ToString("0.0");
        healthBar.fillAmount = Mathf.Clamp01(health / maxHealth);
    }
}