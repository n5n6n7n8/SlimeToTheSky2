using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public GameObject backgroundPrefab;
    public Transform player;
    public float backgroundHeight = 10f; // match the height of your background sprite

    private float topY;

    void Start()
    {
        topY = backgroundPrefab.transform.position.y;
    }

    void Update()
    {
        if (player.position.y + backgroundHeight > topY)
        {
            topY += backgroundHeight;
            Instantiate(backgroundPrefab, new Vector3(0f, topY, 0f), Quaternion.identity);
        }
    }
}