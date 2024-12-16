using UnityEngine;
using System.Collections;

public class Enemy_boss : MonoBehaviour
{
    public int health = 1; // Points de vie de l'ennemi
    public int points = 10; // Points ajoutés au score quand détruit
    public bool isMoving; // L'ennemi est-il en mouvement ?
    public float moveSpeed = 2f; // Vitesse de déplacement de l'ennemi
    public float moveRange = 5f; // Distance maximale de déplacement avant de changer de direction
    public GameObject projectilePrefab; // Préfabriqué du projectile
    public Transform firePoint; // Point de tir du projectile

    private ScoreManager scoreManager;
    private Vector3 startPosition;
    private bool movingRight = true;

    private void Start()
    {
        // Trouve dynamiquement le ScoreManager dans la scène
        scoreManager = FindObjectOfType<ScoreManager>();

        if (scoreManager == null)
        {
            Debug.LogError("ScoreManager introuvable dans la scène !");
        }

        startPosition = transform.position;

        // Démarre la coroutine pour tirer automatiquement
        StartCoroutine(ShootRoutine());
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
    }

    private IEnumerator ShootRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(2f, 5f));
            Shoot();
        }
    }

    private void Shoot()
    {
        if (projectilePrefab != null && firePoint != null)
        {
            Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
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
        Destroy(gameObject); // Détruit l'ennemi
    }
}