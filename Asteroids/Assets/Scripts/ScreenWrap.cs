using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ScreenWrap : MonoBehaviour
{
    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void LateUpdate()
    {
        Camera cam = Camera.main;
        if (cam == null) return;

        Vector3 viewPos = cam.WorldToViewportPoint(rb.position);

        float buffer = 0.01f;

        // Wrap X
        if (viewPos.x > 1f + buffer)
            viewPos.x = 0f - buffer;
        else if (viewPos.x < 0f - buffer)
            viewPos.x = 1f + buffer;

        // Wrap Y
        if (viewPos.y > 1f + buffer)
            viewPos.y = 0f - buffer;
        else if (viewPos.y < 0f - buffer)
            viewPos.y = 1f + buffer;

        Vector3 newWorldPos = cam.ViewportToWorldPoint(viewPos);

        // Important: use rb.position, not transform.position
        rb.position = newWorldPos;
    }
}