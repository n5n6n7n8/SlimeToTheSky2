using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI gameOverText;
    public float flashSpeed = 1f;

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        // Flash by toggling alpha
        float alpha = Mathf.PingPong(Time.time * flashSpeed, 1f);
        gameOverText.alpha = alpha;

        if (timer >= 3f)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("FinalScene");
        }
    }
}