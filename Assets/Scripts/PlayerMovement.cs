using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float jumpAmt = 5f;
    [SerializeField] private float moveSpeed = 2f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Rigidbody2D rb;
    private bool shouldJump = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var keyboard = Keyboard.current;
        if(keyboard == null)
        {
            Debug.Log("No keyboard detected");
            return;
        }
        if (keyboard.spaceKey.wasPressedThisFrame)
        {
            shouldJump = true;
        }
        if (keyboard.aKey.isPressed)
        {
            rb.linearVelocity = new Vector2(-moveSpeed, rb.linearVelocity.y);
        }
        else if (keyboard.aKey.wasReleasedThisFrame)
        {
            rb.linearVelocity = new Vector2(0f, rb.linearVelocity.y);
        }
        if (keyboard.dKey.isPressed)
        {
            rb.linearVelocity = new Vector2(moveSpeed, rb.linearVelocity.y);
        }
        else if (keyboard.dKey.wasReleasedThisFrame)
        {
            rb.linearVelocity = new Vector2(0f, rb.linearVelocity.y);
        }
    }
    void FixedUpdate()
    {
        if (shouldJump)
        {
            rb.linearVelocity = new Vector2(0f,0f);
            rb.AddForce(Vector2.up * jumpAmt, ForceMode2D.Impulse);
            shouldJump = false;
        }
    }
}
