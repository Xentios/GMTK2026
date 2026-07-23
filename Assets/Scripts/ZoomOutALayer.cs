using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class ZoomOutALayer : MonoBehaviour
{
    public RenderTexture renderTexture;

    public RawImage tempImage;


    public void OnZoomOut()
    {
        tempImage.texture = GetSS();
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
