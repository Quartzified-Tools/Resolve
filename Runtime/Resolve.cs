using Quartzified.Resolve.Editor;
using System;
using System.Text;
using UnityEngine;

namespace Quartzified.Resolve
{
    public static class Resolve
    {
        public static bool showDebugTag
        {
            set
            {
                ResolveSettings.showDebugTag = value;
            }
            get
            {
                return ResolveSettings.showDebugTag;
            }
        }

        public static bool showTimestamps
        {
            set
            {
                ResolveSettings.showTimestamp = value;
            }
            get
            {
                return ResolveSettings.showTimestamp;
            }
        }

        public static bool showMilliseconds
        {
            set
            {
                ResolveSettings.showMilliseconds = value;
            }
            get
            {
                return ResolveSettings.showMilliseconds;
            }
        }

        #region Log

        public static void Log(string message)
        {
            Log(message, null);
        }

        public static void Log(string message, Type type)
        {
            if (type == null)
                InternalLog(LogType.Log, message, null, null);
            else
                InternalLog(LogType.Log, message, null, type);
        }

        #endregion

        #region LogWarning

        public static void LogWarning(string message)
        {
            LogWarning(message, null);
        }

        public static void LogWarning(string message, Type type)
        {
            if (type == null)
                InternalLog(LogType.Warning, message, null, null);
            else
                InternalLog(LogType.Warning, message, null, type);
        }

        #endregion

        #region LogError

        public static void LogError(string message)
        {
            LogError(message, null);
        }

        public static void LogError(string message, Type type)
        {
            if (type == null)
                InternalLog(LogType.Error, message, null, null);
            else
                InternalLog(LogType.Error, message, null, type);
        }

        #endregion

        static void InternalLog(LogType logType, object message, UnityEngine.Object context = null, Type type = null)
        {
            string typeResult = ResolveUtility.FillTypeResult(type);
            string timeStamp = ResolveUtility.GetTimeStamp();
            string beutifyMessage = ResolveUtility.BeutifyMessage(logType, message.ToString());

            StringBuilder builder = new StringBuilder();
            builder.Append(timeStamp);
            builder.Append(typeResult);
            builder.Append(beutifyMessage);

            if(logType == LogType.Error)
            {
#if UNITY_EDITOR
                if (ResolveEditorSettings.instance.enableDebugTag)
                    builder.Insert(0, ResolveEditorSettings.instance.enableDebugColor ? 
                        "[Error] ".SetColor(ResolveEditorSettings.instance.errorColor) : "[Error] ");
#else
                if (ResolveSettings.showDebugTag)
                    builder.Insert(0, "[Error] ");
#endif
                
                // TODO add runtime setting

                Debug.LogError(builder.ToString(), context);
            }
            else if(logType == LogType.Warning)
            {
#if UNITY_EDITOR
                if (ResolveEditorSettings.instance.enableDebugTag)
                    builder.Insert(0, ResolveEditorSettings.instance.enableDebugColor ?
                        "[Warning] ".SetColor(ResolveEditorSettings.instance.warningColor) : "[Warning] ");
#else
                if (ResolveSettings.showDebugTag)
                    builder.Insert(0, "[Warning] ");
#endif

                Debug.LogWarning(builder.ToString(), context);
            }
            else
            {
#if UNITY_EDITOR
                if (ResolveEditorSettings.instance.enableDebugTag)
                    builder.Insert(0, ResolveEditorSettings.instance.enableDebugColor ?
                        "[Debug] ".SetColor(ResolveEditorSettings.instance.debugColor) : "[Debug] ");
#else
                if (ResolveSettings.showDebugTag)
                    builder.Insert(0, "[Debug] ");
#endif

                Debug.Log(builder.ToString(), context);
            }
        }



    }

}

