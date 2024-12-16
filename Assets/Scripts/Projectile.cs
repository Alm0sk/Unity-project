using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f; // Vitesse du projectile
    public int damage = 1;    // Dégâts infligés

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = Vector2.down * speed; // Envoie le projectile vers le bas
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            // Inflige des dégâts à l'ennemi
            Enemy enemy = collision.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
            Destroy(gameObject); // Détruit le projectile
        }

        // Détruit le projectile lorsqu'il touche autre chose (optionnel)
        if (collision.CompareTag("Ground") || collision.CompareTag("Platform"))
        {
            Destroy(gameObject);
        }
    }
}
