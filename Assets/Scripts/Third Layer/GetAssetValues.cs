using TMPro;
using UnityEngine;
public class GetAssetValues : MonoBehaviour
{
    public ItemType itemType;
    public TextMeshProUGUI textMeshPro;



    private void Update()
    {
        if (GameManager.instance == null) return;

        var value = GameManager.instance.GetThirdLayerValue(itemType);
        textMeshPro.text = value.ToString();
    }

}
