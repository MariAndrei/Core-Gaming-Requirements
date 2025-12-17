using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar_Script_GT : MonoBehaviour
{
       
    private float health = 70f;
    private float targetX = 7f;
    private float speed = 10f;
    private float damage = 2.5f;

    private float regenDelay = 0.3f;
    private float regenRate = 8f;
    private float lastDamageTime;

    private Material mat;
    private float visibility = 0f;      // shader float 0 → 1
    private float visibilitySpeed = 5f; // speed of transition

    void Start()
    {
        
    }   

    void Update()
    {
        if (mat != null)
        {
            // --- HANDLE VISIBILITY ---
            if (Input.GetKey(KeyCode.Space))
            {
                // increase shader visibility toward 1
                visibility = Mathf.Lerp(visibility, 1f, Time.deltaTime * visibilitySpeed);
            }
            else
            {
                // decrease shader visibility toward 0
                visibility = Mathf.Lerp(visibility, 0f, Time.deltaTime * visibilitySpeed);
            }

            // apply to shader
            mat.SetFloat("_Visibility", visibility);
        }

        // --- HEALTH BAR WIDTH ---
        Vector3 scale = transform.localScale;
        scale.x = Mathf.Lerp(scale.x, targetX, Time.deltaTime * speed);
        transform.localScale = scale;

        // --- DAMAGE ---
        if (Input.GetKey(KeyCode.Space))
        {
            if (health > 0f)
            {
                health -= damage * 10f * Time.deltaTime;
                lastDamageTime = Time.time;

                targetX = (health / 70f) * 7f;
                targetX = Mathf.Max(targetX, 0f);
            }
            else
            {
                targetX = 0f;
            }
        }

        // --- REGEN ---
        if (Time.time - lastDamageTime > regenDelay && health < 70f)
        {
            health += regenRate * Time.deltaTime;
            health = Mathf.Min(health, 70f);

            targetX = (health / 70f) * 7f;
        }

        if (health == 35f) {
            
        }
    }
}
