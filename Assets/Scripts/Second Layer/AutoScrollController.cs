using UnityEngine;
using UnityEngine.UI;

public class AutoScrollController : MonoBehaviour
{
    [SerializeField] private ScrollRect scrollRect;
    [SerializeField] private float scrollSpeed = 0.1f;

    private void Update()
    {
        scrollRect.verticalNormalizedPosition -= scrollSpeed * Time.deltaTime;

        //Going back to the top
        if (scrollRect.verticalNormalizedPosition <= 0 )
        {
            scrollRect.verticalNormalizedPosition = 1f;
        }
    }
}
