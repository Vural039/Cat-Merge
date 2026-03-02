using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameStates currentState;
    public GameObject shopUI;
    public GameObject shopButton;

    void Awake()
    {
        Instance = this;
        ChangeState(GameStates.Playing); // Start in playing state
    }

    public void ChangeState(GameStates newState)
    {
        currentState = newState;

        switch (currentState)
        {
            case GameStates.Playing:
                Debug.Log("Game Started");
                shopUI.SetActive(false);
                shopButton.SetActive(true); // Enable shop button while playing
                break;
            case GameStates.Shop:
                Debug.Log("Shop Opened");
                shopUI.SetActive(true);
                shopButton.SetActive(false); // Disable shop button while in shop
                break;

            // case GameStates.Paused:
            //     Debug.Log("Paused");
            //     shopUI.SetActive(false);
            //     break;
        }
    }
}
