using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public int health = 1; // Points de vie de l'ennemi

    public int points = 10; // Points ajout�s au score quand d�truit

    private ScoreManager scoreManager;


    private void Start()
    {
        // Trouve dynamiquement le ScoreManager dans la sc�ne
        scoreManager = FindObjectOfType<ScoreManager>();

        if (scoreManager == null)
        {
            Debug.LogError("ScoreManager introuvable dans la sc�ne !");
        }
    }


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

        if (scoreManager != null)
        {
            Debug.Log("Enemy Killed! ajout de" + points);
            scoreManager.AddScore(points);
        }

        Debug.Log("Enemy Killed!");
        Destroy(gameObject); // D�truit l'ennemi
    }
}
