using UnityEngine;
using UnityEngine.SceneManagement; // Nécessaire pour charger des scènes

public class PlayerHealth : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Charge la scène GameOver
            SceneManager.LoadScene("GameOver");
        }
    }

    // Si tu utilises des triggers au lieu de collisions physiques
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            // Charge la scène GameOver
            SceneManager.LoadScene("GameOver");
        }
    }
}