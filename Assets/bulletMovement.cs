using UnityEngine;

public class bulletMovement : MonoBehaviour
{
    [SerializeField] private int speed = 30;
    private float timeDes = 0.5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, timeDes);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0,speed * Time.deltaTime,0);

    }
}
    