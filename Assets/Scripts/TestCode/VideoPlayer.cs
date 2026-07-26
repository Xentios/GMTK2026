using UnityEngine;

public class VideoPlayer : MonoBehaviour
{
    UnityEngine.Video.VideoPlayer videoPlayer;
    public GameObject Canvas;
    public AudioSource audioSource;

    public string fileName = "countdown.mp4";

    private void Awake()
    {
        videoPlayer = GetComponent<UnityEngine.Video.VideoPlayer>();
        videoPlayer.loopPointReached += EndReached;
    }
    private void Start()
    {
        videoPlayer.url = System.IO.Path.Combine(Application.streamingAssetsPath, fileName);
        videoPlayer.Prepare();
        videoPlayer.prepareCompleted += OnPrepareCompleted;



    }

    private void OnPrepareCompleted(UnityEngine.Video.VideoPlayer source)
    {
        source.Play();
        if (audioSource != null) audioSource.Play();
    }

    private void EndReached(UnityEngine.Video.VideoPlayer source)
    {
        Canvas.SetActive(true);
    }
}
