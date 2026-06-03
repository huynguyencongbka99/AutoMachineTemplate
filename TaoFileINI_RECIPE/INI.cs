using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace TaoFileINI_RECIPE
{
        public class INI
        {
            [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
            private static extern long WritePrivateProfileString(
                string section,
                string key,
                string value,
                string filePath);

            [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
            private static extern int GetPrivateProfileString(
                string section,
                string key,
                string defaultValue,
                StringBuilder retVal,
                int size,
                string filePath);

            public static void Write(
                string section,
                string key,
                string value,
                string path)
            {
                WritePrivateProfileString(
                    section,
                    key,
                    value,
                    path);
            }

            public static string Read(
                string section,
                string key,
                string path,
                string defaultValue = "")
            {
                StringBuilder sb = new StringBuilder(1024);

                GetPrivateProfileString(
                    section,
                    key,
                    defaultValue,
                    sb,
                    sb.Capacity,
                    path);

                return sb.ToString();
            }
        }
}
