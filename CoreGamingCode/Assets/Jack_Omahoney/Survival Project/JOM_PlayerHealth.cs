using System.Collections.Generic;
using UnityEngine;

public class JOM_PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;

    [Header("Health Bar Script")]
    public HS_BarControl healthBar; // Drag your HealthBar UI here

    public class TimedEffect
    {
        public float amountPerSecond;      // positive = heal, negative = damage
        public MAR_TimerScript timer;      // attached timer component
    }

    private List<TimedEffect> activeEffects = new List<TimedEffect>();

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    
    }

    private void Update()
    {
        // Apply all active timed effects
        for (int i = activeEffects.Count - 1; i >= 0; i--)
        {
            TimedEffect effect = activeEffects[i];

            if (effect.timer.GetTimeRemaining() > 0)
            {
                if (effect.amountPerSecond > 0)
                    Heal(effect.amountPerSecond * Time.deltaTime);
                else
                    TakeDamage(-effect.amountPerSecond * Time.deltaTime);
            }
            else
            {
                Destroy(effect.timer);          // remove timer component
                activeEffects.RemoveAt(i);      // remove effect
            }
        }
    }

    public void TakeDamage(float amount)
    {
        currentHealth = Mathf.Max(currentHealth - amount, 0f);
        UpdateHealthBar();
    }

    public void Heal(float amount)
    {
        currentHealth = Mathf.Min(currentHealth + amount, maxHealth);
        UpdateHealthBar();
    }

    public void ApplyTimedEffectUsingTimer(float perSecond, float duration)
    {
        MAR_TimerScript timer = gameObject.AddComponent<MAR_TimerScript>();
        timer.InitialiseTimer(duration);
        timer.StartTimer();

        TimedEffect effect = new TimedEffect
        {
            amountPerSecond = perSecond,
            timer = timer
        };

        activeEffects.Add(effect);
    }

    void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            healthBar.SetBarValue(currentHealth);

            // OPTIONAL: You can make it change color too
            healthBar.BarColourChange(
                fullHealth: 70f,
                middleHealth: 30f,
                fullHealthColor: Color.green,
                middleHealthColor: Color.yellow,
                lowHealthColor: Color.red
            );
        }
    }
}
