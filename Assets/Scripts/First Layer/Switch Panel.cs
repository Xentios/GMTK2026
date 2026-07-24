using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPanel : MonoBehaviour
{
    public List<GameObject> Panels;

    public Camera RenderCamera;



    public void TogglePanels()
    {

        StartCoroutine(RenderOneFrame(RenderCamera));


    }

    private void AfterRender()
    {
        int index = 0;
        for (int i = 0; i < Panels.Count; i++)
        {
            index = i;
            if (Panels[i].activeSelf == true) break;
        }
        Panels.ForEach(panel => panel.SetActive(false));

        index++;
        index %= Panels.Count;
        Panels[index].SetActive(true);
    }

    IEnumerator RenderOneFrame(Camera camera)
    {
        camera.enabled = true;
        yield return new WaitForEndOfFrame();
        camera.enabled = false;
        AfterRender();
    }

}
