using TMPro;
using UnityEngine;

public class FakeLoadingAnimation : MonoBehaviour
{
    public TMP_Text text;
    public float speed = 5f;
    public float amplitude = 5f;

    TMP_TextInfo info;

    void Update()
    {
        text.ForceMeshUpdate();
        info = text.textInfo;

        int len = text.text.Length;
        int start = Mathf.Max(0, len - 3);

        for (int i = 0; i < info.characterCount; i++)
        {
            var c = info.characterInfo[i];
            if (!c.isVisible) continue;

            int charIndex = c.index;

            Vector3 offset = Vector3.zero;

            if (charIndex >= start)
            {
                float y = Mathf.Sin(Time.time * speed + charIndex) * amplitude;
                offset = new Vector3(0, y, 0);
            }

            var verts = info.meshInfo[c.materialReferenceIndex].vertices;

            for (int j = 0; j < 4; j++)
                verts[c.vertexIndex + j] += offset;
        }

        for (int i = 0; i < info.meshInfo.Length; i++)
        {
            var meshInfo = info.meshInfo[i];
            meshInfo.mesh.vertices = meshInfo.vertices;
            text.UpdateGeometry(meshInfo.mesh, i);
        }
    }
}