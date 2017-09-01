using System;
using RGiesecke.DllExport;
using System.Runtime.InteropServices;

namespace DemoPluginNet
{

    delegate void IdeCreateWindow(int windowType, string text, [MarshalAs(UnmanagedType.Bool)] bool execute);

    [return: MarshalAs(UnmanagedType.Bool)]
    delegate bool IdeSetText(string text);

    public class DemoPlugin
    {
        private const string PLUGIN_NAME = "Demo plug-in in C#";
        private const int PLUGIN_MENU_INDEX = 10;

        private const int CREATE_WINDOW_CALLBACK = 20;
        private const int SET_TEXT_CALLBACK = 34;

        private static DemoPlugin me;

        private static IdeCreateWindow createWindowCallback;
        private static IdeSetText setTextCallback;

        private int pluginId;

        private DemoPlugin(int id)
        {
            pluginId = id;
        }

        #region DLL exported API
        [DllExport("IdentifyPlugIn", CallingConvention = CallingConvention.Cdecl)]
        public static string IdentifyPlugIn(int id)
        {
            if (me == null)
            {
                me = new DemoPlugin(id);
            }
            return PLUGIN_NAME;
        }

        [DllExport("RegisterCallback", CallingConvention = CallingConvention.Cdecl)]
        public static void RegisterCallback(int index, IntPtr function)
        {
            switch (index)
            {
                case CREATE_WINDOW_CALLBACK:
                    createWindowCallback = (IdeCreateWindow)Marshal.GetDelegateForFunctionPointer(function, typeof(IdeCreateWindow));
                    break;
                case SET_TEXT_CALLBACK:
                    setTextCallback = (IdeSetText)Marshal.GetDelegateForFunctionPointer(function, typeof(IdeSetText));
                    break;
            }
        }

        [DllExport("OnMenuClick", CallingConvention = CallingConvention.Cdecl)]
        public static void OnMenuClick(int index)
        {
            if (index == PLUGIN_MENU_INDEX)
            {
                me.ShowDemoForm();
            }
        }

        [DllExport("CreateMenuItem", CallingConvention = CallingConvention.Cdecl)]
        public static string CreateMenuItem(int index)
        {
            if (index == PLUGIN_MENU_INDEX)
            {
                return "Tools / Demo plug-in in C#";
            }
            else
            {
                return "";
            }
        }

        [DllExport("About", CallingConvention = CallingConvention.Cdecl)]
        public static string About()
        {
            return "A demo plug-in written in C#.\nVisit project page and wiki at https://github.com/aniskop/plsql-developer-plugin-net.";
        }
        #endregion

        public string Name
        {
            get
            {
                return PLUGIN_NAME;
            }

        }

        public void CreateSqlWindow()
        {
            createWindowCallback(1, "", false);
            setTextCallback("select 'Hello world!' from dual");
        }

        private void ShowDemoForm()
        {
            DemoForm frm = new DemoForm();
            frm.Show(me);
        }
    }
}
