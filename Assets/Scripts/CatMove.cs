using UnityEngine;

public class CatMove : MonoBehaviour
{
    [Header("Wandering Settings")]
    [Tooltip("Maximum distance from the starting point the cat can wander")]
    public float radius = 2f;
    [Tooltip("Movement speed in units per second")]
    public float speed = 0.3f;
    [Tooltip("Time in seconds between direction changes")]
    public float changeInterval = 3f;

    private Vector3 startPosition;
    private Vector3 targetPosition;
    private float timer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPosition = transform.position;
        ChooseNewTarget();
        timer = changeInterval;
    }

    // Update is called once per frame
    void Update()
    {
        // move towards the current target position without altering orientation
        Vector3 direction = (targetPosition - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;

        // if close to target, or timer expired, pick a new target
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f || timer <= 0f)
        {
            ChooseNewTarget();
            timer = changeInterval;
        }

        timer -= Time.deltaTime;
    }

    private void ChooseNewTarget()
    {
        // pick a random point within a circle on the XZ plane
        Vector2 randomCircle = Random.insideUnitCircle * radius;
        targetPosition = startPosition + new Vector3(randomCircle.x, 0f, randomCircle.y);
    }
}
