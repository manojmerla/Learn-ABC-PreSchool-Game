using UnityEngine;

public class BalloonMove : MonoBehaviour
{
    public float speed = 2f;  // upward speed
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Collider2D col;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();

        // Set upward velocity
        if (rb != null)
            rb.linearVelocity = Vector2.up * speed;
    }

    void Update()
    {
        // If balloon goes above screen
        if (transform.position.y > 6f)
            PopBalloon();
    }

    void OnMouseDown()
    {
        PopBalloon();
        // Play sound from BalloonPop script if needed
    }

    void PopBalloon()
    {
        // Make invisible
        if (sr != null) sr.enabled = false;
        // Stop physics
        if (rb != null) rb.linearVelocity = Vector2.zero;
        if (col != null) col.enabled = false;
    }
}
