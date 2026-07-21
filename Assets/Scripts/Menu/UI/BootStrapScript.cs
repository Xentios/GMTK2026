using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

[DefaultExecutionOrder(1000)]
public class BootStrapScript : MonoBehaviour
{
    public static UnityEvent gameOverEvent = new UnityEvent();

    public InputActionReference tabButton;
    public GameObject menuPanel;
    public GameObject gameOverPanel;
    public GameObject startButton;
    public GameObject conButton;

    public List<GameObject> objectsToDisable;

    public Volume globalVolume;

    static BootStrapScript instance;
    private bool gameOver = false;

    public AudioSource playSfx;
    public AudioClip gameOverClip;

    public AudioClip uiButtonSound;
    public AudioClip uiButtonStartSound;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;

        DontDestroyOnLoad(transform.root.gameObject);
    }

    void OnDestroy()
    {
        if (instance == this) instance = null;
    }

    private void OnEnable()
    {
        gameOverEvent.AddListener(OpenGameOverPanel);
        tabButton.asset.Enable();
        tabButton.action.performed += toogleTabPerformed;
        tabButton.action.started += toogleTabStarted;
    }
    private void OnDisable()
    {
        gameOverEvent.RemoveListener(OpenGameOverPanel);
        tabButton.action.started -= toogleTabStarted;
        tabButton.action.performed -= toogleTabPerformed;
        tabButton.asset.Disable();
    }

    private void toogleTabPerformed(InputAction.CallbackContext context)
    {
        // menuPanel.SetActive(!menuPanel.activeInHierarchy);
        Debug.Log("ToogleMenu");
    }
    private void toogleTabStarted(InputAction.CallbackContext context)
    {
        if (gameOver == true) return;
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            DisablePanels();
            return;
        }


        if (menuPanel.activeInHierarchy == true)
        {
            DisablePanels();

        }
        menuPanel.SetActive(!menuPanel.activeInHierarchy);
        globalVolume.enabled = true;
        globalVolume.weight = menuPanel.activeInHierarchy ? 0.5f : 0f;

    }


    void Start()
    {
        ReturnToMainMenu();
    }

    private void DisablePanels()
    {
        foreach (GameObject obj in objectsToDisable)
        {
            obj.SetActive(false);
        }
    }


    public void RestartLevel()
    {
        DisablePanels();
        menuPanel.SetActive(false);
        gameOver = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }
    public void ReturnToMainMenu()
    {
        DisablePanels();
        startButton.SetActive(true);
        conButton.SetActive(false);
        gameOver = false;
        SceneManager.LoadScene(1, LoadSceneMode.Single);
    }

    public void OpenGameOverPanel()
    {
        gameOver = true;
        menuPanel.SetActive(true);
        gameOverPanel.SetActive(true);
        gameOverPanel.transform.parent.gameObject.SetActive(true);
        playSfx.ignoreListenerPause = true;
        AudioListener.pause = true;
        playSfx.PlayOneShot(gameOverClip);
    }

    public void UISound()
    {
        playSfx.PlayOneShot(uiButtonSound);
    }
    public void UISoundStart()
    {
        playSfx.PlayOneShot(uiButtonStartSound);
    }
}
