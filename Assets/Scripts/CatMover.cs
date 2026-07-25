using Spine;
using Spine.Unity;
using UnityEngine;
using System.Collections;
using Unity.VisualScripting;
using DG.Tweening;
using UnityEngine.InputSystem;

public class CatMover : MonoBehaviour
{
    public float speed;
    public Vector2 direction;

    public bool IsWalking;

    private Collider2D catColllider;
    private Camera mainCam;

    public SkeletonRenderer skeletonRenderer;
    public SkeletonAnimation skeletonRendererAnim;

    public AnimationReferenceAsset Walk;
    public AnimationReferenceAsset Sit;
    public AnimationReferenceAsset Sitting;
    public AnimationReferenceAsset GetUp;
    public AnimationReferenceAsset Idle;

    public Vector2 catPos;
    public bool isSitting=false;
    private bool isLooping = true;
    private bool directionFlip = false;

    private int hitCount;

    public void StartWalking()
    {
        IsWalking = true;
        skeletonRendererAnim.AnimationState.SetAnimation(0, Walk, true);
        catPos = transform.localPosition;
        mainCam = GetComponent<Camera>();
        catColllider = GetComponent<Collider2D>();
        StartCoroutine(CheckIfSitting());
        StartCoroutine(WalkingStarted());
    }

    // Walking coroutine
    IEnumerator WalkingStarted()
    {
        while (isSitting==false)
        {
            //Walking based on the cat's direction.
            Vector2 newPosition = transform.position;
            if (skeletonRenderer.initialFlipX == false)
                newPosition.x += direction.x * speed * Time.deltaTime;

            if (skeletonRenderer.initialFlipX == true)
                newPosition.x -= direction.x * speed * Time.deltaTime;

            transform.position = newPosition;
            catPos = newPosition;

            //If the cat is not on the screen, stops the animation and the cat, flips the cat to get it ready for the next event
            if (catPos.x >= 21 && directionFlip==false) 
            {
                IsWalking = false;

                skeletonRendererAnim.AnimationState.SetAnimation(0, Walk, false);

                if (skeletonRenderer.initialFlipX == false)
                    { skeletonRenderer.initialFlipX = true; }
                else if (skeletonRenderer.initialFlipX == true)
                    { skeletonRenderer.initialFlipX = false; }

                transform.eulerAngles = new Vector3 (0, -180, 0);
                directionFlip = true;
                isLooping = true;
                yield break;
            }
            else if (catPos.x <=-17 && directionFlip==true)
            {
                IsWalking = false;

                skeletonRendererAnim.AnimationState.SetAnimation(0, Walk, false);

                if (skeletonRenderer.initialFlipX == false)
                { skeletonRenderer.initialFlipX = true; }
                else if (skeletonRenderer.initialFlipX == true)
                { skeletonRenderer.initialFlipX = false; }

                transform.eulerAngles = new Vector3 (0, -0, 0);
                directionFlip = false;
                isLooping = true;
                yield break;
            }
            yield return null;
        }
        
    }

    // Checks if chat should sit
    IEnumerator CheckIfSitting()
    {
        while (isLooping)
        {
            if (catPos.x >= 0.0 && catPos.x <= 0.9)
            {
                if (isSitting==false)
                {
                    
                    StartCoroutine(SitForABit());
                    isLooping = false;
                    yield break;
                }               
            }
            yield return null;
        }
    }

    // Will change the coroutine to do something and stop the cat's sitting animation
    // For now it's just waiting
    IEnumerator SitForABit()
    {
        isSitting = true;
        skeletonRendererAnim.AnimationState.SetAnimation(0, Walk, false);
        skeletonRendererAnim.AnimationState.SetAnimation(0, Sit, true);
        skeletonRendererAnim.AnimationState.SetAnimation(0, Sit, false);
        skeletonRendererAnim.AnimationState.SetAnimation(0, Sitting, true);

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector2 mousePos = mainCam.ScreenToWorldPoint(Mouse.current.position.ReadValue());

            if (catColllider.OverlapPoint(mousePos))
            {
                hitCount++;
                Debug.Log($"hitted {hitCount}");

                if (hitCount>=10)
                {
                    Debug.Log($"hitted {hitCount} times!!!");
                    skeletonRendererAnim.AnimationState.SetAnimation(0, Sitting, false);
                    skeletonRendererAnim.AnimationState.SetAnimation(0, Walk, true);
                    isSitting = false;
                    StartCoroutine(WalkingStarted());
                    yield break;
                }
            }
        }
        yield return null;
    }

    public void StartSitDown()
    {
        
    }

    private void SitDown(TrackEntry trackEntry)
    {        
    }

    public void SitDown()
    {
        
    }
}
