using UnityEngine;
//Decidí hacer esto en otro script para reutilizarlo en proyectos futuros
public class playerAttack : MonoBehaviour
{
    [Header ("SoundFx")]
    [SerializeField] AudioClip attackSound;
    [SerializeField] AudioSource audioSource;

    [Header ("ToCreateABullet")]
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject spawnBullet;

    [Header ("TimeBetweenBullets")]
    float timer;
    [SerializeField] private float timeBetweenBullets = 0.2f;
    
    private void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            timer += Time.deltaTime;
            if (timer > timeBetweenBullets)
            {
                Attack();
                timer = 0;
            }
        }
    }

    private void Attack()
    {
        Instantiate(bullet, spawnBullet.transform.position, spawnBullet.transform.rotation);
        audioSource.PlayOneShot(attackSound);
    }
}
