using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    private Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer sprinteRenderer;
    
    // Variables internes
    public bool isMovingRight = false;
    private bool isMovingLeft = false;
    private bool isGrounded = false; // Nécessite une gestion pour savoir quand on est au sol


    public AudioSource audioSource_jump; // Référence à l'AudioSource
    public AudioSource audioSource_shoot;
    public AudioClip jumpSound;
    public AudioClip shootSound;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator.SetBool("OnceTime", true);

        if (audioSource_jump == null)
        {
            audioSource_jump = GetComponent<AudioSource>();
        }

        if (audioSource_shoot == null)
        {
            audioSource_shoot = GetComponent<AudioSource>();
        }
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
        
    }



/// ////////////////////////////////////////////////


    // Fonctions appelées par les boutons
    public void MoveRightDown()
    {
        if (Time.timeScale == 0)
                return;
        isMovingRight = true;
    }

    public void MoveRightUp()
    {
        if (Time.timeScale == 0)
                return;
        isMovingRight = false;
    }

    public void MoveLeftDown()
    {
        if (Time.timeScale == 0)
                return;
        isMovingLeft = true;
    }

    public void MoveLeftUp()
    {
        if (Time.timeScale == 0)
                return;
        isMovingLeft = false;
    }

    public void Jump()
    {
        
        if (Time.timeScale == 0)
                return;
        if (isGrounded)
        {            
            
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            audioSource_jump.PlayOneShot(jumpSound);
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
    public float fireRate = 0.2f;       // Intervalle entre deux tirs

    private float nextFireTime = 0f;

  

    void HandleMovement()
    {
      
        // Logique de déplacement horizontale si nécessaire
        float move = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * move * Time.deltaTime * 5f);
    }

    public void OnShootButtonPressed()
    {
        if (Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireRate;
        }
    }

    void Shoot()
    {
        // Instancie un projectile et le positionne au "firePoint"
        Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
        audioSource_shoot.PlayOneShot(shootSound);
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