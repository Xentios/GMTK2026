using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class Item : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float startSpeed = 1f;
    [SerializeField] private float acceleration = 0.3f;
    [SerializeField] private float maxSpeed = 6f;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    private float currentSpeed;

    private bool isDragging;

    public ItemType ItemType { get; private set; }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        rb.gravityScale = 0;
        currentSpeed = startSpeed;
    }

    private void FixedUpdate()
    {
        if (isDragging)
            return;

        currentSpeed += acceleration * Time.fixedDeltaTime;
        currentSpeed = Mathf.Min(currentSpeed, maxSpeed);

        rb.linearVelocity = Vector2.down * currentSpeed;
    }

    public void Initialize(ItemInfo info)
    {
        ItemType = info.type;

        int randomSprite = Random.Range(0, info.sprites.Length);

        spriteRenderer.sprite = info.sprites[randomSprite];
    }

    public void StartDrag()
    {
        isDragging = true;

        rb.linearVelocity = Vector2.zero;
    }

    public void EndDrag()
    {
        isDragging = false;

        currentSpeed = startSpeed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Item çarptı: " + other.name);
    }
}