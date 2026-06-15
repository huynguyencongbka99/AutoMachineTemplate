using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaoFileINI_RECIPE
{
    public static class RecipeManager
    {
        public static Recipe CurrentRecipe
        {
            get;
            private set;
        }

        public static readonly string RecipeFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Recipe");

        public static void Load(string recipeName)
        {
            string path =
                Path.Combine(
                    RecipeFolder,
                    $"{recipeName}.ini");

            CurrentRecipe = new Recipe
            {
                Name = recipeName
            };

            #region PLC Recipe
            CurrentRecipe.Plc.IP = INI.Read(
                        "PLC",
                        "IP",
                        path);
            CurrentRecipe.Plc.Port = int.Parse(
                         INI.Read(
                             "PLC",
                             "Port",
                             path));
            CurrentRecipe.Plc.Timeout = int.Parse(
                        INI.Read(
                            "PLC",
                            "Timeout",
                            path));
            #endregion

            #region Camera
            CurrentRecipe.Camera.Exposure =
                double.Parse(
                    INI.Read(
                        "CAMERA",
                        "Exposure",
                        path));

            CurrentRecipe.Camera.Gain =
                double.Parse(
                    INI.Read(
                        "CAMERA",
                        "Gain",
                        path));

            CurrentRecipe.Camera.TriggerMode =
                INI.Read(
                    "CAMERA",
                    "TriggerMode",
                    path);
            #endregion

            #region Vision
            CurrentRecipe.Vision.Score =
                double.Parse(
                    INI.Read(
                        "VISION",
                        "Score",
                        path));

            CurrentRecipe.Vision.AngleStart =
                double.Parse(
                    INI.Read(
                        "VISION",
                        "AngleStart",
                        path));

            CurrentRecipe.Vision.AngleEnd =
                double.Parse(
                    INI.Read(
                        "VISION",
                        "AngleEnd",
                        path));
            #endregion

            #region Robot
            CurrentRecipe.Robot.IP = INI.Read(
                        "ROBOT",
                        "IP",
                        path);
            CurrentRecipe.Robot.Port = int.Parse(
                         INI.Read(
                             "ROBOT",
                             "Port",
                             path));

            CurrentRecipe.Robot.Speed =
                double.Parse(
                    INI.Read(
                        "ROBOT",
                        "Speed",
                        path));

            CurrentRecipe.Robot.Accel =
                double.Parse(
                    INI.Read(
                        "ROBOT",
                        "Accel",
                        path));
        }

        #endregion

        public static void Save()
        {
            if (CurrentRecipe == null)
                return;

            string path =
                Path.Combine(
                    RecipeFolder,
                    $"{CurrentRecipe.Name}.ini");

            INI.Write("PLC","IP",CurrentRecipe.Plc.IP.ToString(),path);
            INI.Write("PLC", "Port", CurrentRecipe.Plc.Port.ToString(), path);
            INI.Write("PLC", "Timeout", CurrentRecipe.Plc.Timeout.ToString(), path);


            INI.Write(
                "CAMERA",
                "Exposure",
                CurrentRecipe.Camera.Exposure.ToString(),
                path);

            INI.Write(
                "CAMERA",
                "Gain",
                CurrentRecipe.Camera.Gain.ToString(),
                path);

            INI.Write(
                "CAMERA",
                "TriggerMode",
                CurrentRecipe.Camera.TriggerMode,
                path);

            INI.Write(
                "VISION",
                "Score",
                CurrentRecipe.Vision.Score.ToString(),
                path);

            INI.Write(
                "VISION",
                "AngleStart",
                CurrentRecipe.Vision.AngleStart.ToString(),
                path);

            INI.Write(
                "VISION",
                "AngleEnd",
                CurrentRecipe.Vision.AngleEnd.ToString(),
                path);

            INI.Write(
                "ROBOT",
                "Speed",
                CurrentRecipe.Robot.Speed.ToString(),
                path);

            INI.Write(
                "ROBOT",
                "Accel",
                CurrentRecipe.Robot.Accel.ToString(),
                path);

            INI.Write(
                "ROBOT",
                "IP",
                CurrentRecipe.Robot.IP.ToString(),
                path);

            INI.Write(
                "ROBOT",
                "Port",
                CurrentRecipe.Robot.Port.ToString(),
                path);
        }

        public static void SaveAs(string recipeName)
        {
            if (CurrentRecipe == null) return;
            string oldName = CurrentRecipe.Name;
            CurrentRecipe.Name = recipeName;
            Save();
            CurrentRecipe.Name = oldName;
        }
    }
}
