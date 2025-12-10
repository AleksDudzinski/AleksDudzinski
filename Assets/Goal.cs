using UnityEngine;

public class Goal : MonoBehaviour
{
    public bool isPlayerOneGoal = true;

    private GameManager gm;

    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        if (gm == null)
            Debug.LogError("Brak GameManagera w scenie!");
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Ball"))
        {
            gm.GoalScored(isPlayerOneGoal);
        }
    }
}
