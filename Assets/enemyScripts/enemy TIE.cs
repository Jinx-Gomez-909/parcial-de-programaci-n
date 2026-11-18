using UnityEngine;

public class enemyTIE : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private Animator anim;

    private Rigidbody2D rb;
    private Transform player;
    private Vector2 movement;
    private bool isDead;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GameObject p = GameObject.FindWithTag("Player");
        if (p != null) player = p.transform;
    }

    void Update()
    {
        if (isDead || player == null) { movement = Vector2.zero; return; }
        movement = ((Vector2)player.position - rb.position).normalized;
    }

    void FixedUpdate()
    {
        if (isDead || player == null) return;

        float angle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg;
        rb.rotation = angle - 90f;
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (isDead || !collision.CompareTag("bullet")) return;

        isDead = true;
        Destroy(collision.gameObject);
        GetComponent<Collider2D>().enabled = false;
        anim.SetBool("Death", true);
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}