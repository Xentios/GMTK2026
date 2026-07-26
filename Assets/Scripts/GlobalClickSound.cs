using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
public class GlobalClickSound : MonoBehaviour
{
    private Sequence jumpSequence;
    private void Update()
    {
        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            Collider2D hit = Physics2D.OverlapPoint(mousePos);

            if (hit != null && hit.CompareTag("Cat"))
            {

                //  AudioManager.instance.PlaySFX("CatClick");
            }
            else if (hit != null && hit.CompareTag("CatEvent"))
            {
                AudioManager.instance.PlaySFX("CatEventClick");
            }
            else if (hit != null && hit.CompareTag("Syrup"))
            {
                AudioManager.instance.PlaySFX("SyrupClick");
                StartCoroutine(CuteJump(hit.transform));
            }
            else if (hit != null && hit.CompareTag("Keyboard"))
            {
                AudioManager.instance.PlaySFX("KeyboardClick");
            }
            else if (hit != null && hit.CompareTag("Tab"))
            {
                AudioManager.instance.PlaySFX("TabClick");
            }
            else if (hit != null && hit.CompareTag("Modem"))
            {
                AudioManager.instance.PlayModemSounds();
            }
            else
            { AudioManager.instance.PlaySFX("OnClick"); }

        }



    }

    IEnumerator CuteJump(Transform target)
    {
        yield return null;
        if (jumpSequence == null)
        {
            jumpSequence = target.DOJump(target.position, 0.4f, 2, 0.3f).SetLoops(2, LoopType.Yoyo);
        }
        else if (jumpSequence.active == false)
        {
            jumpSequence = target.DOJump(target.position, 0.4f, 2, 0.3f).SetLoops(2, LoopType.Yoyo);
        }


    }
}
