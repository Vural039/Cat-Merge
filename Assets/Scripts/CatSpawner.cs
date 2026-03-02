using UnityEngine;

public class CatSpawner : MonoBehaviour
{
    public GameObject catContainer;
    public LevelSystem levelSystem;
    public float spawnInterval = 5f; // seconds between spawns
    private float spawnTimer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        SpawnCatAtCoordinate(new Vector2(0, 0), 0); // Example spawn at (0,0) with level 0 cat
    }



    // Update is called once per frame
    void Update()
    {
        // accumulate time and spawn at interval
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnInterval)
        {
            spawnTimer = 0f;
            // spawn at default position or modify as needed
            SpawnCatAtCoordinate(new Vector2(0, 0), 0);
        }
    }

    public void SpawnCatAtCoordinate(Vector2 position, int catLevel)
    {
        GameObject catPrefab = catContainer.GetComponent<CatContainer>().GetCatPrefabAccLevel(catLevel);
        if (catPrefab == null)
        {
            Debug.LogError("No cat prefab found for level: " + catLevel);
            return;
        }
        Instantiate(catPrefab, position, Quaternion.identity);
    }

    public void PurchaseCat()
    {
        // Example: Spawn a level 0 cat at a default position when purchased
        SpawnCatAtCoordinate(new Vector2(0, 0), levelSystem.currentlevel);
    }
}
