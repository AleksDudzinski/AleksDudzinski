using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rb;
    public float startingSpeed = 5f;

    private Vector2 startPos;

    void Start()
    {
        startPos = transform.position;
        LaunchBall();
    }

    void LaunchBall()
    {
        bool isRight = Random.value >= 0.5f;
        float xVelocity = isRight ? 1f : -1f;
        float yVelocity = Random.Range(-0.5f, 0.5f);
        rb.velocity = new Vector2(xVelocity, yVelocity).normalized * startingSpeed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Sprawdzamy, czy pi³ka uderzy³a w paletê
        if (collision.collider.CompareTag("Paddle"))
        {
            // Zwiêkszamy prêdkoœæ pi³ki o 1
            rb.velocity = rb.velocity.normalized * (rb.velocity.magnitude + 1f);

            // Zwiêkszamy prêdkoœæ palety o 0.5
            P1 p1 = collision.collider.GetComponent<P1>();
            P2 p2 = collision.collider.GetComponent<P2>();

            if (p1 != null)
                p1.moveSpeed += 0.5f;
            if (p2 != null)
                p2.moveSpeed += 0.5f;
        }
    }

    public void ResetPosition()
    {
        rb.velocity = Vector2.zero;
        transform.position = startPos;
        Invoke(nameof(LaunchBall), 1f);
    }

    public void StopBall()
    {
        rb.velocity = Vector2.zero;
    }
}
