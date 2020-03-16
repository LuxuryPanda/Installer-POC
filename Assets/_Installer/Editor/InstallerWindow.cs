
using System;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;


namespace _Installer
{
    public class InstallerWindow : EditorWindow
    {
        
        
        #region Variables
        
        
        private Pages currentPage = Pages.Home;
        private Pages nextPage;
        private Rect currentPageRect;
        private Rect nextPageRect;
        private float currentPageMoveTo;
        private Rect headerRect;
        private Rect backButtonRect;

        private bool pageInTransition;
        private float transitionStartTime;
        private const float transitionDuration = 0.5f;

        private Vector2 scrollPosition;


        #endregion
        
        
        
        #region Window
        
        
        [MenuItem(Constants.INSTALLER_MENUITEM, false, Constants.INSTALLER_PRIORITY)]
        public static void OpenWelcomeWindow()
        {
            var window = GetWindow<InstallerWindow>(true);
            window.SetPage(Pages.Home);
        }


        #endregion
        
        
        
        private void Update()
        {
            if (pageInTransition)
            {
                TweenPage();
            }
        }


        public void OnEnable()
        {
            titleContent = new GUIContent(Constants.INSTALLERWINDOW_TITLE);
            maxSize = new Vector2(Constants.WIDTH, Constants.HEIGHT);
            minSize = maxSize;
            
            
            currentPageRect = new Rect(0, Constants.TOP, Constants.WIDTH, Constants.HEIGHT - Constants.PADDING);
            nextPageRect = new Rect(0, Constants.TOP, Constants.WIDTH, Constants.HEIGHT - Constants.PADDING);
            headerRect = new Rect(0, 0, Constants.WIDTH, 60);
            backButtonRect = new Rect(0, Constants.WIDTH - 30, 25, 26);

            
            SetPage(currentPage);               
            Update();
        }




        public void OnGUI()
        {
            InstallerStyle.InitStyle();
    
            
            GUILayout.BeginVertical();
            GUILayout.BeginVertical();
            GUILayout.BeginHorizontal();
            
            DrawPage(currentPage, currentPageRect);
            
            
            if (pageInTransition)
            {
                DrawPage(nextPage, nextPageRect);
            }
            
            GUILayout.EndHorizontal();

            GUILayout.EndVertical();
            GUILayout.EndVertical();

            if (currentPage != Pages.Home && !pageInTransition)
            {
                DrawBackButton(Pages.Home);
            }
        }
        
        

        
        #region Pages Stuff
        
        
        private void DrawPage(Pages page, Rect pageRect)
        {
            pageRect.height = position.height - Constants.PADDING;
            GUILayout.BeginArea(pageRect);

            switch (page)
            {
                case Pages.Home:
                    DrawHome();
                    break;
                case Pages.Install:
                    DrawTestPage();
                    break;
                case Pages.TestPage:
                    DrawTestPage2();
                    break;
            }

            GUILayout.EndArea();
        }

        private void DrawHome()
        {
            GUILayout.BeginVertical();
            GUILayout.FlexibleSpace();
            
            EditorStyleAddOns.DrawLink(InstallerStyle.InstallIcon,
                    "Install the package",
                    "Install the latest version of the package.",
                    GotoPage, Pages.Install);

            EditorStyleAddOns.DrawLink(InstallerStyle.TestIcon,
                     "Test page 2",
                     "That's the second page :D",
                     GotoPage, Pages.TestPage);

            GUILayout.FlexibleSpace();
            GUILayout.EndVertical();
        }

        private static void DrawTestPage()
        {
            EditorStyleAddOns.DrawHelpBox("HelpBox test!!", MessageType.Info);

            GUILayout.BeginVertical();
            GUILayout.Space(20);

            EditorStyleAddOns.DrawLink(InstallerStyle.InstallIcon, "TEST BUTTON!!", "", null, null);


            GUILayout.FlexibleSpace();
            GUILayout.EndVertical();
        }

        
        private static void DrawTestPage2()
        {
            GUILayout.BeginVertical();
            GUILayout.FlexibleSpace();

            EditorStyleAddOns.DrawLink(InstallerStyle.InstallIcon,
                 "Sub-Button 1",
                 "Test sub-button 1!",
                 CoreAddOns.OpenUrl, "");

            EditorStyleAddOns.DrawLink(InstallerStyle.TestIcon,
                 "Sub-Button 2",
                 "Test sub-button 2!",
                 CoreAddOns.OpenUrl, "");

            GUILayout.FlexibleSpace();
            GUILayout.EndVertical();
        }
        
        
        private void GotoPage(object userData)
        {
            nextPage = (Pages)userData;
            pageInTransition = true;
            transitionStartTime = Time.realtimeSinceStartup;
            
            
            if (nextPage == Pages.Home)
            {
                nextPageRect.x = -Constants.WIDTH;
                currentPageMoveTo = Constants.WIDTH;
            }
            else
            {
                nextPageRect.x = Constants.WIDTH;
                currentPageMoveTo = -Constants.WIDTH;
            }

            GUIUtility.ExitGUI();
        }

        private void SetPage(Pages page)
        {
            currentPage = page;
            nextPage = page;
            pageInTransition = false;
            currentPageRect.x = 0;
            Repaint();
        }

        #endregion
        
        
        #region Pages Core
        
        
        private void DrawBackButton(Pages toPage)
        {
            GUI.Box(backButtonRect, InstallerStyle.BackButton, GUIStyle.none);
            EditorGUIUtility.AddCursorRect(backButtonRect, MouseCursor.Link);

            if (Event.current.type == EventType.MouseDown && backButtonRect.Contains(Event.current.mousePosition))
            {
                GotoPage(toPage);
                GUIUtility.ExitGUI();
            }
        }


        private void TweenPage()
        {
            var t = (Time.realtimeSinceStartup - transitionStartTime) / transitionDuration;
            if (t > 1f)
            {
                SetPage(nextPage);
                return;
            }

            var nextPageX = Mathf.SmoothStep(nextPageRect.x, 0, t);
            var currentPageX = Mathf.SmoothStep(currentPageRect.x, currentPageMoveTo, t);
            currentPageRect.Set(currentPageX, Constants.TOP, Constants.WIDTH, position.height);
            nextPageRect.Set(nextPageX, Constants.TOP, Constants.WIDTH, position.height);

            Repaint();
        }
        

        #endregion
        
    }
}