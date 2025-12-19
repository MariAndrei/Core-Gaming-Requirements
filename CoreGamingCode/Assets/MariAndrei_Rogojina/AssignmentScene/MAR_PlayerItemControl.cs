using System.Collections.Generic;
using UnityEngine;

public class MAR_PlayerItemController : MonoBehaviour
{

    public Transform playerCameraTransform;

    [Header("Pickup Settings")]
    private float pickupDistance = 3f;
    private KeyCode pickupKey = KeyCode.E;
    private KeyCode dropKey = KeyCode.Q;

    public MAR_ItemSpawn itemSpawner; 
    public GameObject rockPrefab;
    public GameObject swordPrefab;
    public GameObject potionPrefab;

    private RS_Inventory inventory;
    private MAR_WorldItem lookedAtItem;

    // Track picked-up items in order
    private List<ItemClass> pickedUpItems = new List<ItemClass>();

    void Start()
    {
        inventory = new RS_Inventory(20, 150f); 
    }

    void Update()
    {
        LookForItem();

        // Pick up item
        if (Input.GetKeyDown(pickupKey) && lookedAtItem != null)
        {
            ItemClass itemData = lookedAtItem.itemData;
            if (inventory.AddRequest(itemData))
            {
                pickedUpItems.Add(itemData);
                Debug.Log("Picked up: " + itemData.name);
                Destroy(lookedAtItem.gameObject);
                lookedAtItem = null;
            }
            else
            {
                Debug.Log("Cannot pick up: inventory full or overweight");
            }
        }

        // Drop last item
        if (Input.GetKeyDown(dropKey) && pickedUpItems.Count > 0)
        {
            ItemClass itemToDrop = pickedUpItems[pickedUpItems.Count - 1];

            // Remove from inventory
            inventory.RemoveRequest(itemToDrop.id);

            // Remove from local list
            pickedUpItems.RemoveAt(pickedUpItems.Count - 1);

            // Spawn in front of player
            Vector3 spawnPos = transform.position + transform.forward * 2f;
            GameObject prefabToSpawn = GetPrefabForItem(itemToDrop);
            if (prefabToSpawn != null)
            {
                GameObject dropped = Instantiate(prefabToSpawn, spawnPos, Quaternion.identity);
                MAR_WorldItem worldItem = dropped.GetComponent<MAR_WorldItem>();
                if (worldItem != null)
                    worldItem.itemData = itemToDrop;

                Debug.Log("Dropped: " + itemToDrop.name);
            }
        }
    }

    private MAR_WorldItem previousLookedAtItem = null; // Track previously looked-at item

    void LookForItem()
    {
        if (playerCameraTransform == null) return;

        Ray ray = new Ray(playerCameraTransform.position, playerCameraTransform.forward);
        RaycastHit hit;
        lookedAtItem = null;

        if (Physics.Raycast(ray, out hit, pickupDistance))
        {
            lookedAtItem = hit.collider.GetComponent<MAR_WorldItem>();

            // Only log when the looked-at item changes
            if (lookedAtItem != null && lookedAtItem != previousLookedAtItem)
            {
                Debug.Log("Looking at: " + lookedAtItem.itemData.name);
                previousLookedAtItem = lookedAtItem;
            }
        }
        else
        {
            // Reset previous if looking at nothing
            previousLookedAtItem = null;
        }

        Debug.DrawRay(playerCameraTransform.position, playerCameraTransform.forward * pickupDistance, Color.red);
    }

    GameObject GetPrefabForItem(ItemClass item)
    {
        if (item.name == "A Rock") return rockPrefab;
        if (item.name == "Rapier") return swordPrefab;
        if (item.name == "Green Potion") return potionPrefab;
        return null;
    }
}