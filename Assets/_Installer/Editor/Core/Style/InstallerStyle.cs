
using System.IO;
using UnityEditor;
using UnityEngine;

namespace _Installer
{
    internal static class InstallerStyle
    {
        
        // ICONS
        private static Texture _installIcon;
        private static Texture _iconTest;
        private static Texture _backButton;

        
        private static bool isStyleInit;
        
        
        
        private static string _texturesPath;


        
        #region Paths
        
        
        private static string TexturesPath
        {
            get
            {
                if (!string.IsNullOrEmpty(_texturesPath))
                {
                    return _texturesPath;
                }

                var res = Directory.GetFiles(Application.dataPath, "InstallerWindow.cs", SearchOption.AllDirectories);
                var assetPath = res[0].Replace("\\", "/");
                assetPath = "Assets" + assetPath.Replace(Application.dataPath, "");
                _texturesPath = Directory.GetParent(Directory.GetParent(assetPath).ToString()) + "/Textures/";

                return _texturesPath;
            }
        }


        private static void LoadTexturePath()
        {
            var res = Directory.GetFiles(Application.dataPath, "InstallerWindow.cs", SearchOption.AllDirectories);
            var assetPath = res[0].Replace("\\", "/");
            assetPath = "Assets" + assetPath.Replace(Application.dataPath, "");
            _texturesPath = Directory.GetParent(Directory.GetParent(assetPath).ToString()) + "/Editor/Textures/";
            
            
            // Enable this log in case of missing Textures
            //Debug.Log("Textures Path is: " + _texturesPath);
        }

        
        #endregion
        
        
        
        #region Textures
        
        
        public static Texture InstallIcon
        {
            get
            {
                if (_installIcon)
                {
                    return _installIcon;
                }

                return _installIcon = AssetDatabase.LoadAssetAtPath(TexturesPath + "DownloadIcon.png", typeof(Texture)) as Texture;
            }
        }

        public static Texture TestIcon
        {
            get
            {
                if (_iconTest)
                {
                    return _iconTest;
                }

                return _iconTest = AssetDatabase.LoadAssetAtPath(TexturesPath + "Test1.png", typeof(Texture)) as Texture;
            }
        }

        public static Texture BackButton
        {
            get
            {
                if (_backButton)
                {
                    return _backButton;
                }

                return _backButton = AssetDatabase.LoadAssetAtPath(TexturesPath + "BackButton.png", typeof(Texture)) as Texture;
            }
        }

        #endregion
        
        
        
        public static void InitStyle()
        {
            if (!isStyleInit)
            {
                LoadTexturePath();
            }
            isStyleInit = true;
        }
        
        
    }
}