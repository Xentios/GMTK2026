using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ZoomOutALayer : MonoBehaviour
{

    [SerializeField]
    private InputActionReference goBackButton;

    public string Layer1SceneName;

    public Camera renderTextureCam;
    public RenderTexture renderTexture;
    public Volume postProcessEffects;

    public float duration = 1f;

    public RawImage tempImage;

    private bool MaxLevel = false;


    public AudioSource AudioSource;
    public AudioClip errorSound;

    private void OnEnable()
    {
        goBackButton.action.performed += Action_performed;
    }
    private void OnDisable()
    {
        goBackButton.action.performed -= Action_performed;
    }

    private void Action_performed(InputAction.CallbackContext obj)
    {
        OnZoomOut();
    }

    public void OnZoomOut()
    {
        // renderTextureCam.Render();       
        StartCoroutine(RenderOneFrame(renderTextureCam));
        tempImage.texture = GetSS();
        MaxLevel = SceneManager.GetActiveScene().name == Layer1SceneName;
        var offset = MaxLevel ? duration - 0.3f : 0f;

        DOTween.To(() => postProcessEffects.weight, x => postProcessEffects.weight = x, 1f, duration - offset).OnComplete(ChangeLevel);

    }

    private void PlayAudio()
    {
        AudioSource.PlayOneShot(errorSound);
    }

    private void ChangeLevel()
    {
        if (MaxLevel == true)
        {
            PlayAudio();
        }

        DOTween.To(() => postProcessEffects.weight, x => postProcessEffects.weight = x, 0f, 0.3f);

        if (MaxLevel == true) return;
        SceneManager.LoadSceneAsync(1);
    }


    private Texture2D GetSS()
    {
        RenderTexture.active = renderTexture;
        Texture2D texture = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.RGBA32, false);
        texture.ReadPixels(new Rect(0, 0, renderTexture.width, renderTexture.height), 0, 0);
        texture.Apply();
        RenderTexture.active = null;

        return texture;
    }

    IEnumerator RenderOneFrame(Camera camera)
    {
        camera.enabled = true;
        yield return new WaitForEndOfFrame();
        camera.enabled = false;
    }
}
