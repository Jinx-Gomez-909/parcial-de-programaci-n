using System;
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour
{
    [Header("CameraMovement")] //los headers ayudan a separar secciones de código y a ubicar cosas
    private Vector3 objetive;
    [SerializeField] private new Camera camera;

    [Header("PlayerMovement")]
    [SerializeField] private float speedMovement = 10f;
    private Vector2 direction;
    private Rigidbody2D rb2d;
    Vector2 input;

    [Header("UI")]
    [SerializeField] private Slider slider;

    [Header("SoundFx")]
    [SerializeField] AudioClip deathSound;
    [SerializeField] AudioSource audioSource;

    [Header("Animations")]
    [SerializeField] private Animator anim;

    [Header("PlayerHealth")]
    private float maxHealth = 10;
    [SerializeField] private float health = 10;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //segir mouse
        objetive = camera.ScreenToWorldPoint(Input.mousePosition);
        float angleRad = MathF.Atan2(objetive.y - transform.position.y, objetive.x - transform.position.x);
        float angleDeg = (180 / MathF.PI) * angleRad - 90;
        transform.rotation = Quaternion.Euler(0, 0, angleDeg);

        //movimiento
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");
        direction = input.normalized;

    }
    //el fixedupdate se ejecuta una vez cada cierto tiempo determinado (0.02 segundos por defecto)
    private void FixedUpdate() //El fixed update se usa para hacer calculos en el sistema de físicas, recomiendan usarlo al aplicar fuerzas en el rigidbody 
    {
        rb2d.MovePosition(rb2d.position + direction * speedMovement * Time.fixedDeltaTime);
        //puede que no termine apliccando fuerzas en el rigidBody,pero lo dejo así por cualquier cambio en el futuro
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            health--;
            slider.value = health / maxHealth;
            if (health <= 0)
            {
                Die();
            }
        }
        if (collision.gameObject.CompareTag("heal"))
        {

            if (health < maxHealth)
            {
                Destroy(collision.gameObject);
                health += 3;
                if (health >= maxHealth)
                {
                    health = maxHealth;
                }
                slider.value = health / maxHealth;
            }
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyMother"))
        {
            health = 0;
            slider.value = health / maxHealth;
            Die();
        }
    }

    public void Die()
    {
        speedMovement = 0f;
        audioSource.PlayOneShot(deathSound);
        anim.SetBool("Death", true);
    }
    public void Destroy()
    {
        Destroy(gameObject);
    }
}
    