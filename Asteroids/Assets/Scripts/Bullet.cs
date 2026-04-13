using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 15f;
    public float lifeTime = 2f;

    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        rb.linearVelocity = transform.up * speed;

        // Destroy after 2 seconds
        Destroy(gameObject, lifeTime);
    }
}
