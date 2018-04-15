using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace Variables._Definitions
{
    [CreateAssetMenu]
    public class Vector3Variable : Variable<Vector3>
    {

    }

#if UNITY_EDITOR
    [CustomEditor(typeof(Vector3Variable))]
    public class Vector3VariableEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            Vector3Variable myScript = (Vector3Variable)target;
            if (GUILayout.Button("Invoke"))
            {
                myScript.ValueChangedEvent.Invoke();
            }
        }
    }
#endif
}