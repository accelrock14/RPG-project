using UnityEngine;

public class CharectorStats : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth { get; private set; }

    public stat damage;
    public stat armor;

    public void Awake()
    {
        currentHealth = maxHealth;
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        damage = Mathf.Clamp(damage, 0, int.MaxValue);
        Debug.Log(transform.name + "takes" + damage + "damage");

        if(currentHealth<=0)
        {
            Die();
        }
    }
    public virtual void Die()
    {
        
    }
}
