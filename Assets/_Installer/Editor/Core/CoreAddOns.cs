using System;
using UnityEditor;
using UnityEngine;



namespace _Installer
{
    public static class CoreAddOns
    {
        public delegate void MethodToCall(object callback);
        
        #region Unity Version
        
        
        
        public static bool IsUnityPro()
        {
            return Application.HasProLicense();
        }
        
        
        
        #endregion
        
        
        #region Installation
        
        public static MethodToCall ImportPackage(string packagePath)
        {
            try
            {
                AssetDatabase.ImportPackage(packagePath, true);
            }
            catch (Exception e)
            {
                Debug.LogError("Error while importing the package '" + packagePath + "'" + " | Exception: <" + e + ">");
                throw;
            }

            return null;
        }

        #endregion
        
        
        #region Dialogs
        
        
        public static void ShowDialog(string title, string message, string buttonText)
        {
            EditorUtility.DisplayDialog(title, message, buttonText);
        }

        #endregion
        
        
        #region Extra
        
        public static void OpenUrl(object link)
        {
            Application.OpenURL(link as string);
        }
        
        public static void DrawURLButton(string name, string tooltip, string url)
        {
            if (EditorStyleAddOns.DrawButton(name, tooltip))
            {
                Application.OpenURL(url);
            }
        }
        
        #endregion
        
    }
}

