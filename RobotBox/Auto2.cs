using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotBox
{
    namespace RobotBox
    {
        public enum AutoStep
        {
            Idle,
            WaitVision,
            WaitPick,
            WaitPlace,
            Error
        }

        class Auto
        {
            private readonly ABBSocket _robot;

            public AutoStep Step { get; private set; }

            private bool _robotDone;
            private bool _visionDone;

            private double _x;
            private double _y;
            private double _angle;

            public Auto(ABBSocket robot)
            {
                _robot = robot;

                _robot.MessageReceived += Robot_MessageReceived;

                Step = AutoStep.Idle;
            }

            private void Robot_MessageReceived(string msg)
            {
                if (msg == "DONE")
                {
                    _robotDone = true;
                }
                else if (msg == "ERROR")
                {
                    Step = AutoStep.Error;
                }
            }

            public void Start()
            {
                Step = AutoStep.WaitVision;
            }

            public void Stop()
            {
                Step = AutoStep.Idle;
            }

            // Vision gọi hàm này khi tìm thấy bản mạch
            public void VisionResult(double x, double y, double angle)
            {
                _x = x;
                _y = y;
                _angle = angle;

                _visionDone = true;
            }

            public void Run()
            {
                switch (Step)
                {
                    case AutoStep.Idle:
                        break;

                    case AutoStep.WaitVision:

                        if (_visionDone)
                        {
                            _visionDone = false;
                            _robotDone = false;
                            _robot.Send($"PICK,{_x:F3},{_y:F3},{_angle:F3}");
                            Step = AutoStep.WaitPick;
                        }

                        break;

                    case AutoStep.WaitPick:
                        if (_robotDone)
                        {
                            _robotDone = false;
                            _robot.Send("PLACE");
                            Step = AutoStep.WaitPlace;
                        }
                        break;

                    case AutoStep.WaitPlace:
                        if (_robotDone)
                        {
                            _robotDone = false;
                            Step = AutoStep.WaitVision;
                        }

                        break;

                    case AutoStep.Error:
                        break;
                }
            }
        }
    }
}
