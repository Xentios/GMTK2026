using Spine.Unity;
using UnityEngine;
using UnityEngine.InputSystem;

public class CatPetSystem : MonoBehaviour
{
    public InputActionReference mouseClick;
    public InputActionReference pointerPos;

    public Collider2D catCollider;

    private SkeletonRenderer catSkeletonRenderer;
    private SkeletonAnimation catSkeletonAnim;

    public AnimationReferenceAsset catPetting;
    public AnimationReferenceAsset catIdle;
    public AnimationReferenceAsset catAfterPetting;
    private void Awake()
    {
        catSkeletonRenderer = catCollider.transform.parent.GetComponent<SkeletonRenderer>();
        catSkeletonAnim = catSkeletonRenderer.GetComponent<SkeletonAnimation>();
    }

    private void OnEnable()
    {
        mouseClick.action.performed += pettingStarted;
        mouseClick.action.canceled += pettingEndded;
        pointerPos.action.performed += pettingOrNotPetting;
    }

    private bool isPetting;

    private void OnDisable()
    {

        mouseClick.action.performed -= pettingStarted;
        mouseClick.action.canceled -= pettingEndded;
        pointerPos.action.performed -= pettingOrNotPetting;
    }
    private void pettingEndded(InputAction.CallbackContext context)
    {
        if (isPetting == false) return;

        isPetting = false;
        catSkeletonAnim.AnimationState.SetAnimation(0, catAfterPetting, false);
        catSkeletonAnim.AnimationState.AddAnimation(0, catIdle, true, catAfterPetting.Animation.Duration);
    }

    private void pettingStarted(InputAction.CallbackContext obj)
    {
        if (isPetting == true) return;
        var mousePos = pointerPos.action.ReadValue<Vector2>();
        var worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        if (catCollider.bounds.Contains(worldPos) == false) return;

        isPetting = true;
        catSkeletonAnim.AnimationState.SetAnimation(0, catPetting, loop: true);
    }

    private void pettingOrNotPetting(InputAction.CallbackContext context)
    {
        if (isPetting == false) return;
        //DO stuff with cursor and maybe check if we move away from the cat?

    }


}
