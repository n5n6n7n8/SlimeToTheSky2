using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;





public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float jumpAmt = 5f;
    [SerializeField] private float moveSpeed = 2f;
    public Rigidbody2D rb;

    public int maxJumps = 40;
    public int jumps = 40;
    private bool shouldJump = false;
    private bool gameStarted = false;

    bool canJump = true; // is the player currently on a slime platform?

    Collider2D toDestroy;

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

        if (keyboard.spaceKey.wasPressedThisFrame && canJump && jumps > 0)
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
            jumps--;
            rb.linearVelocity = new Vector2(0f, 0f);
            rb.AddForce(Vector2.up * jumpAmt, ForceMode2D.Impulse);
            shouldJump = false;
            Destroy(toDestroy.gameObject);
        }
    }



    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.CompareTag("Platform"))
        {
            Debug.Log("in");
            canJump = true;
            toDestroy = other;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            Debug.Log("out");
            canJump = false;
            toDestroy = null;
        }
    }
}