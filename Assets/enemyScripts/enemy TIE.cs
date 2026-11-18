using UnityEngine;

public class enemyTIE : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float moveSpeed = 1f;
    private Rigidbody2D rb;
    private Vector2 movement;

    [Header("Animations")]
    [SerializeField] private Animator anim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = player.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle-90;
        direction.Normalize();
        movement = direction;
    }

    private void FixedUpdate()
    {
        moveCharacter(movement);
    }
    void moveCharacter(Vector2 direction)
    {
        rb.MovePosition((Vector2)transform.position+(direction*moveSpeed*Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bullet")|| collision.gameObject.CompareTag("Player"))
        {
            if (collision.gameObject.CompareTag("bullet"))
            {
                Destroy(collision.gameObject);
                anim.SetBool("Death", true);
            }
            
        }
    }
    public void Destroy()
    {
        Destroy(gameObject);
    }
}
