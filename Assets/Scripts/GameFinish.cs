using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFinish : MonoBehaviour
{
    public GameObject rootBootstrap;
    public string GameLostSceneName;
    public string GameWonSceneName;

    private bool triggered;

    public void TriggerGameLost()
    {
        if (triggered == true) return;
        triggered = true;
        SceneManager.LoadSceneAsync(GameLostSceneName);
        Destroy(rootBootstrap);
    }

    public void TriggerGameWin()
    {
        if (triggered == true) return;
        triggered = true;
        SceneManager.LoadSceneAsync(GameWonSceneName);
        Destroy(rootBootstrap);
    }


}
