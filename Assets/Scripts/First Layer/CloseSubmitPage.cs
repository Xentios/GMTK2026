using UnityEngine;

public class CloseSubmitPage : MonoBehaviour
{
    public GameObject submissionPopUpPanel;
    void OnDisable()
    {
        submissionPopUpPanel.SetActive(false);
    }
}
