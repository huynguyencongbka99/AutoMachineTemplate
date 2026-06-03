using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaoFileINI_RECIPE
{
    public class Recipe
    {
        public string Name { get; set; }

        public CameraConfig Camera { get; set; }
            = new CameraConfig();

        public VisionConfig Vision { get; set; }
            = new VisionConfig();

        public RobotConfig Robot { get; set; }
            = new RobotConfig();
    }

}
