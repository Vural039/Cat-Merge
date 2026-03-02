using UnityEngine;
using TMPro;

public class EconomyManager : MonoBehaviour
{
    public int balance = 20;
    public TextMeshProUGUI balanceText;

    void Start()
    {
        UpdateBalanceUI();
    }

    public void AddCurrency(int amount, float multiplier)
    {
        if (multiplier > 1)
        {
            balance += (int)(amount * multiplier);
        }
        else
        {
            balance += amount;
        }

        UpdateBalanceUI();
    }

    public bool SpendCurrency(int amount)
    {
        if (balance >= amount)
        {
            balance -= amount;
            UpdateBalanceUI();
            return true;
        }
        else
        {
            Debug.Log("Not enough currency!");
            return false;
        }
    }

    void UpdateBalanceUI()
    {
        balanceText.text = balance.ToString();
    }
}
