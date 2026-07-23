using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class Item : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float startSpeed = 1f;

    /* OLD SPEED SYSTEM */
    //[SerializeField] private float acceleration = 0.3f;
    //[SerializeField] private float maxSpeed = 6f;

    private Rigidbody2D rb;
    private RigidbodyType2D oldBodyType;
    private SpriteRenderer spriteRenderer;

    private float currentSpeed;

    private bool isDragging;
    public bool IsDropped { get; private set; }
    private bool usePhysics = false;

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
        {
            rb.linearVelocity = Vector2.zero;
            return;
        }

        if (usePhysics)
            return;

        rb.linearVelocity = Vector2.down * GameEngineManager.Instance.CurrentFallSpeed;
    }

    public void Initialize(ItemInfo info)
    {
        ItemType = info.type;

        int randomSprite = Random.Range(0, info.sprites.Length);

        spriteRenderer.sprite = info.sprites[randomSprite];
    }


    //Dragging 
    public void StartDrag()
    {
        isDragging = true;

        rb.linearVelocity = Vector2.zero;
        rb.angularVelocity = 0f;
        rb.gravityScale = 1f;
    }

    public void EndDrag()
    {
        isDragging = false;

        rb.linearVelocity = Vector2.zero;
        rb.angularVelocity = 0f;
    }

    //Resetting dragged/clicked item's speed
    public void EnablePhysics()
    {
        if (usePhysics)
            return;

        usePhysics = true;

        rb.linearVelocity = Vector2.zero;
        rb.angularVelocity = 0f;
        rb.gravityScale = 1f;
    }

    /* TEST */
    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    Debug.Log("Item çarptı: " + other.name);
    //}
}