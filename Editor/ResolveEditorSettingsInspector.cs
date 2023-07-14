using UnityEditor;
using UnityEngine;

namespace Quartzified.Resolve.Editor
{
    [CustomEditor(typeof(ResolveEditorSettings))]
    public class ResolveEditorSettingsInspector : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            EditorGUILayout.HelpBox("Go to Edit -> Preferences -> Quartzified/Resolve", MessageType.Info);
            if (GUILayout.Button("Open Settings"))
            {
                SettingsService.OpenUserPreferences("Quartzified/Resolve");
            }

            base.OnInspectorGUI();
        }
    }

}
