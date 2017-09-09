using System;
using RGiesecke.DllExport;
using System.Runtime.InteropServices;

namespace DemoCommandLinePluginNet
{

    delegate void IdeCommandFeedback(int feedbackHandle, string text);

    public class DemoCommandPluginNet
    {
        private const string PLUGIN_NAME = "Demo command line plug-in in C#";

        private static DemoCommandPluginNet me;
        private int pluginId;

        private const int COMMAND_FEEDBACK_CALLBACK = 180;
        private static IdeCommandFeedback commandFeedbackCallback;

        private DemoCommandPluginNet(int id)
        {
            pluginId = id;
        }

        #region DLL exported API
        [DllExport("IdentifyPlugIn", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static string IdentifyPlugIn(int id)
        {
            if (me == null)
            {
                me = new DemoCommandPluginNet(id);
            }
            return PLUGIN_NAME;
        }

        [DllExport("RegisterCallback", CallingConvention = System.Runtime.InteropServices.CallingConvention.Cdecl)]
        public static void RegisterCallback(int index, IntPtr function)
        {
            if (index == COMMAND_FEEDBACK_CALLBACK)
            {
                commandFeedbackCallback = (IdeCommandFeedback)Marshal.GetDelegateForFunctionPointer(function, typeof(IdeCommandFeedback));
            }
        }

        [DllExport("About", CallingConvention = CallingConvention.Cdecl)]
        public static string About()
        {
            return "This demo plug-in demonstrates, how plug-in accepts commands in the command window.\nVisit project page and wiki at https://github.com/aniskop/plsql-developer-plugin-net.";
        }

        [DllExport("CommandLine", CallingConvention = CallingConvention.Cdecl)]
        public static void CommandLine(int feedbackHandle, string command, string parameters)
        {
            string output = "Hello world!\n";

            if (command != null)
            {
                output += "command=" + command + "\n";
            }

            if (parameters != null)
            {
                output += "parameters=" + parameters + "\n";
            }

            me.PrintOutput(feedbackHandle, output);
        }

        [DllExport("PlugInShortName", CallingConvention = CallingConvention.Cdecl)]
        public static string PluginShortName()
        {
            return "dm";
        }

        [DllExport("PlugInName", CallingConvention = CallingConvention.Cdecl)]
        public static string PluginName()
        {
            return "demo";
        }

        private void PrintOutput(int feedbackHandle, string text)
        {
            commandFeedbackCallback(feedbackHandle, text);
        }
        #endregion
    }

}
