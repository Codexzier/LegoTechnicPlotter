using System;
using Microsoft.SPOT;
using LegoTechnicPlotter.Views.Base;
using Microsoft.SPOT.Presentation.Controls;
using LegoTechnicPlotter.Components;
using LegoTechnicPlotter.Components.Plotter;
using LegoTechnicPlotter.Controls;
using System.Collections;

namespace LegoTechnicPlotter.Views.Print
{
    public class CalibrateView : BaseView
    {
        private PlotterController _plotterController;
        private ProgramSettings _settings;
        private IconButton _buttonLeft;
        private IconButton _buttonRight;
        private IconButton _buttonUp;
        private IconButton _buttonDown;

        private IconButton _buttonFixStart;
        private IconButton _buttonFixEnd;

        public CalibrateView(Panel content, PlotterController controller, ProgramSettings settings)
            : base(content)
        {
            this._plotterController = controller;
            this._settings = settings;

            this._buttonLeft = new IconButton(this, 30, 80, "<");
            this._buttonLeft.ButtonPressedEvent += this._buttonLeft_ButtonPressedEvent;
            this._buttonRight = new IconButton(this, 130, 80, ">");
            this._buttonRight.ButtonPressedEvent += this._buttonRight_ButtonPressedEvent;

            this._buttonUp = new IconButton(this, 80, 30, "^");
            this._buttonUp.ButtonPressedEvent += this._buttonUp_ButtonPressedEvent;
            this._buttonDown = new IconButton(this, 80, 130, "v");
            this._buttonDown.ButtonPressedEvent += this._buttonDown_ButtonPressedEvent;

            this._buttonFixStart = new IconButton(this, 180, 80, "S");
            this._buttonFixStart.ButtonPressedEvent += this._buttonFixStart_ButtonPressedEvent;

            this._buttonFixEnd = new IconButton(this, 180, 130, "E");
            this._buttonFixEnd.ButtonPressedEvent += this._buttonFixEnd_ButtonPressedEvent;
        }

        private void _buttonFixStart_ButtonPressedEvent()
        {
            this._plotterController.ActualPositionReset();
        }

        public void _buttonFixEnd_ButtonPressedEvent()
        {
            var rangeMaxX = this._plotterController.ActualX.ToString();
            var rangeMaxY = this._plotterController.ActualY.ToString();

            this._settings.Save(SettingNames.RangeMaxX, rangeMaxX);
            this._settings.Save(SettingNames.RangeMaxY, rangeMaxY);
        }


        private void _buttonLeft_ButtonPressedEvent()
        {
            this._plotterController.SetLeft();
        }

        private void _buttonRight_ButtonPressedEvent()
        {
            this._plotterController.SetRight();
        }

        private void _buttonUp_ButtonPressedEvent()
        {
            this._plotterController.SetUp();
        }

        private void _buttonDown_ButtonPressedEvent()
        {
            this._plotterController.SetDown();
        }
    }
}
