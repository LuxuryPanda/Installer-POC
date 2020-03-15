
using UnityEditor;
using UnityEngine;

namespace _Installer
{
    internal static class EditorStyleAddOns
    {
        
        public static readonly GUIContent label = new GUIContent();
        
        private static GUIStyle labelWithWordWrap = new GUIStyle(EditorStyles.label)
        {
            wordWrap = true
        };
        
        
        
        
        #region Drawers
        
        
        public static void DrawLink(Texture texture, string heading, string body, CoreAddOns.MethodToCall callback, object userData)
        {
            GUILayout.BeginHorizontal();

            GUILayout.Space(64);
            GUILayout.Box(texture, GUIStyle.none, GUILayout.MaxWidth(48));
            GUILayout.Space(10);

            GUILayout.BeginVertical();
            GUILayout.Space(1);
            GUILayout.Label(heading, EditorStyles.boldLabel);
            GUILayout.Label(body, labelWithWordWrap);
            GUILayout.EndVertical();

            GUILayout.EndHorizontal();

            var rect = GUILayoutUtility.GetLastRect();
            EditorGUIUtility.AddCursorRect(rect, MouseCursor.Link);

            if (Event.current.type == EventType.MouseDown && rect.Contains(Event.current.mousePosition))
            {
                callback(userData);
                GUIUtility.ExitGUI();
            }

            GUILayout.Space(10);
        }
        
        
        
        
        public static void DrawHelpBox(string text, MessageType messageType)
        {
            GUILayout.BeginHorizontal();
            EditorGUILayout.HelpBox(text, messageType);
            GUILayout.Space(5);
            GUILayout.EndHorizontal();
        }
        
        public static void DrawHelpBox(string text, MessageType messageType, int space)
        {
            GUILayout.BeginHorizontal();
            EditorGUILayout.HelpBox(text, messageType);
            GUILayout.Space(space);
            GUILayout.EndHorizontal();
        }
        
        
        public static void DrawSectionTitle(string title)
        {
            GUILayout.Label(title, EditorStyles.boldLabel);
        }

        public static void DrawTopSpacer()
        {
            GUILayout.Space(10);
        }

        public static void DrawBottomSpacer()
        {
            GUILayout.Space(20);
        }
        
        
        
        #endregion

        
        
        public static bool DrawButton(string name, string tooltip)
        {
            InitLabel(name, tooltip);
            return GUILayout.Button(label, GUILayout.Height(25));
        }
	    

        public static void InitLabel(string text, string tooltip)
        {
            label.text = text;
            label.tooltip = tooltip;
        }
        
        
    }
}