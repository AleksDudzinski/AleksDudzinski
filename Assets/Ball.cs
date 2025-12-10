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
        bool isRight = UnityEngine.Random.value >= 0.5f;
        float xVelocity = isRight ? 1f : -1f;
        float yVelocity = UnityEngine.Random.Range(-0.5f, 0.5f);
        rb.velocity = new Vector2(xVelocity, yVelocity).normalized * startingSpeed;
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
