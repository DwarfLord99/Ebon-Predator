using UnityEngine;

public interface IDamage
{
    // health
    public float Health { get; set; }
    // defense
    public int Defense { get; set; }

    public void TakeDamage(float damage);
    
    public void Die();

    public void RestoreHealth();
}
