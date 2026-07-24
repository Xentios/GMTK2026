using UnityEngine;
using UnityEngine.UI;

public class DisableRenderImageAlpha : MonoBehaviour
{
    public RawImage rawImage;

    private void Awake()
    {
        if (rawImage == null) rawImage = GetComponent<RawImage>();
    }

    private void OnEnable()
    {
        FixAlphaValue();
    }

    private void Start()
    {
        FixAlphaValue();
    }

    private void FixAlphaValue()
    {
        if (GameManager.instance == null) return;

        var flag = GameManager.instance.DidWeVisitLayer2;

        if (flag == true)
        {
            rawImage.color = Color.white;
        }
    }
}
