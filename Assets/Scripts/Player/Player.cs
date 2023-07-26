using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public LayerMask groundLayer;

    private BoxCollider2D boxCollider;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
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

    public void Jump(float _speed, float localScaleY)
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

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Obstacle"))
        {
            collision.GetComponent<Health>().TakeDamage(damage);
            *//*Jump(-speed, 1.5f);
            enabled = false;
            GameManager.Instance.GameOver();*//*
        }
    }*/
}
