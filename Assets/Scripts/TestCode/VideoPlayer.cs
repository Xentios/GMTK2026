using UnityEngine;

public class VideoPlayer : MonoBehaviour
{
    UnityEngine.Video.VideoPlayer videoPlayer;
    public GameObject Canvas;


    private void Awake()
    {
        videoPlayer = GetComponent<UnityEngine.Video.VideoPlayer>();
        videoPlayer.loopPointReached += EndReached;
    }
    private void Start()
    {
        videoPlayer.url = System.IO.Path.Combine(Application.streamingAssetsPath, "countdown.mp4");
        videoPlayer.Play();
    }
    private void EndReached(UnityEngine.Video.VideoPlayer source)
    {
        Canvas.SetActive(true);
    }
}
