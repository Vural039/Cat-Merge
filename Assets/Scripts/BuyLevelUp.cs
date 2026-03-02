using UnityEngine;
using TMPro;

public class BuyLevelUp : MonoBehaviour
{
    public int levelCost = 10;
    public LevelSystem levelSystem;
    public EconomyManager economyManager;
    public TextMeshProUGUI levelText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateLevelText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnLevelUpButtonPressed()
    {
        if(economyManager.SpendCurrency(levelCost))
        {
        levelSystem.LevelUp();
        levelCost += 10; // Example: Increase cost for next level up
        UpdateLevelText();
        }
        else
        {
            Debug.Log("Not enough currency to level up!");
        }
    }

    public void UpdateLevelText()
    {
        levelText.text = "Level Up (" + levelCost.ToString() + ")";
    }
}
