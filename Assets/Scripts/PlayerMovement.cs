using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float jumpAmt = 5f;
    [SerializeField] private float moveSpeed = 2f;
    Rigidbody2D rb;
    public int maxJumps = 5;
    public int jumps = 6;
    private bool shouldJump = false;
    private bool gameStarted = false;
    public float fallThreshold = 5f;
    public float gravityScale = 3f;
    private float highestPlayerY;
    bool canJump = true;
    Collider2D toDestroy;
    public GameObject titleText;
    public GameObject pressSpaceText;
    public Slider slider;
    SpriteRenderer sr;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
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
                rb.gravityScale = gravityScale;
                titleText.SetActive(false);
                pressSpaceText.SetActive(false);
            }
            return;
        }

        if (transform.position.y > highestPlayerY)
        {
            highestPlayerY = transform.position.y;
        }
        if (highestPlayerY - transform.position.y > fallThreshold)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
        }

        if (keyboard.spaceKey.wasPressedThisFrame && canJump && jumps > 0)
        {
            shouldJump = true;
        }
        if (keyboard.aKey.isPressed)
        {
            sr.flipX = false;
            rb.linearVelocity = new Vector2(-moveSpeed, rb.linearVelocity.y);
        }
        else if (keyboard.aKey.wasReleasedThisFrame)
        {
            rb.linearVelocity = new Vector2(0f, rb.linearVelocity.y);
        }
        if (keyboard.dKey.isPressed)
        {
            sr.flipX = true;
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
            slider.value = jumps;
            rb.linearVelocity = new Vector2(0f, 0f);
            rb.AddForce(Vector2.up * jumpAmt, ForceMode2D.Impulse);
            shouldJump = false;
            Destroy(toDestroy.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            Debug.Log("in");
            canJump = true;
            toDestroy = other;
        }
        else if (other.gameObject.CompareTag("Pizza"))
        {
            jumps += 5;
            if (jumps > maxJumps)
            {
                jumps = maxJumps;
            }
            slider.value = jumps;
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Lava"))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("GameOver");
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