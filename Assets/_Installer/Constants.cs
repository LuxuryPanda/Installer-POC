namespace _Installer
{
    // Class that contains all the Editor Constants
    // All the modifications can be applied here
    public static class Constants
    {
        
        #region INSTALLER
        
        public const string CURRENT_INSTALLER_VERSION = "1.0.0";

        public const string INSTALLER_MENUITEM = "Tools/Installer";
        public const string INSTALLERWINDOW_TITLE = "Welcome to the Installer POC";
        
        public const int INSTALLER_PRIORITY = 0;

        
        public const string INSTALLER_PATH = "Assets/_Installer/Editor/";
        public const string INSTALLER_PACKAGES = INSTALLER_PATH + "Packages/";
        public const string INSTALLER_RESOURCES = "Assets/_Installer/Editor/Resources/";
        
        
        #endregion


        #region INSTALLER SIZES
        
        public const float PADDING = 80;
        public const float TOP = 30;
        
        public const float WIDTH = 500;
        public const float HEIGHT = 500;
        
        #endregion
        
    }
}