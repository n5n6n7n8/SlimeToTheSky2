using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public Transform player;
    public TextMeshProUGUI scoreText;

    private float highestY;
    private float startY; // ADD THIS
    private int score;
    
    void Start()
    {
        highestY = player.position.y;
        startY = player.position.y; // ADD THIS
    }

    void Update()
    {
        if (player.position.y > highestY)
        {
            highestY = player.position.y;
            score = Mathf.FloorToInt((highestY - startY) * 10f); // CHANGED THIS
            scoreText.text = score.ToString();
        }
    }
}