// using UnityEngine;

// public class PlayerMovement : MonoBehaviour
// {
//     public float moveSpeed = 5f;
//     public Rigidbody2D rb;
//     private Vector2 velocity = Vector2.zero;

//     void Start()
//     {
//         rb = GetComponent<Rigidbody2D>();
//     }

//     void FixedUpdate()
//     {

//         // Movements

//         float horizontalMovement = 0f;

//         if (Input.GetKey(KeyCode.Q))
//         {
//             horizontalMovement = 200;
//         }
//         else if (Input.GetKey(KeyCode.D))
//         {
//             horizontalMovement = -200;
//         }
        
//         MovePlayer(horizontalMovement);
//     }
    
//     void MovePlayer(float _horizontalMovement)
//     {
//         Vector2 targetVelocity = new(_horizontalMovement, rb.linearVelocity.y);
//         rb.linearVelocity = Vector2.SmoothDamp(rb.linearVelocity, targetVelocity, ref velocity, .05f);
//     }
// }


using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    private Rigidbody2D rb;

    // Variables internes
    private bool isMovingRight = false;
    private bool isMovingLeft = false;
    private bool isGrounded = false; // Nécessite une gestion pour savoir quand on est au sol

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Gestion du déplacement horizontal
        float horizontal = 0f;
        if (isMovingRight) horizontal = 1f;
        if (isMovingLeft) horizontal = -1f;

        Vector2 velocity = rb.linearVelocity;
        velocity.x = horizontal * moveSpeed; // Modifie uniquement la vitesse horizontale
        rb.linearVelocity = velocity;
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
}