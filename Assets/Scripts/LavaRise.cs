using UnityEngine;

public class LavaRise : MonoBehaviour
{
    public Transform player;
    public float riseSpeed = 1f;
    public float offsetY = -5f; // how far below the player the lava stays

    private float highestY;

    void Start()
    {
        highestY = player.position.y;
    }

    void Update()
    {
        // only update highestY when player is going up
        if (player.position.y > highestY)
        {
            highestY = player.position.y;
        }

        float targetY = highestY + offsetY;

        // only rise, never fall
        if (targetY > transform.position.y)
        {
            transform.position = new Vector3(
                transform.position.x,
                Mathf.MoveTowards(transform.position.y, targetY, riseSpeed * Time.deltaTime),
                transform.position.z
            );
        }
    }
}