using UnityEngine;
using System;

public class HealthSystem : MonoBehaviour{
    public int health;
    public int maxHealth;
    public event EventHandler OnHealthChanged;

    public int GetHealth()
    {
        return health;
    }

    public float GetHealthPercent()
    {
        return (float) health / maxHealth; 
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        if(health<0)
        {
            health = 0;
        }
        OnHealthChanged?.Invoke(this, EventArgs.Empty);
    }

    public void Heal(int healAmount)
    {
        health += healAmount;
        if (health > maxHealth)
            health = maxHealth;

        OnHealthChanged?.Invoke(this, EventArgs.Empty);
    }
}
