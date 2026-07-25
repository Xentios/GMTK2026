using UnityEngine;
using UnityEngine.SceneManagement;

public class OnEnableLoadNextScene : MonoBehaviour
{
    void OnEnable()
    {
        SceneManager.LoadScene(1);
    }
}
