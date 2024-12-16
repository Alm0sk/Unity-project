using UnityEngine;
using UnityEngine.SceneManagement; // N�cessaire pour charger des sc�nes

public class PlayerHealth : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Charge la sc�ne GameOver
            SceneManager.LoadScene("GameOver");
        }
    }

    // Si tu utilises des triggers au lieu de collisions physiques
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            // Charge la sc�ne GameOver
            SceneManager.LoadScene("GameOver");
        }
    }
}