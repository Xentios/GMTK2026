using Spine.Unity;
using UnityEngine;
using UnityEngine.InputSystem;

public class CatPetSystem : MonoBehaviour
{
    public InputActionReference mouseClick;
    public InputActionReference pointerPos;

    public Collider2D catCollider;

    public SkeletonRenderer catSkeletonRenderer;
    public SkeletonAnimation catSkeletonAnim;

    public AnimationReferenceAsset catPetting;
    public AnimationReferenceAsset catIdle;
    public AnimationReferenceAsset catAfterPetting;

    public GameObject hand;

    private void OnEnable()
    {
        mouseClick.action.performed += pettingStarted;
        mouseClick.action.canceled += pettingEndded;
        pointerPos.action.performed += pettingOrNotPetting;
    }

    private bool isPetting;
    public float handSlipOffset = 10f;

    private void OnDisable()
    {

        mouseClick.action.performed -= pettingStarted;
        mouseClick.action.canceled -= pettingEndded;
        pointerPos.action.performed -= pettingOrNotPetting;
    }
    private void pettingEndded(InputAction.CallbackContext context)
    {

        if (isPetting == false) return;

        Cursor.visible = true;
        hand.transform.position = Vector3.back * 30;//Some random location or just make it inactive?
        isPetting = false;
        catSkeletonAnim.AnimationState.SetAnimation(0, catAfterPetting, false);
        catSkeletonAnim.AnimationState.AddAnimation(0, catIdle, true, catAfterPetting.Animation.Duration);
    }

    private void pettingStarted(InputAction.CallbackContext obj)
    {
        if (isPetting == true) return;
        var mousePos = pointerPos.action.ReadValue<Vector2>();
        var worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        worldPos.z = 0;
        if (catCollider.bounds.Contains(worldPos) == false) return;

        isPetting = true;
        catSkeletonAnim.AnimationState.SetAnimation(0, catPetting, loop: true);
        hand.transform.position = worldPos;
    }

    private void pettingOrNotPetting(InputAction.CallbackContext context)
    {
        if (isPetting == false) return;

        Cursor.visible = false;
        var mousePos = context.ReadValue<Vector2>();
        var worldPos = Camera.main.ScreenToWorldPoint(mousePos);
        worldPos.z = 0;
        if (catCollider.bounds.Contains(worldPos) == true || Vector2.Distance(worldPos, hand.transform.position) < handSlipOffset)
        {
            hand.transform.position = worldPos;
            Vector3 dir = catCollider.transform.position - worldPos;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;

            hand.transform.rotation = Quaternion.Euler(hand.transform.rotation.x, hand.transform.rotation.y, angle);
        }
        else
        {
            if (Vector2.Distance(worldPos, hand.transform.position) > handSlipOffset + 3f)
            {
                pettingEndded(context);//Sacrilege
            }
        }


        //DO stuff with cursor and maybe check if we move away from the cat?

    }


}
