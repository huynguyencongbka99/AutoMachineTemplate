using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaoFileINI_RECIPE
{
    public static class ConfigManager
    {
        public static SystemConfig System
        {
            get;
            private set;
        }

        public static readonly string ConfigFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Config");

        public static readonly string InitPath = Path.Combine(ConfigFolder, "Initialize.ini");

        public static void Load()
        {
            System = new SystemConfig
            {
                LastRecipe =
                    INI.Read(
                        "SYSTEM",
                        "LastRecipe",
                        InitPath)
            };
        }

        public static void Save()
        {
            INI.Write(
                "SYSTEM",
                "LastRecipe",
                System.LastRecipe,
                InitPath);
        }
    }
}
