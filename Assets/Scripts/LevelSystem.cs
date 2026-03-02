using UnityEngine;

public class LevelSystem : MonoBehaviour
{

    public int currentlevel=0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LevelUp()
    {
        currentlevel++;
        // Additional logic for leveling up can be added here
    }
}
