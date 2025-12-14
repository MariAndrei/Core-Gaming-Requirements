using UnityEngine;

public class YB_BulletScript : MonoBehaviour
{
    Rigidbody rb;

    float force = 60f;
    float explosionRadius = 1;
    float explosionStrength = 100;

    internal void launchMe(Vector3 dir)
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody>();
        }

        rb.AddForce(force * dir, ForceMode.Impulse);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        YB_EnemyScript enemyScript = collision.gameObject.GetComponent<YB_EnemyScript>();

        Collider[] allEnemies = Physics.OverlapSphere(transform.position + Vector3.down, explosionRadius);

        foreach (Collider collider in allEnemies)
        {
            YB_EnemyScript newEnemy = collider.gameObject.GetComponent<YB_EnemyScript>();

            if (newEnemy != null)
            {
                newEnemy.Bump(explosionStrength, transform.position + Vector3.down, explosionRadius);
            }
        }

        if (enemyScript != null)
        {
            enemyScript.Bump(explosionStrength, transform.position + Vector3.down, explosionRadius);

        }

    }
}
