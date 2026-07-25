using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFinish : MonoBehaviour
{

    public string GameLostSceneName;


    public void TriggerGameLost()
    {
        SceneManager.LoadSceneAsync(GameLostSceneName);
        Destroy(transform.root);
    }


}
