using UnityEngine;

public class P2 : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Vector2 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        bool up = Input.GetKey(KeyCode.UpArrow);
        bool down = Input.GetKey(KeyCode.DownArrow);

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
