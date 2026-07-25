using DG.Tweening;
using Spine.Unity;
using UnityEngine;
using UnityEngine.InputSystem;

public class OnTeamMemberClick : MonoBehaviour
{
    public InputActionReference mouseClick;
    public InputActionReference mousePosition;
    public float defaultScaleModifier = 1.1f;

    private BoxCollider2D BoxCollider2D;
    private Rigidbody2D rb;
    private AudioSource audioSource;
    private ISkeletonAnimation skeletonAnimation;

    private Vector3 defaultScale;

    private void Awake()
    {
        BoxCollider2D = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        skeletonAnimation = GetComponent<ISkeletonAnimation>();

        defaultScale = transform.localScale;
    }

    void OnEnable()
    {
        mouseClick.action.performed += ClickMouse;
        mousePosition.action.performed += checkMousePos;
    }

    void OnDisable()
    {
        mouseClick.action.performed -= ClickMouse;
        mousePosition.action.performed -= checkMousePos;
    }

    private void ClickMouse(InputAction.CallbackContext context)
    {


        var mousePos = Mouse.current.position.ReadValue();
        var worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        worldPos.z = 0;
        if (BoxCollider2D.bounds.Contains(worldPos) == false) return;
        rb.gravityScale = 1f;
        rb.AddForceY(10f);
        audioSource.Stop();
        skeletonAnimation.ClearAnimationState();
        transform.DOScale(defaultScale * 0.8f, 0.5f);
        this.enabled = false;
    }

    private void checkMousePos(InputAction.CallbackContext context)
    {
        var mousePos = context.ReadValue<Vector2>();
        var worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        worldPos.z = 0;
        if (BoxCollider2D.bounds.Contains(worldPos) == true)
        {
            transform.localScale = defaultScale * defaultScaleModifier;
        }
        else
        {
            transform.localScale = defaultScale;
        }

    }
}
