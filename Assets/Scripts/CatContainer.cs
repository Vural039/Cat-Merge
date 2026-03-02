using UnityEngine;

public class CatContainer : MonoBehaviour
{
    public GameObject[] catPrefabs=new GameObject[2];

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject GetCatPrefabAccLevel(int level)
    {
        if (level < 0 || level >= catPrefabs.Length)
        {
            Debug.LogWarning("Invalid cat level: " + level);
            return null;
        }
        return catPrefabs[level];
    }
}
