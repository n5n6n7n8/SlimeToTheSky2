
using UnityEngine;

public class Platform : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float platformSize = 1.5f;
    Transform transform;
    public void Start()
    {
        transform = GetComponent<Transform>();
    }
    public void Initialize(float pSize, float xpos, float ypos) {
        platformSize = pSize;
        transform.localScale = new Vector3(platformSize, transform.localScale.y, transform.localScale.z);
        transform.position = new Vector2(xpos, ypos);
        
    }
    public void Initialize(float xpos, float ypos) {
        transform.localScale = new Vector3(platformSize, transform.localScale.y, transform.localScale.z);
        transform.position = new Vector2(xpos, ypos);
    }

}
