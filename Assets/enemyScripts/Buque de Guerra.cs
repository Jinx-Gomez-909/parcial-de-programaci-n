using UnityEngine;
using UnityEngine.UI;

public class mothership : MonoBehaviour
{

    [Header("Animations")]
    [SerializeField] private Animator anim;

    [Header("SoundFx")]
    [SerializeField] AudioClip deathSound;
    [SerializeField] AudioSource audioSource;

    [Header("MothershipStats")]
    [SerializeField] private float health = 30;
    float maxHealth = 30;
    [SerializeField] private GameObject objectToSpawn;

    [Header ("UI")]
    [SerializeField] private Slider slider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            Destroy(collision.gameObject);
            health--;
            slider.value = health/maxHealth;
            if (health <= 0)
            {
                audioSource.PlayOneShot(deathSound);
                anim.SetBool("Death", true);
            }
        }
    }

    public void Destroy()
    {
        Instantiate(objectToSpawn, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
