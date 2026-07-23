using DG.Tweening;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ZoomOutALayer : MonoBehaviour
{
    public RenderTexture renderTexture;
    public Volume postProcessEffects;

    public float duration = 1f;

    public RawImage tempImage;


    public void OnZoomOut()
    {
        tempImage.texture = GetSS();
        DOTween.To(() => postProcessEffects.weight, x => postProcessEffects.weight = x, 1f, duration / 2f);//.OnComplete(ChangeLevel);
        ChangeLevel();
    }
    private void ChangeLevel()
    {
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
}
