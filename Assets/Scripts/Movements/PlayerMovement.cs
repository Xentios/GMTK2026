using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private KeyBinder keyBinder;

    [SerializeField]
    private float moveForce = 10f;

    [SerializeField]
    private float jumpForce = 11f;

    private float movementX;
    private Rigidbody2D myBody;

    private bool isGrounded = true;
    private bool jumpPressed = false;
    private string GROUND_TAG = "Ground";
    private void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        keyBinder = GetComponent<KeyBinder>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeyboard();

        if (keyBinder.IsJumping())  //Input.GetButtonDown("Jump"))
        {
            jumpPressed = true;
        }
    }
    private void FixedUpdate()
    {
        PlayerJump();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GROUND_TAG))
        {
            isGrounded = true;
        }
    }
    void PlayerMoveKeyboard()
    {
        movementX = keyBinder.GetMovement().x;
        transform.position += new Vector3(movementX, 0f, 0f) * moveForce * Time.deltaTime;
    }
    void PlayerJump()
    {
        if (jumpPressed && isGrounded)
        {
            jumpPressed = false;
            isGrounded = false;
            myBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        jumpPressed = false;
    }
}
