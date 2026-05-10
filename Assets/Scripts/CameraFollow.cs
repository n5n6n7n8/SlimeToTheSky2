using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float smoothSpeed = 5f;

    private float fixedX;
    private float fixedZ;

    void Start()
    {
        fixedX = transform.position.x;
        fixedZ = transform.position.z;
    }

    void LateUpdate()
    {
        if (player == null) return;

        float targetY = player.position.y;
        Vector3 targetPos = new Vector3(fixedX, targetY, fixedZ);
        transform.position = Vector3.Lerp(transform.position, targetPos, smoothSpeed * Time.deltaTime);
    }
}