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
        private ArrayList _sequenz;

        private PlotterController(Gadgeteer.Modules.GHIElectronics.Extender extender)
        {
            this._extender = extender;

            this._outputP3 = this._extender.SetupDigitalOutput(Gadgeteer.Socket.Pin.Three, false);
            this._outputP4 = this._extender.SetupDigitalOutput(Gadgeteer.Socket.Pin.Four, false);
            this._outputP5 = this._extender.SetupDigitalOutput(Gadgeteer.Socket.Pin.Five, false);
            this._outputP6 = this._extender.SetupDigitalOutput(Gadgeteer.Socket.Pin.Six, false);


            this._timer.Interval = TimeSpan.FromTicks(TimeSpan.TicksPerMillisecond * 100);
            this._timer.Tick += _timer_Tick;
        }

        public static PlotterController GetInstance(Gadgeteer.Modules.GHIElectronics.Extender extender)
        {
            if(_instance == null)
            {
                _instance = new PlotterController(extender);
            }

            return _instance;
        }

        private void _timer_Tick(object sender, EventArgs e)
        {
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

            switch (this._moveState)
            {
                case MoveState.Stand:
                    this.Reset();
                    break;
                case MoveState.Left:
                    this._outputP4.Write(true);
                    break;
                case MoveState.Right:
                    this._outputP3.Write(true);
                    break;
                case MoveState.Up:
                    this._outputP5.Write(true);
                    break;
                case MoveState.Down:
                    this._outputP6.Write(true);
                    break;
                default:
                    break;
            }
        }

        public delegate void MoveStoppedEventHandler() ;
        public event MoveStoppedEventHandler MoveStoppedEvent;

        internal void RunSequenz(ArrayList sequenz)
        {
            this._sequenz = sequenz;
            this._timer.Start();
        }

        //private void Move(int milliSeconds, MoveState move)
        //{
        //    this._countDown = milliSeconds;
        //    this._moveState = move;
        //}

        internal void Reset()
        {
            this._outputP3.Write(false);
            this._outputP4.Write(false);
            this._outputP5.Write(false); 
            this._outputP6.Write(false);
        }
    }


}
