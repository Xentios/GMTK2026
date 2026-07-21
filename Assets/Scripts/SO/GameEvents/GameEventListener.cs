using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class GameEventListener : MonoBehaviour
{
    [SerializeField]
    public GameEvent gameEvent;
    [SerializeField]
    public UnityEvent onEventTriggered;
    [SerializeField]
    public UnityEvent<GameObject> onEventTriggeredWithParameter;
    [SerializeField]
    public UnityEvent<int> onEventTriggeredWithParameterInt;
    void OnEnable()
    {
        gameEvent.AddListener(this);
    }
    void OnDisable()
    {
        gameEvent.RemoveListener(this);
    }
    public void OnEventTriggered()
    {
        onEventTriggered.Invoke();
    }

    public void OnEventTriggered(GameObject go)
    {
        onEventTriggeredWithParameter.Invoke(go);
    }

    public void OnEventTriggered(int value)
    {
        onEventTriggeredWithParameterInt.Invoke(value);
    }
}


#if UNITY_EDITOR

[CustomEditor(typeof(GameEventListener))]
public class GameEventListenerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        GameEventListener listener = (GameEventListener) target;

        if (GUILayout.Button("Trigger Event"))
        {
            listener.OnEventTriggered();
            EditorUtility.SetDirty(listener);
        }

        if (GUILayout.Button("Trigger Event (With Parameter)"))
        {
            listener.OnEventTriggered(null);
            EditorUtility.SetDirty(listener);
        }


        if (GUILayout.Button("Trigger Event (With Parameter)"))
        {
            listener.OnEventTriggered(0);
            EditorUtility.SetDirty(listener);
        }
    }
}
#endif