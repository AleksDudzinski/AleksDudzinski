using UnityEngine;

public class P1 : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Vector2 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        bool up = Input.GetKey(KeyCode.W);
        bool down = Input.GetKey(KeyCode.S);

        if (up)
            transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);

        if (down)
            transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
    }

    public void ResetPosition()
    {
        transform.position = startPos;
    }
}
