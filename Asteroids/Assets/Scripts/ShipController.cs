using UnityEngine;
using UnityEngine.InputSystem;

public class ShipController : MonoBehaviour
{
    [Header("Movement")]
    public float rotationSpeed = 180f;   // degrees per second
    public float thrustForce = 8f;       // force applied while holding W
    public GameObject bulletPrefab;
    public Transform firePoint;

    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
    }

    void Update()
    {
        // A/D rotate (tank controls)
        float turn = 0f;
        if (Input.GetKey(KeyCode.A)) turn = 1f;
        if (Input.GetKey(KeyCode.D)) turn = -1f;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        }

        transform.Rotate(0f, 0f, turn * rotationSpeed * Time.deltaTime);
    }

    void FixedUpdate()
    {
        // W thrust (adds force in the ship's "up" direction)
        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(transform.up * thrustForce, ForceMode2D.Force);
        }
    }
}
