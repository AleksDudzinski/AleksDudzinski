using UnityEngine;

public class Goal : MonoBehaviour
{
    [Tooltip("Zaznacz TRUE jeœli to bramka gracza 1 (po lewej stronie)")]
    public bool isPlayerOneGoal = true;

    private GameManager gm;

    void Start()
    {
        gm = FindObjectOfType<GameManager>();
        if (gm == null)
            Debug.LogError("Brak GameManagera w scenie!");
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Ball"))
        {
            gm.GoalScored(isPlayerOneGoal);
        }
    }
}
