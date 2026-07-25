using UnityEngine;
using UnityEngine.UI;

public class AutoScrollController : MonoBehaviour
{
    [SerializeField] private ScrollRect scrollRect;
    [SerializeField] private float scrollSpeed = 0.1f;

    private bool goingDown = true;
    private bool isPaused = false;

    private void Update()
    {
        if (isPaused)
            return;

        //Going down then going up
        if (goingDown)
        {
            scrollRect.verticalNormalizedPosition -= scrollSpeed * Time.deltaTime;

            if (scrollRect.verticalNormalizedPosition <= 0f)
            {
                scrollRect.verticalNormalizedPosition = 0f;
                goingDown = false;
            }
        }
        else
        {
            scrollRect.verticalNormalizedPosition += scrollSpeed * Time.deltaTime;

            if (scrollRect.verticalNormalizedPosition >= 1f)
            {
                scrollRect.verticalNormalizedPosition = 1f;
                goingDown = true;
            }
        }
    }


    //For Event trigger 
    public void PauseScroll()
    {
        isPaused = true;
    }

    public void ResumeScroll()
    {
        isPaused = false;
    }
}