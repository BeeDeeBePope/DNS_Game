using System.Collections.Generic;
using System.Linq;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Variables._Definitions
{
    [CreateAssetMenu]
    public class GameEvent : ScriptableObject
    {
        private readonly HashSet<GameEventListener> _listeners = new HashSet<GameEventListener>();

        public void Raise()
        {
            for (int i = _listeners.Count - 1; i >= 0; i--)
                _listeners.ToList()[i].OnEventRaised();
        }

        public void RegisterListener(GameEventListener listener)
        {
            _listeners.Add(listener);
        }

        public void UnregisterListener(GameEventListener listener)
        {
            _listeners.Remove(listener);
        }
    }

#if UNITY_EDITOR
    [CustomEditor(typeof(GameEvent))]
    public class GameEventEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            GameEvent myScript = (GameEvent)target;
            if (GUILayout.Button("Raise"))
            {
                myScript.Raise();
            }
        }
    }
#endif
}