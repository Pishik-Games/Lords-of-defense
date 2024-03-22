using UnityEngine.UI;
using UnityEngine;

public class PlayerStatsUI : MonoBehaviour
{
    
    public Text healthText;
    public Text fireRateText;
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
                //case "moveSpeedText" : moveSpeedText = text; break;
            }
        } 
        UpdateUI(); 
    }

    public void UpdateUI()
    {
        healthText.text = playerStats.health.ToString();
        fireRateText.text = playerStats.fireRate.ToString();
        //moveSpeedText.text = playerStats.moveSpeed.ToString();
        // Update other UI components as needed
    }
}