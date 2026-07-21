using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    [SerializeField]
    private Button startGame;

    private List<Button> buttons;

    private void Start()
    {
        buttons = new List<Button>();
        for (int i = 0; i < transform.childCount; i++)
        {
            var button = transform.GetChild(i).transform.GetComponentInChildren<Button>();
            buttons.Add(button);
        }

        startGame.onClick.AddListener(StartGame);
    }
    private void OnDestroy()
    {
        startGame.onClick.RemoveAllListeners();
    }

    private void StartGame()
    {
        // SceneManager.UnloadSceneAsync(1);
        Invoke(nameof(LoadAsync), 2.3f);
    }


    private void LoadAsync()
    {
        SceneManager.LoadSceneAsync(sceneBuildIndex: 2, LoadSceneMode.Single);
    }
}
