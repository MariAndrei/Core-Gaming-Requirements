using TMPro;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    /// <summary>
    /// An array of spawn points represented as <see cref="Transform"/> objects.
    /// </summary>
    /// <remarks>Each element in the array defines a position and orientation in the scene where objects can
    /// be spawned.  Ensure that the array is populated with valid references before use.</remarks>
    public Transform[] spawnPoints;

    public TextMeshProUGUI highScore;
    public int counter = 0;
    Vector3 rotationSpeed = new Vector3(0f, 100f, 0f);

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            MoveToNextPosition();
            counter++;
        }
    }
    /// <summary>
    /// Moves the object to a randomly selected position from the available spawn points.
    /// </summary>
    /// <remarks>If no spawn points are defined, the method exits without making any changes to the object's
    /// position.</remarks>
    private void MoveToNextPosition()
    {
        if (spawnPoints.Length == 0) return; // No positions set

        // Pick a random position from the list
        int index = Random.Range(0, spawnPoints.Length);

        // Move the collectible to that position
        transform.position = spawnPoints[index].position;

        
    }
    /// <summary>
    /// Updates the object's rotation based on the specified rotation speed and the elapsed time since the last frame.
    /// </summary>
    /// <remarks>This method applies a rotation to the object by multiplying the rotation speed with the time
    /// elapsed since the last frame. It is typically called once per frame to ensure smooth and consistent rotation
    /// over time.</remarks>
    private void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }



}