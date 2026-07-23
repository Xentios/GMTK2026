using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ZoomOutALayer : MonoBehaviour
{
    public Camera renderTextureCam;
    public RenderTexture renderTexture;
    public Volume postProcessEffects;

    public float duration = 1f;

    public RawImage tempImage;


    public void OnZoomOut()
    {
        // renderTextureCam.Render();       
        StartCoroutine(RenderOneFrame(renderTextureCam));
        tempImage.texture = GetSS();
        DOTween.To(() => postProcessEffects.weight, x => postProcessEffects.weight = x, 1f, duration).OnComplete(ChangeLevel);

    }
    private void ChangeLevel()
    {
        SceneManager.LoadSceneAsync(1);
        DOTween.To(() => postProcessEffects.weight, x => postProcessEffects.weight = x, 0f, 0.3f);
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
