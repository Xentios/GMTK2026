using Spine;
using Spine.Unity;
using UnityEngine;

public class CatMover : MonoBehaviour
{
    public float speed;
    public Vector2 direction;

    public bool IsWalking;

    public SkeletonRenderer skeletonRenderer;
    public SkeletonAnimation skeletonRendererAnim;

    public AnimationReferenceAsset Walk;
    public AnimationReferenceAsset Sit;
    public AnimationReferenceAsset Sitting;
    public AnimationReferenceAsset GetUp;
    public AnimationReferenceAsset Idle;
    void Update()
    {
        if (IsWalking == false) return;
        // skeletonRendererAnim.
        //skeletonRenderer.Animation=
        //skeletonRendererAnim.AnimationState.SetAnimation(0, Walk, true);
        Vector2 newPosition = transform.position;
        newPosition.x += direction.x * speed * Time.deltaTime;
        transform.position = newPosition;
    }

    public void StartWalking()
    {
        skeletonRendererAnim.AnimationState.SetAnimation(0, Walk, true);
    }

    public void StartSitDown()
    {
        var end = skeletonRendererAnim.AnimationState.SetAnimation(0, Sit, false).AnimationEnd;
        skeletonRendererAnim.AnimationState.AddAnimation(0, Sitting, true, Sitting.Animation.Duration);
    }

    private void SitDown(TrackEntry trackEntry)
    {
        skeletonRendererAnim.AnimationState.SetAnimation(0, Sit, true);
    }

    public void SitDown()
    {

    }
}
