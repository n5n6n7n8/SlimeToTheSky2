using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float jumpAmt = 5f;
    [SerializeField] private float moveSpeed = 2f;
    public Rigidbody2D rb;
    private bool shouldJump = false;
    private bool gameStarted = false;

    public GameObject titleText;
    public GameObject pressSpaceText;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
    }

    void Update()
    {
        var keyboard = Keyboard.current;
        if (keyboard == null)
        {
            Debug.Log("No keyboard detected");
            return;
        }

        if (!gameStarted)
        {
            if (keyboard.spaceKey.wasPressedThisFrame)
            {
                gameStarted = true;
                rb.gravityScale = 1f;
                titleText.SetActive(false);
                pressSpaceText.SetActive(false);
                shouldJump = true;
            }
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
            rb.linearVelocity = new Vector2(0f, 0f);
            rb.AddForce(Vector2.up * jumpAmt, ForceMode2D.Impulse);
            shouldJump = false;
        }
    }
}