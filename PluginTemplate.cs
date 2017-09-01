using System;
using RGiesecke.DllExport;
using System.Runtime.InteropServices;

//TODO: set plug-in namespace
namespace YourNamespace
{
    //TODO: set plug-in class name
    public class TemplatePlugin
    {
        //TODO: set plug-in name
        private const string PLUGIN_NAME = "Plug-in name";

        //TODO: assign the menu index to the menu item created by your plug-in [1-99].
        private const int PLUGIN_MENU_INDEX = 1;

        private static TemplatePlugin me;
        private int pluginId;

        private TemplatePlugin(int id)
        {
            pluginId = id;
        }

        #region DLL exported API
        [DllExport("IdentifyPlugIn", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static string IdentifyPlugIn(int id)
        {
            if (me == null)
            {
                me = new TemplatePlugin(id);
            }
            return PLUGIN_NAME;
        }

        [DllExport("RegisterCallback", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static void RegisterCallback(int index, IntPtr function)
        {
            //TODO: register pointers to PL/SQL Developer callbacks you need
        }

        [DllExport("OnMenuClick", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static void OnMenuClick(int index)
        {
            if (index == PLUGIN_MENU_INDEX)
            {
                //TODO: do something when plug-in's menu is clicked.
            }
        }

        [DllExport("CreateMenuItem", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static string CreateMenuItem(int index)
        {
            if (index == PLUGIN_MENU_INDEX)
            {
                //TODO: create a menu item
                return "Tools / My plug-in menu item";
            }
            else
            {
                return "";
            }
        }

        [DllExport("About", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static string About()
        {
            //TODO: create about dialog
            return "This is my plug-in";
        }
        #endregion
    }
}
