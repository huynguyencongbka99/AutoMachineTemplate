using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotBox
{
    public enum AutoStep
    {
        Idle,

        MoveHome,
        WaitHomeDone,

        TriggerVision,
        WaitVisionResult,

        MovePick,
        WaitPickDone,

        VacuumOn,
        WaitVacuumOn,

        MovePlace,
        WaitPlaceDone,

        VacuumOff,
        WaitVacuumOff,

        CycleComplete,

        Error
    }

    public class Auto
    {
        private readonly ABBSocket _robot;
        private readonly VisionSystem _vision;

        private bool _robotDone;
        private bool _visionDone;
        private bool _visionOK;

        private VisionResult _visionResult;

        public AutoStep Step { get; private set; }

        public Auto(ABBSocket robot, VisionSystem vision)
        {
            _robot = robot;
            _vision = vision;

            Step = AutoStep.Idle;

            _robot.MessageReceived += Robot_MessageReceived;
            _vision.ResultReceived += Vision_ResultReceived;
        }

        private void Robot_MessageReceived(string msg)
        {
            switch (msg)
            {
                case "DONE":
                    _robotDone = true;
                    break;

                case "ERROR":
                    Step = AutoStep.Error;
                    break;
            }
        }

        private void Vision_ResultReceived(VisionResult result)
        {
            _visionDone = true;
            _visionResult = result;
            _visionOK = result.Success;
        }

        public void Start()
        {
            Step = AutoStep.MoveHome;
        }

        public void Stop()
        {
            Step = AutoStep.Idle;
        }

        public void Run()
        {
            switch (Step)
            {
                case AutoStep.Idle:
                    break;

                #region Home

                case AutoStep.MoveHome:

                    _robotDone = false;

                    _robot.Send("HOME");

                    Step = AutoStep.WaitHomeDone;

                    break;

                case AutoStep.WaitHomeDone:

                    if (_robotDone)
                    {
                        Step = AutoStep.TriggerVision;
                    }

                    break;

                #endregion

                #region Vision

                case AutoStep.TriggerVision:

                    _visionDone = false;

                    _vision.Trigger();

                    Step = AutoStep.WaitVisionResult;

                    break;

                case AutoStep.WaitVisionResult:

                    if (!_visionDone)
                        break;

                    if (!_visionOK)
                    {
                        Step = AutoStep.Error;
                        break;
                    }

                    Step = AutoStep.MovePick;

                    break;

                #endregion

                #region Pick

                case AutoStep.MovePick:

                    _robotDone = false;

                    _robot.Send(
                        $"PICK,{_visionResult.X:F3},{_visionResult.Y:F3},{_visionResult.Angle:F3}");

                    Step = AutoStep.WaitPickDone;

                    break;

                case AutoStep.WaitPickDone:

                    if (_robotDone)
                    {
                        Step = AutoStep.VacuumOn;
                    }

                    break;

                #endregion

                #region Vacuum ON

                case AutoStep.VacuumOn:

                    _robot.Send("VACUUM_ON");

                    Step = AutoStep.WaitVacuumOn;

                    break;

                case AutoStep.WaitVacuumOn:

                    Step = AutoStep.MovePlace;

                    break;

                #endregion

                #region Place

                case AutoStep.MovePlace:

                    _robotDone = false;

                    _robot.Send("PLACE");

                    Step = AutoStep.WaitPlaceDone;

                    break;

                case AutoStep.WaitPlaceDone:

                    if (_robotDone)
                    {
                        Step = AutoStep.VacuumOff;
                    }

                    break;

                #endregion

                #region Vacuum OFF

                case AutoStep.VacuumOff:

                    _robot.Send("VACUUM_OFF");

                    Step = AutoStep.WaitVacuumOff;

                    break;

                case AutoStep.WaitVacuumOff:

                    Step = AutoStep.CycleComplete;

                    break;

                #endregion

                case AutoStep.CycleComplete:

                    Step = AutoStep.TriggerVision;

                    break;

                case AutoStep.Error:

                    break;
            }
        }
    }
}
