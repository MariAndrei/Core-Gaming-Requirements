using System.Collections.Generic;
using UnityEngine;

public class MAR_ItemSpawn : MonoBehaviour
{
    [Header("Assign Prefabs")]
    public GameObject rockPrefab;
    public GameObject swordPrefab;
    public GameObject potionPrefab;

    private List<GameObject> itemPrefabs;

    void Awake()
    {
        // Add prefab references to list
        itemPrefabs = new List<GameObject> { rockPrefab, swordPrefab, potionPrefab };
    }

    // Spawn a random item prefab at the specified position
    public GameObject SpawnRandomItem(Vector3 position)
    {
        if (itemPrefabs.Count == 0) return null;

        int index = Random.Range(0, itemPrefabs.Count);
        GameObject prefabToSpawn = itemPrefabs[index];

        GameObject spawned = Instantiate(prefabToSpawn, position, Quaternion.identity);

        // Assign ItemClass based on prefab
        MAR_WorldItem worldItem = spawned.GetComponent<MAR_WorldItem>();
        if (worldItem != null)
        {
            switch (prefabToSpawn.name)
            {
                case "RockPrefab":
                    worldItem.itemData = new ItemClass("A Rock", 0, "This is one boring rock!!", 1.2f);
                    break;
                case "SwordPrefab":
                    worldItem.itemData = new RS_Weapon("Rapier", 1, "Sharp but flimsy!!", 0.8f, 35);
                    break;
                case "PotionPrefab":
                    worldItem.itemData = new RS_ConsumableItem("Green Potion", 2, -50);
                    break;
            }
        }

        return spawned;
    }
}