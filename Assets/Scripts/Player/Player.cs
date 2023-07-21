using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement Instance { get; private set; }

    [SerializeField] private float speed;
    [SerializeField] private LayerMask groundLayer;

    private BoxCollider2D boxCollider;
    private Rigidbody2D rb;
    private Animator anim;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        /*rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y);*/
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            if (isGrounded() || onWall())
                Jump(speed, -1.5f);
        }    
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            if (isGrounded() || onWall())
                Jump(-speed, 1.5f);
        }    
            
    }

    private void Jump(float _speed, float localScaleY)
    {
        rb.velocity = new Vector2(rb.velocity.x, _speed);
        transform.localScale = new Vector3(1.5f, localScaleY, 1.5f); 
    }

    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }

    private bool onWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.up, 0.1f, groundLayer);
        return raycastHit.collider != null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Obstacle"))
        {
            anim.SetTrigger("die");
            Jump(-speed, 1.5f);
            enabled = false;
            GameManager.Instance.GameOver();
        }
    }
}
