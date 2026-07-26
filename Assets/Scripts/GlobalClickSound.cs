using UnityEngine;
using UnityEngine.InputSystem;

public class GlobalClickSound : MonoBehaviour
{
    private void Update()
    {
        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            Debug.Log("Tıklandı");
            AudioManager.instance.PlaySFX("OnClick");
        }
    }
}
