using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 1; // Points de vie de l'ennemi

    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Enemy Killed!");
        Destroy(gameObject); // Détruit l'ennemi
    }
}
