using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Variables._Definitions
{
    [CreateAssetMenu]
    public class StringVariable : Variable<string>
    {
    }

#if UNITY_EDITOR
    [CustomEditor(typeof(StringVariable))]
    public class StringVariableEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            StringVariable myScript = (StringVariable)target;
            if (GUILayout.Button("Invoke"))
            {
                myScript.ValueChangedEvent.Invoke();
            }
        }
    }
#endif
}