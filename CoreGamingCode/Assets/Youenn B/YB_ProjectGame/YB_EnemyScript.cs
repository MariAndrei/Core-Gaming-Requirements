using UnityEngine;

public class YB_EnemyScript : MonoBehaviour
{
    internal void Bump(float explosionForce, Vector3 explosionPosition, float explosionRadius)
    {
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.color = Color.red;
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.AddExplosionForce(explosionForce, explosionPosition, explosionRadius);
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}