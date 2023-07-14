#if UNITY_EDITOR
using Quartzified.Resolve.Editor;
#endif

using System;
using System.Text;
using UnityEngine;

namespace Quartzified.Resolve
{
    public static class ResolveUtility
    {

#if UNITY_EDITOR
        static ResolveEditorSettings editorSettings => ResolveEditorSettings.instance;
#endif

        #region Message Coloring

        public static string BeutifyMessage(LogType logType, string message)
        {
#if UNITY_EDITOR

            if (editorSettings.adjustNumeralColor)
            {
                StringBuilder result = new StringBuilder();
                string[] splitMessage = message.Split(' ');

                for (int i = 0; i < splitMessage.Length; i++)
                {
                    string temp = splitMessage[i];

                    if (System.Text.RegularExpressions.Regex.IsMatch(temp, @"^-?\d+(?:\.\d+)?%?(?=[.,()!%:]|$)|^\(-?\d+(?:\.\d+)?%?(?=[.,()!%:]|$)"))
                    {
                        splitMessage[i] = temp.SetColor(editorSettings.numeralMessageColor);
                    }

                    if (i < splitMessage.Length - 1)
                        result.Append(splitMessage[i] + " ");
                    else
                        result.Append(splitMessage[i]);

                }

                message = result.ToString();
            }

            if (editorSettings.adjustMessageColor)
            {
                if (logType == LogType.Warning)
                {
                    message = message.SetColor(editorSettings.warningMessageColor);
                }
                else if (logType == LogType.Error)
                {
                    message = message.SetColor(editorSettings.errorMessageColor);
                }
                else
                {
                    message = message.SetColor(editorSettings.defaultMessageColor);
                }
            }

#endif

            return message;
        }

        #endregion

        #region Time Stamping

        public static string GetTimeStamp()
        {
#if UNITY_EDITOR
            if(editorSettings.showTimestamp)
            {
                return (editorSettings.showMilliseconds ? DateTime.Now.ToString("[HH:mm:ss.fff] ") : DateTime.Now.ToString("[HH:mm:ss] ")).SetColor(editorSettings.timeStampColor);
            }
#endif

            if(ResolveSettings.showTimestamp)
            {
                return ResolveSettings.showMilliseconds ? DateTime.Now.ToString("[HH:mm:ss.fff] ") : DateTime.Now.ToString("[HH:mm:ss] ");
            }

            return string.Empty;
        }

        #endregion

        #region Type Result

        public static string FillTypeResult(System.Type type = null)
        {
            if (type == null)
                return string.Empty;

            return GetTypeResult(type);
        }

        public static string GetTypeResult(System.Type type)
        {
            string typeResult = "";
            string typeName = type.Name;

#if UNITY_EDITOR
            if (editorSettings.enableTypeColoring)
            {
                Color typeColor = ColorFromName(typeName);
                typeResult = string.Format("[{0}] ", typeName).SetColor(typeColor);
            }
            else
            {
                typeResult = string.Format("[{0}] ", typeName);
            }
#else
                typeResult = string.Format("[{0}] ", typeName);
#endif

            return typeResult;
        }

        #endregion

#if UNITY_EDITOR
        // This should only work in the Editor
        // As we do not want to add unecessary data into Runtime Debug Files.

        // Original code under MIT Copyright (c) James Frowen
        public static Color ColorFromName(string name)
        {
            int hash = name.GetStableHashCode();
            
            if (editorSettings.ColorSeed != 0)
                hash = unchecked(editorSettings.ColorSeed * hash);

            float hue = Mathf.Abs(hash / (float)int.MaxValue);
            return Color.HSVToRGB(hue, editorSettings.ColorSaturation, editorSettings.ColorValue);
        }
#endif

        public static string SetColor(this string s, string color) => string.Format("<color={1}>{0}</color>", s, color);

        public static string SetColor(this string s, Color color) => string.Format("<color=#{1}>{0}</color>", s, ColorUtility.ToHtmlStringRGB(color));

        static int GetStableHashCode(this string text)
        {
            unchecked
            {
                int hash = 23;

                foreach (char c in text)
                {
                    hash = hash * 31 + c;
                }

                return hash;
            }
        }
    }
}


