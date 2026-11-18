using UnityEngine;

public class spawnTIE : MonoBehaviour
{
    [SerializeField] private GameObject objectToSpawn;
    float timer;
    [SerializeField] private float timeToSpawm=1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > timeToSpawm)
        {
            Spawnear();
            timer = 0;
        }
    }
    void Spawnear()
    {
        Instantiate(objectToSpawn, transform.position, transform.rotation);
    }
}
