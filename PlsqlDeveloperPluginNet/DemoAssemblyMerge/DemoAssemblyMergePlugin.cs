using System;
using RGiesecke.DllExport;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace DemoAssemblyMerge
{

    public class DemoAssemblyMergePlugin
    {
        private const string PLUGIN_NAME = "Demo Merge Assemblies";

        private const int PLUGIN_MENU_ITEM_INDEX = 3;

        private static DemoAssemblyMergePlugin me;
        private int pluginId;

        private DemoAssemblyMergePlugin(int id)
        {
            pluginId = id;
        }

        [DllExport("IdentifyPlugIn", CallingConvention = CallingConvention.Cdecl)]
        public static string IdentifyPlugIn(int id)
        {
            if (me == null)
            {
                me = new DemoAssemblyMergePlugin(id);
            }

            return PLUGIN_NAME;
        }

        [DllExport("RegisterCallback", CallingConvention = CallingConvention.Cdecl)]
        public static void RegisterCallback(int index, IntPtr function)
        {
        }

        [DllExport("OnMenuClick", CallingConvention = CallingConvention.Cdecl)]
        public static void OnMenuClick(int index)
        {
            if (index == PLUGIN_MENU_ITEM_INDEX)
            {
                DemoCar car = new DemoCar();
                car.Manufacturer = "Volswagen";
                car.Model = "Jetta";
                car.ProductionYear = 2018;
                MessageBox.Show("DemoCar object serialized with Newtonsoft.Json library is \n" + JsonConvert.SerializeObject(car));

            }
        }

        [DllExport("CreateMenuItem", CallingConvention = CallingConvention.Cdecl)]
        public static string CreateMenuItem(int index)
        {
            switch (index)
            {
                case 1:
                    return "TAB=Demo plug-ins .NET";

                case 2:
                    return "GROUP=All-in-one assembly";

                case PLUGIN_MENU_ITEM_INDEX:
                    return "ITEM=Object to JSON";

                default:
                    return "";
            }
        }

        [DllExport("About", CallingConvention = CallingConvention.Cdecl)]
        public static string About()
        {
            return "This plug-in demonstrates a standalone (or all-in-one) assembly, where dependencies are merged into the assembly.\n" +
                "This plug-in has dependency to the Newtonsoft.Json library.\nThe dependency is embedded inside the plug-in assembly - Newtonsoft.Json.dll must not be copied on the disk.\n" +
                "This makes development, distribution and installation of the plug-in easier.";
        }
    }
}
