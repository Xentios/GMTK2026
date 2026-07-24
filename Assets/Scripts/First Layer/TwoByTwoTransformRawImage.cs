using UnityEngine;
using UnityEngine.UI;


public class TwoByTwoTransformRawImage : RawImage
{
    [SerializeField]
    public Vector2 xAxis = new Vector2(1, 0);
    public Vector2 yAxis = new Vector2(0, 1);


    protected override void OnPopulateMesh(VertexHelper vh)
    {
        base.OnPopulateMesh(vh);

        UIVertex vertex = default;

        for (int i = 0; i < vh.currentVertCount; i++)
        {
            vh.PopulateUIVertex(ref vertex, i);

            Vector3 originalPos = vertex.position;

            vertex.position = new Vector3(
                (xAxis.x * originalPos.x) + (yAxis.x * originalPos.y),
                (xAxis.y * originalPos.x) + (yAxis.y * originalPos.y),
                 originalPos.z

            );

            vh.SetUIVertex(vertex, i);
        }
    }
}






