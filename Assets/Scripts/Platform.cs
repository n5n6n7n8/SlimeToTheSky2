
using UnityEngine;

public class Platform : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float platformSize = 1.5f;
    Transform transform;
    public void Start()
    {
        transform = GetComponent<Transform>();
        platformSize = Random.Range(0.05f, 0.2f);
        transform.localScale = new Vector3(platformSize, transform.localScale.y, transform.localScale.z);
    }

    public void Initialize(float xpos, float ypos) {
        transform.localScale = new Vector3(platformSize, transform.localScale.y, transform.localScale.z);
        transform.position = new Vector2(xpos, ypos);
    }
    public float getY()
    {
        return transform.position.y;
    }

}
