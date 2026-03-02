using UnityEngine;

public class MergeManager : MonoBehaviour
{
    public static MergeManager Instance;
    public EconomyManager economyManager;
    public AudioSource audioSource;
    public AudioClip mergeSound;

    public float mergeRadius = 0.6f;
    public GameObject[] levelPrefabs;

    private void Awake()
    {
        Instance = this;
    }

    public void TryMerge(GameObject dragged, Vector3 startPos)
    {
        Cat draggedCat = dragged.GetComponent<Cat>();

        Collider2D[] hits = Physics2D.OverlapCircleAll(
            dragged.transform.position,
            mergeRadius
        );

        foreach (var hit in hits)
        {
            if (hit.gameObject == dragged)
                continue;

            Cat otherCat = hit.GetComponent<Cat>();

            if (otherCat != null && otherCat.level == draggedCat.level)
            {
                ExecuteMerge(dragged, hit.gameObject, draggedCat.level);
                return;
            }
        }

        // if no merge occurred we leave the cat where the player dropped it
        // (previous behavior snapped it back to startPos)
        // dragged.transform.position = startPos;
    }

    void ExecuteMerge(GameObject a, GameObject b, int level)
    {
        Vector3 pos = a.transform.position;

        Destroy(a);
        Destroy(b);

        economyManager.AddCurrency(1, 1+level*0.3f); // Example: Add currency on merge
        Instantiate(levelPrefabs[level + 1], pos, Quaternion.identity);
        audioSource.PlayOneShot(mergeSound);
    }
}
