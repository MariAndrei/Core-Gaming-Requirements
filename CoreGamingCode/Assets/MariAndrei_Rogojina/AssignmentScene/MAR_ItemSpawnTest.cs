using UnityEngine;

public class MAR_TestSpawner : MonoBehaviour
{
    private MAR_ItemSpawn itemSpawner;
    private GameObject lastSpawnedItem; // Keep track of last spawned

    void Start()
    {
        itemSpawner = FindFirstObjectByType<MAR_ItemSpawn>();

        if (itemSpawner == null)
            Debug.LogError("MAR_ItemSpawn not found in scene!");
    }

    void Update()
    {
        // Spawn new item with Space
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 spawnPos = transform.position + transform.forward * 2f;
            GameObject spawnedItem = itemSpawner.SpawnRandomItem(spawnPos);

            if (spawnedItem != null)
            {
                lastSpawnedItem = spawnedItem; // track it
                Debug.Log("Spawned: " + spawnedItem.name);
            }
        }

        // Remove last spawned item with U
        if (Input.GetKeyDown(KeyCode.U))
        {
            if (lastSpawnedItem != null)
            {
                Destroy(lastSpawnedItem);
                Debug.Log("Removed last spawned item");
                lastSpawnedItem = null;
            }
            else
            {
                Debug.Log("No item to remove");
            }
        }
    }
}