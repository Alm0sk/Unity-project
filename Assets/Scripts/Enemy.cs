using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public int health = 1; // Points de vie de l'ennemi
    public bool isBoss = false; // Est-ce un boss ?
    public int points = 10; // Points ajout�s au score quand d�truit
    public SpriteRenderer sprinteRenderer;

    // Mouvement de l'ennemi
    public bool isMoving; // L'ennemi est-il en mouvement ?
    public float moveSpeed = 2f;

    public AudioSource audioSource_destroy;
    public AudioClip destroySound;

    public float moveRange = 5f;
    private ScoreManager scoreManager;
    private Vector3 startPosition;
    private bool movingRight = true;

    private void Start()
    {
        // Trouve dynamiquement le ScoreManager dans la sc�ne
        scoreManager = FindObjectOfType<ScoreManager>();
        startPosition = transform.position;

        if (audioSource_destroy == null)
        {
            audioSource_destroy = GetComponent<AudioSource>();
        }
    }


    private void FixedUpdate()
    {
        if (isMoving)
        {
            // Déplacement de l'ennemi
            if (movingRight)
            {
                transform.position += Vector3.right * moveSpeed * Time.deltaTime;
                if (transform.position.x >= startPosition.x + moveRange)
                {
                    movingRight = false;
                }
            }
            else
            {
                transform.position += Vector3.left * moveSpeed * Time.deltaTime;
                if (transform.position.x <= startPosition.x - moveRange)
                {
                    movingRight = true;
                }
            }
        }
        Flip(movingRight);
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

        if (isBoss)
        {
            // Si l'ennemi est un boss, on charge la sc�ne de fin
            SceneManager.LoadScene("GameOver");
        }

        if (audioSource_destroy != null)
        {
            audioSource_destroy.PlayOneShot(destroySound);
        }
    }

    void Flip(bool _movingRight)
    {
        // Inverse la direction du sprite
        if (_movingRight)
        {
            sprinteRenderer.flipX = false;
        }
        else if (!_movingRight)
        {
            sprinteRenderer.flipX = true;
        }
    }
}
