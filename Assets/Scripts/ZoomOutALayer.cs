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

    public Camera renderTextureCamForLayer1;
    public Camera renderTextureCamForLayer2;

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
        if (GameManager.instance.AnimationOnProgress == true) return;

        GameManager.instance.AnimationOnProgress = true;
        if (SceneManager.GetActiveScene().buildIndex == 2)
            StartCoroutine(RenderOneFrame(renderTextureCamForLayer1));
        if (SceneManager.GetActiveScene().buildIndex == 3)
            StartCoroutine(RenderOneFrame(renderTextureCamForLayer2));

        //MaxLevel = SceneManager.GetActiveScene().name == Layer1SceneName;
        MaxLevel = SceneManager.GetActiveScene().buildIndex == 1;
        var offset = MaxLevel ? duration - 0.3f : 0f;

        postProcessEffects.weight = 0f;
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

        DOTween.To(() => postProcessEffects.weight, x => postProcessEffects.weight = x, 0f, 0.3f).OnComplete(CreatorOfBugs);
        if (MaxLevel == true) return;
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex - 1);

    }

    private void CreatorOfBugs()
    {
        GameManager.instance.AnimationOnProgress = false;

    }


    private Texture2D GetSS(RenderTexture renderTexture)
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
