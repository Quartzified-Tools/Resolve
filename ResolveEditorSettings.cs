#if UNITY_EDITOR
using UnityEditor;
#endif

using UnityEngine;

namespace Quartzified.Resolve.Editor
{
    public class ResolveEditorSettings : ScriptableObject
    {
#if UNITY_EDITOR

        static ResolveEditorSettings _instance;
        public static ResolveEditorSettings instance
        {
            get
            {
                if (_instance != null)
                {
                    return _instance;
                }

                return _instance = GetAssets();
            }
            set
            {
                _instance = value;
            }
        }

#endif

        [Header("Debug Message")]
        public bool adjustMessageColor = false;
        public bool adjustNumeralColor = true;

        [Space]
        public Color defaultMessageColor = Color.white;
        public Color warningMessageColor = Color.yellow;
        public Color errorMessageColor = Color.red;

        [Space]
        public Color numeralMessageColor = Color.green;

        [Header("Debug Tag")]
        public bool enableDebugTag = true;
        public bool enableDebugColor = false;

        [Space]
        public Color debugColor = Color.white;
        public Color warningColor = Color.yellow;
        public Color errorColor = Color.red;

        [Header("Time Stamping")]
        public bool showTimestampAtStart = true;
        public bool showTimestamp = true;
        public bool showMilliseconds;

        [Space]
        public Color timeStampColor = Color.white;

        [Header("Type Coloring")]
        public bool enableTypeColoring = true;

        [Space]
        public int ColorSeed = 417;
        public float ColorSaturation = 0.6f;
        public float ColorValue = 0.95f;


#if UNITY_EDITOR
        // While Runtime scripts do not require access to this class
        // The Utility script does... So we remove Editor related code for runtime
        // To not cause any issues and prevent future issues

        public static ResolveEditorSettings GetAssets()
        {
            if (_instance != null)
                return _instance;

            string[] guids = AssetDatabase.FindAssets(string.Format("t:{0}", typeof(ResolveEditorSettings).Name));

            for (int i = 0; i < guids.Length; i++)
            {
                instance = AssetDatabase.LoadAssetAtPath<ResolveEditorSettings>(AssetDatabase.GUIDToAssetPath(guids[i]));
                if (_instance != null)
                    return _instance;
            }
                
            return _instance = CreateAssets();
        }

        internal static ResolveEditorSettings CreateAssets()
        {
            string path = EditorUtility.SaveFilePanelInProject("Save as...", "Resolve Editor Settings", "asset", "");

            if (path.Length > 0)
            {
                ResolveEditorSettings settings = CreateInstance<ResolveEditorSettings>();
                AssetDatabase.CreateAsset(settings, path);
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();
                EditorUtility.FocusProjectWindow();
                Selection.activeObject = settings;

                return settings;
            }

            return null;
        }
#endif
    }
}


