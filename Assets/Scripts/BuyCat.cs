using UnityEngine;
using TMPro;

public class BuyCat : MonoBehaviour
{

    public EconomyManager economyManager;
    public CatSpawner catSpawner;
    public TextMeshProUGUI balanceText;
    public int catCost = 10; // Example cost for buying a cat  
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateLabelText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnBuyCatButtonPressed()
    {
        if (economyManager.SpendCurrency(catCost))
        {
            catSpawner.PurchaseCat();
        }
    }

    public void UpdateLabelText()
    {
        balanceText.text = "Buy Cat (" + catCost.ToString() + ")";
    }


}
