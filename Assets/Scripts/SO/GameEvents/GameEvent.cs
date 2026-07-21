using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
[CreateAssetMenu(menuName = "Game Event")]
public class GameEvent : ScriptableObject
{
    private List<GameEventListener> listeners = new List<GameEventListener>();
    public void TriggerEvent()
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnEventTriggered();
        }
    }

    public void TriggerEvent(GameObject gameObjectToSend)
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnEventTriggered(gameObjectToSend);
            listeners[i].OnEventTriggered();
        }
    }

    public void TriggerEvent(int value)
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
        {
            listeners[i].OnEventTriggered(value);
            listeners[i].OnEventTriggered();
        }
    }
    public void AddListener(GameEventListener listener)
    {
        listeners.Add(listener);
    }
    public void RemoveListener(GameEventListener listener)
    {
        listeners.Remove(listener);
    }

    [ContextMenu("Invoke Me")]
    private void MyButtonFunction()
    {
        // Add your button functionality here
        TriggerEvent();
    }
}

#if UNITY_EDITOR
[CustomEditor(typeof(GameEvent))]
public class GameEventEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        GameEvent gameEvent = (GameEvent) target;

        if (GUILayout.Button("Trigger Event"))
        {
            gameEvent.TriggerEvent();
            EditorUtility.SetDirty(gameEvent);
        }

        if (GUILayout.Button("Trigger Event (With Parameter null)"))
        {
            gameEvent.TriggerEvent(null);
            EditorUtility.SetDirty(gameEvent);
        }


        if (GUILayout.Button("Trigger Event (With Zero '0')"))
        {
            gameEvent.TriggerEvent(0);
            EditorUtility.SetDirty(gameEvent);
        }
    }
}
#endif

//[CreateAssetMenu(menuName = "Game Event with GameObject target")]
//public class GameEventWithGameObject : ScriptableObject
//{
//    private List<GameEventListener> listeners = new List<GameEventListener>();

//    public void TriggerEvent(GameObject value)
//    {
//        for (int i = listeners.Count - 1; i >= 0; i--)
//        {
//            listeners[i].OnEventTriggered(value);
//        }
//    }
//    public void AddListener(GameEventListener gameEvent)
//    {
//        listeners.Add(gameEvent);
//    }
//    public void RemoveListener(GameEventListener gameEvent)
//    {
//        listeners.Remove(gameEvent);
//    }
//}