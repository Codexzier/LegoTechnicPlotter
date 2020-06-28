using System;
using Microsoft.SPOT;
using Microsoft.SPOT.Presentation.Shapes;
using Microsoft.SPOT.Presentation.Controls;
using Microsoft.SPOT.Presentation;
using Microsoft.SPOT.Presentation.Media;
using LegoTechnicPlotter.Styles;
using System.Collections;
using LegoTechnicPlotter.Controls;

namespace LegoTechnicPlotter.Views.Base
{
    /// <summary>
    /// Base view. Draw a background with base color and has the reference of the panel.
    /// </summary>
    public abstract class BaseView : IDisposable
    {
        private readonly IApplicationContext _context;

        private SquareButton _buttonBack;
        private string _backButtonText;

        private SquareLabel _label;
        private string _title;

        private ArrayList _controls = new ArrayList();
        private readonly Panel _content = new Panel();
        private readonly bool _withoutBackButton;
        private AppView _isApplicationView = AppView.NotSet;
        private AppView _fromApplicationView = AppView.NotSet;

        public BaseView(IApplicationContext context, AppView isView, AppView fromView, string title, bool withoutBack = false, string backButtonText = "")
        {
            this._isApplicationView = isView;
            this._fromApplicationView = fromView;
            this._context = context;
            this._title = title;
            this._withoutBackButton = withoutBack;

            this.InitializeComponent();
        }

        public AppView ApplicationView { get { return this._isApplicationView; } }

        public Panel GetPanel() { return this._content; }

        protected IApplicationContext Context { get { return this._context; } }

        public virtual void InitializeComponent()
        {
            this.SetBackground();

            if (this._title != null || this._title != "")
            {
                this._label = new SquareLabel(this, this._title);
            }
            
            this._buttonBack = new SquareButton(this, SquareButtonPosition.Line_4, this.GetTextForBackButton());
            this._buttonBack.ButtonPressedEvent += _buttonBack_ButtonPressedEvent;
        }

        private string GetTextForBackButton()
        {
            if (this._backButtonText == "" ||  this._backButtonText == null)
            {
                return "Back";
            }

            return this._backButtonText;
        }

        private void _buttonBack_ButtonPressedEvent()
        {
            this.Context.Show(this._fromApplicationView, AppView.Nothing);
        }

        protected void SetBackground()
        {
            Rectangle rec = new Rectangle(320, 240);
            rec.HorizontalAlignment = HorizontalAlignment.Left;
            rec.VerticalAlignment = VerticalAlignment.Top;
            rec.Fill = new SolidColorBrush(SquareBlueColors.DarkBlue);

            this._content.Children.Add(rec);
            this._controls.Add(rec);
        }

        public void Add(UIElement element)
        {
            this._content.Children.Add(element);
            this._controls.Add(element);
        }

        public void Remove(UIElement element)
        {
            this._content.Children.Remove(element);
            this._controls.Remove(element);
        }

        public virtual void Show()
        {
            foreach (var item in this._controls)
            {
                if (this.IsSubElement(item))
                {
                    continue;
                }

                var element = item as UIElement;
                element.Visibility = Visibility.Visible;
            }
        }

        public virtual void Hide()
        {
            foreach (var item in this._controls)
            {
                if (this.IsSubElement(item))
                {
                    continue;
                }

                var element = item as UIElement;
                element.Visibility = Visibility.Collapsed;
            }
        }

        private bool IsSubElement(object item)
        {
            var control = item as IElementControl;

            if(control == null)
            {
                return false;
            }

            return control.IsSubElement;
        }

        public SquareButton Back { get { return this._buttonBack; } }

        public virtual void Dispose()
        {
        }
    }
}
