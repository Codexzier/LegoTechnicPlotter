using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Presentation.Controls;
using Microsoft.SPOT.Presentation.Media;
using LegoTechnicPlotter.Views.Base;

namespace LegoTechnicPlotter.Controls
{
    public abstract class BaseButton : Canvas, IElementControl
    {
        protected bool _isEffect = false;
        private readonly DispatcherTimer _timer = new DispatcherTimer();

        protected Pen _pen = new Pen(ColorUtility.ColorFromRGB(120, 136, 150), 1);

        protected BaseButton(int left, int top)
        {
            this._timer.Interval = TimeSpan.FromTicks(TimeSpan.TicksPerMillisecond * 500);
            this._timer.Tick += this._timer_Tick;

            this.HorizontalAlignment = Microsoft.SPOT.Presentation.HorizontalAlignment.Left;
            this.VerticalAlignment = Microsoft.SPOT.Presentation.VerticalAlignment.Top;
            this.SetMargin(left, top, 0, 0);
        }

        protected virtual void SetupTouch()
        {
            this.TouchUp += SquareButton_TouchUp;
        }

        private void SquareButton_TouchUp(object sender, Microsoft.SPOT.Input.TouchEventArgs e)
        {
            Debug.Print("Button pressed");
            this.SetPressEffect();
       
        }

        protected virtual void SetPressEffect()
        {
            Debug.Print("Timer start for effect");
            this._timer.Start();
        }

        /// <summary>
        /// Hide the effect.
        /// </summary>
        private void _timer_Tick(object sender, EventArgs e)
        {
            this._timer.Stop();
            this.SetPressEffectEnd();
        }

        protected virtual void SetPressEffectEnd()
        {
            Debug.Print("SetPressEffectEnd");
            this.ButtonPressed();
        }

        public bool IsSubElement { get { return this._isEffect; } }

        protected void ButtonPressed()
        {
            if (this.ButtonPressedEvent != null)
            {
                this.ButtonPressedEvent.Invoke();
            }
        }
        public delegate void ButtonPressedEventHandler();
        public event ButtonPressedEventHandler ButtonPressedEvent;

        public abstract void MoveElementToLastLevel(BaseView view);

        /// <summary>
        /// Change the element order.
        /// </summary>
        /// <param name="view"></param>
        protected void MoveElementToLastLevel(BaseView view, BaseButton pressEffect)
        {
            view.Remove(this);
            view.Remove(pressEffect);

            view.Add(this);
            view.Add(pressEffect);
        }
    }
}
