using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    public int health = 100;
    private int currentHealth;

    void Start()
    {
        currentHealth = health;
    }
}
