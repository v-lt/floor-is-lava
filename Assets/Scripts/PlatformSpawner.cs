using UnityEngine;
public class PlatformSpawner : MonoBehaviour
{
    public GameObject platformPrefab;
    public Transform player;
    public float distanceBetweenPlatforms = 1.0f;
    private float lastPlatformY;

    void Start()
    {
        // Initial platform height (should match where the first platform is)
        lastPlatformY = 0f;

        // Generate a few starter platforms
        for (int i = 1; i <= 5; i++)
        {
            SpawnPlatform(lastPlatformY + i * distanceBetweenPlatforms);
        }
    }

    void Update()
    {
        // Spawn platform when player gets near top of current set
        if (player.position.y + 10f > lastPlatformY)
        {
            SpawnPlatform(lastPlatformY + distanceBetweenPlatforms);
        }
    }
    void SpawnPlatform(float y)
    {
        float x = Random.Range(-2.5f, 2.5f); // Spread platforms horizontally
        GameObject platform = Instantiate(platformPrefab, new Vector3(x, y, 0), Quaternion.identity);

        // Set to Ground layer
        platform.layer = LayerMask.NameToLayer("Ground");

        lastPlatformY = y;
    }
}