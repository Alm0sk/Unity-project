using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    private Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer sprinteRenderer;
    // Variables internes
    private bool isMovingRight = false;
    private bool isMovingLeft = false;
    private bool isGrounded = false; // Nécessite une gestion pour savoir quand on est au sol

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        // Gestion du déplacement horizontal
        float horizontal = 0f;
        if (isMovingRight) horizontal = 1f;
        if (isMovingLeft) horizontal = -1f;

        Flip(horizontal);

        Vector2 velocity = rb.linearVelocity;
        velocity.x = horizontal * moveSpeed; // Modifie uniquement la vitesse horizontale
        rb.linearVelocity = velocity;

        animator.SetFloat("Vertical_speed", rb.linearVelocity.y);
        animator.SetBool("Grounded", isGrounded);

        HandleMovement();
        HandleShooting();
    }



    // Fonctions appelées par les boutons
    public void MoveRightDown()
    {
        isMovingRight = true;
    }

    public void MoveRightUp()
    {
        isMovingRight = false;
    }

    public void MoveLeftDown()
    {
        isMovingLeft = true;
    }

    public void MoveLeftUp()
    {
        isMovingLeft = false;
    }

    public void Jump()
    {
        if (isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    // Cette fonction est un exemple simplifié pour détecter le sol.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Si on touche quelque chose qui est le sol
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    public GameObject projectilePrefab; // Préfab du projectile
    public Transform firePoint;         // Point d'où part le projectile
    public float fireRate = 0.5f;       // Intervalle entre deux tirs

    private float nextFireTime = 0f;

  

    void HandleMovement()
    {
        // Logique de déplacement horizontale si nécessaire
        float move = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * move * Time.deltaTime * 5f);
    }

    void HandleShooting()
    {
        // Détection du toucher sur mobile
        if (Input.GetMouseButtonDown(0) && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        // Instancie un projectile et le positionne au "firePoint"
        Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
    }

    void Flip(float _horizontal)
    {
        // Inverse la direction du sprite
        if (_horizontal > 0.1f)
        {
            sprinteRenderer.flipX = false;
        }
        else if (_horizontal < -0.1f)
        {
            sprinteRenderer.flipX = true;
        }
    }

}