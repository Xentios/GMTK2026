using DG.Tweening;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class ZoomInALayer : MonoBehaviour
{

    public Camera cam;

    public Transform zoomTarget;
    public Volume postProcessEffects;

    public float duration = 2f;
    public float zoomLevel = 1f;

    private float originalorthographicSize;

    private void Start()
    {
        originalorthographicSize = cam.orthographicSize;
    }



    public void ZoomIn()
    {
        if (GameManager.instance.AnimationOnProgress == true) return;

        GameManager.instance.AnimationOnProgress = true;
        var oSize = originalorthographicSize;
        DOTween.To(() => cam.orthographicSize, x => cam.orthographicSize = x, zoomLevel, duration).OnComplete(ChangeLevel);

        postProcessEffects.weight = 0f;
        DOTween.To(() => postProcessEffects.weight, x => postProcessEffects.weight = x, 1f, duration / 2f);//.OnComplete(ChangeLevel);
        var finalRotation = Quaternion.LookRotation(zoomTarget.position - cam.transform.position);
        cam.transform.DORotateQuaternion(finalRotation, duration);
    }

    private void ChangeLevel()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        DOTween.To(() => postProcessEffects.weight, x => postProcessEffects.weight = x, 0f, 0.3f).OnComplete(() => GameManager.instance.AnimationOnProgress = false);
    }
}
