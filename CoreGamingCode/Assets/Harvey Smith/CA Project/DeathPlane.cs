using UnityEngine;

public class DeathPlane : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


    }

    /// <summary>
    /// Handles collision events by resetting the position and velocity of the colliding object if it meets specific
    /// conditions.
    /// </summary>
    /// <remarks>If the colliding object has the tag <see langword="Player"/>, its position is reset to a
    /// predefined location. Additionally, if the colliding object has a <see cref="Rigidbody"/> component, its linear
    /// and angular velocities are set to zero.</remarks>
    /// <param name="collision">The collision data containing information about the colliding object.</param>
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.transform.position = new Vector3(551, 1000, 584);
        }

        Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;        
            rb.angularVelocity = Vector3.zero;  
        }
    }
}
