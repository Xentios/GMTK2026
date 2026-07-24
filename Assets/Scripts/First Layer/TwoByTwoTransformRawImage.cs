using System;
using System.Reflection;
using UnityEditor;
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








[CustomEditor(typeof(TwoByTwoTransformRawImage))]
[CanEditMultipleObjects]
public class TwoByTwoTransformRawImageEditor : Editor
{
    Editor rawImageEditor;

    void OnEnable()
    {
        var editorType = Type.GetType("UnityEditor.UI.RawImageEditor, UnityEditor.UI");

        if (editorType == null)
            editorType = Type.GetType("UnityEditor.UI.RawImageEditor, UnityEditor");

        if (editorType != null)
            rawImageEditor = CreateEditor(targets, editorType);
    }

    void OnDisable()
    {
        if (rawImageEditor != null)
            DestroyImmediate(rawImageEditor);
    }

    public override void OnInspectorGUI()
    {
        if (rawImageEditor != null)
        {
            MethodInfo method = rawImageEditor.GetType().GetMethod(
                "OnInspectorGUI",
                BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            method?.Invoke(rawImageEditor, null);
        }
        else
        {
            DrawDefaultInspector();
        }

        EditorGUILayout.Space();
        EditorGUILayout.LabelField("2x2 Transform", EditorStyles.boldLabel);

        var image = (TwoByTwoTransformRawImage) target;

        image.xAxis = EditorGUILayout.Vector2Field("X Axis", image.xAxis);
        image.yAxis = EditorGUILayout.Vector2Field("Y Axis", image.yAxis);
        //image.zAxis = EditorGUILayout.Vector2Field("Z Axis", image.zAxis);

        if (GUI.changed)
        {
            EditorUtility.SetDirty(image);
            image.SetVerticesDirty();
        }
    }
}
