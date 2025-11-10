using UnityEngine;

using System.Collections;
using System.Collections.Generic;

public class Ball : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        Launch();
    }

    public void Reset()
    {
        rb.linearVelocity = Vector2.zero;
        transform.position = startPosition;
        Launch();
    }
    void Update()
    {

    }

    private void Launch()
    {
        float x = Random.Range(0, 2) == 0 ? -1 : 1;
        float y = Random.Range(0, 2) == 0 ? -1 : 1;
        rb.linearVelocity = new Vector2(speed * x, speed * y);
    }
}
