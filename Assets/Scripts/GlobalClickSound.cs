using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class GlobalClickSound : MonoBehaviour
{
    private void Update()
    {
        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            Collider2D hit = Physics2D.OverlapPoint(mousePos);

            if (hit != null && hit.CompareTag("Cat"))
            {
                
                AudioManager.instance.PlaySFX("CatClick");
            }
            else if (hit != null && hit.CompareTag("CatEvent"))
            {
                AudioManager.instance.PlaySFX("CatEventClick");
            }
            else
            { AudioManager.instance.PlaySFX("OnClick"); }

        }
    }
}
