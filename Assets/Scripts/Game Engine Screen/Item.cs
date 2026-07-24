using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class Item : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float startSpeed = 1f;

    public float scaleReducer = 0.25f;

    /* OLD SPEED SYSTEM */
    //[SerializeField] private float acceleration = 0.3f;
    //[SerializeField] private float maxSpeed = 6f;

    private Rigidbody2D rb;
    private RigidbodyType2D oldBodyType;
    private SpriteRenderer spriteRenderer;

    private float currentSpeed;

    private bool isDragging;
    public bool IsDropped { get; private set; }
    [SerializeField]
    private bool usePhysics = false;

    public ItemType ItemType { get; private set; }
    public int value = 10;
    public float force = 100f;

    public int valueCorruption = -20;
    public bool corruption = false;

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
        gameObject.AddComponent<PolygonCollider2D>();
    }


    //Dragging 
    public void StartDrag()
    {
        usePhysics = false;
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
        transform.localScale = Vector2.one * scaleReducer;
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


    public void FireTowardsRight()
    {
        rb.excludeLayers = ~0;
        rb.gravityScale = -1f;
        rb.linearVelocity = Vector2.zero;
        rb.AddForce(new Vector2(1, 10) * force, ForceMode2D.Impulse);
        rb.AddForce(Vector2.up * 10f);
        rb.AddRelativeForce(Vector2.up * 10f);
        //rb.AddForce(transform.forward * 200, ForceMode.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (corruption == true) return;

        if (other.gameObject.layer == LayerMask.NameToLayer("TeamMembers"))
        {
            corruption = true;
            value += valueCorruption;
            spriteRenderer.color = Color.red;
        }

    }
}