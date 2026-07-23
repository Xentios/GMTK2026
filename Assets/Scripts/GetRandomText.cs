using System.Collections.Generic;
using UnityEngine;

public class GetRandomText : MonoBehaviour
{
    public List<string> texts;
    private TMPro.TextMeshProUGUI TextMeshProUGUI;

    private void Awake()
    {
        TextMeshProUGUI = GetComponent<TMPro.TextMeshProUGUI>();
    }
    void OnEnable()
    {
        TextMeshProUGUI.text = texts[Random.Range(0, texts.Count)];
    }





}
