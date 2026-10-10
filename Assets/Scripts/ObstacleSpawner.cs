using Unity.Scripting.LifecycleManagement;
using UnityEngine;

[AutoStaticsCleanup]
public partial class ObstacleSpawner : MonoBehaviour
{
    public GameObject cactusPrefab;
    public Transform spawnPoint;
    public float spawnDelay;
    public static bool doesSpawning = true;

    private float timer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        doesSpawning = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!doesSpawning) return;

        timer += Time.deltaTime;

        if (timer >= spawnDelay)
        {
            Instantiate(cactusPrefab, spawnPoint);
            timer = 0f;
        }
    }
}
