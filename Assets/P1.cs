using UnityEngine;

public class P1 : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Vector2 startPos;

    public float minY = -4f;
    public float maxY = 4f;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float move = 0f;

        if (Input.GetKey(KeyCode.W))
            move = moveSpeed * Time.deltaTime;

        if (Input.GetKey(KeyCode.S))
            move = -moveSpeed * Time.deltaTime;

        transform.Translate(0, move, 0);

        Vector3 pos = transform.position;
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        transform.position = pos;
    }

    public void ResetPosition()
    {
        transform.position = startPos;
    }
}
