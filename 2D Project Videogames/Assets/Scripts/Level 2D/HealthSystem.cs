using System;

public class HealthSystem{
    private int health;
    private int maxHealth;
    public event EventHandler OnHealthChanged;

    public HealthSystem(int maxHealth) {
        this.maxHealth = maxHealth;
        health = maxHealth;
    }

    public int GetHealth() {
        return health;
    }

    public float GetHealthPercent() {
        return (float) health / maxHealth; 
    }

    public void TakeDamage(int damage) {
        health -= damage;

        OnHealthChanged?.Invoke(this, EventArgs.Empty);
    }

    public void Heal(int healAmount) {
        health += healAmount;
        if (health > maxHealth)
            health = maxHealth;

        OnHealthChanged?.Invoke(this, EventArgs.Empty);
    }
}
