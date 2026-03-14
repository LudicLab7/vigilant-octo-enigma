using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    public int health = 100;
    private int currentHealth;
    
    [SerializeField]
    private bool IsLiving = true;
    void Start()
    {
        currentHealth = health;
    }
    public void TakeDamage(int damage)
    {
        health = currentHealth - damage;
        if(health <= 0)
        {
            health = 0; //funkcja na umieranie czy cos ewentualnie animacja lub ragdoll, ale to juz pozniej
            IsLiving = false;
        }
    }
}
