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
        
        
        public static void InstallTestPackage(object callback)
        {
            if (ShowDialog("Installer POC v1", "Do you want to install the package??", "Yes of course, let's go!!", "No, cancel!"))
            {
                ImportPackage(AssetsGUIDs.DemoPackage);
            }
        }
        
        /// <summary>
        /// Import a package using its path or GUID
        /// </summary>
        /// <param name="package">Package's path or GUID</param>
        public static void ImportPackage(string package)
        {
            try
            {
                AssetDatabase.ImportPackage(AssetDatabase.GUIDToAssetPath(package), true);
            }
            catch (Exception e)
            {
                Debug.LogError("Error while importing the package '" + package + "'" + " | Exception: <" + e + ">");
                throw;
            }
        }

        #endregion
        
        
        #region Dialogs
        
        public static bool ShowDialog(string title, string message, string acceptText, string cancelText)
        {
            return EditorUtility.DisplayDialog(title, message, acceptText, cancelText);
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

