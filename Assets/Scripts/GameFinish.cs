using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFinish : MonoBehaviour
{
    public GameObject rootBootstrap;
    public string GameLostSceneName;


    public void TriggerGameLost()
    {
        SceneManager.LoadSceneAsync(GameLostSceneName);
        Destroy(rootBootstrap);
    }


}
