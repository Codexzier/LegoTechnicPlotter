using System;
using Microsoft.SPOT;
using Gadgeteer.Interfaces;
using System.Collections;

namespace LegoTechnicPlotter.Components.Plotter
{
    public class PlotterController
    {
        private static PlotterController _instance;

        private DispatcherTimer _timer = new DispatcherTimer();
        private Gadgeteer.Modules.GHIElectronics.Extender _extender;
        private DigitalOutput _outputP3;
        private DigitalOutput _outputP4;
        private DigitalOutput _outputP5;
        private DigitalOutput _outputP6;

        private int _countDown = 0;
        private MoveState _moveState;

        private bool _IsRunSequenz = false;
        private bool _isReturnToStart = false;
        private ArrayList _sequenz;
        private int _sequenzIndex;
        private bool _hasPointReached = false;
        private MovePointItem _targetPoint = null;

        private int _rangeXMax = 100;
        private int _rangeYMax = 100;

        private int _actualX = 0;
        private int _actualY = 0;

        public int ActualX { get { return this._actualX; } }
        public int ActualY { get { return this._actualY; } }

        public void ActualPositionReset()
        {
            this._actualX = 0;
            this._actualY = 0;
        }

        public void SetPositionMaxRange(int rangeMaxX, int rangeMaxY)
        {
            this._rangeXMax = rangeMaxX;
            this._rangeYMax = rangeMaxY;
        }

        private PlotterController(Gadgeteer.Modules.GHIElectronics.Extender extender)
        {
            this._extender = extender;

            this._outputP3 = this._extender.SetupDigitalOutput(Gadgeteer.Socket.Pin.Three, false);
            this._outputP4 = this._extender.SetupDigitalOutput(Gadgeteer.Socket.Pin.Four, false);
            this._outputP5 = this._extender.SetupDigitalOutput(Gadgeteer.Socket.Pin.Five, false);
            this._outputP6 = this._extender.SetupDigitalOutput(Gadgeteer.Socket.Pin.Seven, false);


            this._timer.Interval = TimeSpan.FromTicks(TimeSpan.TicksPerMillisecond * 100);
            this._timer.Tick += _timer_Tick;
        }

        public static PlotterController GetInstance(Gadgeteer.Modules.GHIElectronics.Extender extender, Gadgeteer.Modules.GHIElectronics.SDCard sdCard)
        {
            if (_instance == null)
            {
                ProgramSettings setting = ProgramSettings.GetInstance(sdCard);

                int rangeMaxX = setting.GetValue(SettingNames.RangeMaxX).GetValue().GetMin();
                int rangeMaxY = setting.GetValue(SettingNames.RangeMaxY).GetValue().GetMin();

                _instance = new PlotterController(extender);
                _instance.SetPositionMaxRange(rangeMaxX, rangeMaxY);
            }

            return _instance;
        }

        private void _timer_Tick(object sender, EventArgs e)
        {
            if (this._IsRunSequenz)
            {
                Debug.Print("IsRunSequenz");
                Debug.Print("Sequenz index: " + this._sequenzIndex.ToString() + "/" + this._sequenz.Count.ToString());

                if (this._targetPoint == null)
                {
                    Debug.Print("Target point: X:" + this._actualX.ToString() + ", Y" + this._actualY.ToString());
                }
                else
                {
                    Debug.Print("Target point: X:" + this._actualX.ToString() + "/" + this._targetPoint.X.ToString() + ", Y:" + this._actualY.ToString() + "/" + this._targetPoint.Y.ToString());
                };

                if (this._sequenzIndex >= this._sequenz.Count && !this._isReturnToStart)
                {
                    // return to start
                    if (this._actualX != 0 || this._actualY != 0)
                    {
                        this._targetPoint = new MovePointItem(0, 0);
                        this._isReturnToStart = true;
                        return;
                    }

                    this._timer.Stop();
                    this.Reset();

                    // TODO: Report message for finish
                    Debug.Print("Finish Sequenz");
                    return;
                }

                Debug.Print("HasPointReached: " + this._hasPointReached.ToString());
                if (this._hasPointReached)
                {
                    Debug.Print("--------------------");
                    this.Reset();

                    var item = this._sequenz[this._sequenzIndex] as MovePointItem;
                    if (item == null)
                    {
                        return;
                    }

                    // TIP: all directions rotate
                    this._targetPoint = item;
                    this._hasPointReached = false;
                    this._sequenzIndex++;
                    return;
                }

                this.Reset();

                if (this._actualX < this._targetPoint.X)
                {
                    Debug.Print("Move: Left");
                    this.SwitchOutput(MoveState.Left);
                    this._actualX++;
                }
                else if (this._actualX > this._targetPoint.X)
                {
                    Debug.Print("Move: Right");
                    this.SwitchOutput(MoveState.Right);
                    this._actualX--;
                }

                if (this._actualY < this._targetPoint.Y)
                {
                    Debug.Print("Move: Up");
                    this.SwitchOutput(MoveState.Up);
                    this._actualY++;
                }
                else if (this._actualY > this._targetPoint.Y)
                {
                    Debug.Print("Move: Down");
                    this.SwitchOutput(MoveState.Down);
                    this._actualY--;
                }

                this._hasPointReached = this._actualX == this._targetPoint.X &&
                    this._actualY == this._targetPoint.Y;

                if (this._isReturnToStart && this._hasPointReached)
                {
                    this._isReturnToStart = false;
                }

                return;
            }

            if (_countDown <= 0)
            {
                this._timer.Stop();
                this.Reset();
                return;
            }
            else
            {
                this._countDown -= 100;
            }

            this.SwitchOutput(this._moveState);
        }

        private void SwitchOutput(MoveState ms)
        {
            switch (ms)
            {
                case MoveState.Stand:
                    this.Reset();
                    break;
                case MoveState.Left:
                    this._outputP5.Write(true);
                    break;
                case MoveState.Right:
                    this._outputP3.Write(true);
                    break;
                case MoveState.Up:
                    this._outputP4.Write(true);
                    break;
                case MoveState.Down:
                    this._outputP6.Write(true);
                    break;
                default:
                    break;
            }
        }

        public delegate void MoveStoppedEventHandler();
        public event MoveStoppedEventHandler MoveStoppedEvent;

        internal void RunSequenz(ArrayList sequenz)
        {
            this._IsRunSequenz = true;
            this._sequenzIndex = 0;
            this._sequenz = sequenz;
            this._hasPointReached = true;
            this._timer.Start();
        }


        internal void Reset()
        {
            this._outputP3.Write(false);
            this._outputP4.Write(false);
            this._outputP5.Write(false);
            this._outputP6.Write(false);
        }

        internal void SetLeft()
        {
            this._IsRunSequenz = false;
            this._countDown = 1000;
            this._moveState = MoveState.Left;
            this._timer.Start();
        }

        internal void SetRight()
        {
            this._IsRunSequenz = false;
            this._countDown = 1000;
            this._moveState = MoveState.Right;
            this._timer.Start();
        }

        internal void SetUp()
        {
            this._IsRunSequenz = false;
            this._countDown = 1000;
            this._moveState = MoveState.Up;
            this._timer.Start();
        }

        internal void SetDown()
        {
            this._IsRunSequenz = false;
            this._countDown = 1000;
            this._moveState = MoveState.Down;
            this._timer.Start();
        }
    }


}
