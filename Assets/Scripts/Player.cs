using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement Instance { get; private set; }

    [SerializeField] private float speed;
    [SerializeField] private LayerMask groundLayer;

    public float gravity = 9.81f * 2f;

    private BoxCollider2D boxCollider;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = rb.GetComponent<BoxCollider2D>();
        rb.velocity = Vector2.down * gravity * Time.deltaTime;
    }

    private void Update()
    {
        /*rb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, rb.velocity.y);*/
        
        if (Input.GetKeyDown(KeyCode.UpArrow))
            Jump(speed, -1.5f);
        else if (Input.GetKeyDown(KeyCode.DownArrow))
            Jump(-speed, 1.5f);
    }

    private void Jump(float _speed, float localScaleY)
    {
        if(isGrounded() || onWall())
        {
            rb.velocity = new Vector2(rb.velocity.x, _speed);
            transform.localScale = new Vector3(1.5f, localScaleY, 1.5f); 
        }
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
            GameManager.Instance.GameOver();
        }
    }
}
