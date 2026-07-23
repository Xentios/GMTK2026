using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabButtons : MonoBehaviour
{
    public List<Button> buttons;

    public List<GameObject> panels;



    void Awake()
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            int index = i;
            buttons[i].onClick.AddListener(() => OnButtonClicked(index));
        }
    }


    private void OnDestroy()
    {
        for (int i = 0; i < buttons.Count; i++)
        {
            buttons[i].onClick.RemoveAllListeners();
        }
    }


    public void OnButtonClicked(int index)
    {
        foreach (var panel in panels)
        {
            panel.SetActive(false);
        }
        panels[index].SetActive(true);
    }
}
