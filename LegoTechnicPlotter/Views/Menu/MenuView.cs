

using LegoTechnicPlotter.Controls;
using LegoTechnicPlotter.Views.Base;
using Microsoft.SPOT.Presentation.Controls;

namespace LegoTechnicPlotter.Views.Menu
{
    /// <summary>
    /// Start menu of the program.
    /// </summary>
    public class MenuView : BaseView
    {
        private SquareButton _buttonCreatePhoto;
        private SquareButton _buttonLoadPhoto;
        private SquareButton _buttonPreviewPhoto;
        private SquareButton _buttonPrint;
        private InfoBar _infobar;

        public MenuView(Panel content)
            : base(content)
        {
            this.InitializeComponent();
        }

        public override void InitializeComponent()
        {
            base.InitializeComponent();

            this._buttonCreatePhoto = new SquareButton(this._content, 20, 30, "Create photo");
            this._buttonLoadPhoto = new SquareButton(this._content, 20, 80, "Load photo");
            this._buttonPreviewPhoto = new SquareButton(this._content, 20, 130, "Preview photo");
            this._buttonPrint = new SquareButton(this._content, 20, 180, "Print");

            this._infobar = new InfoBar(this._content);
        }




        //private void GetText(Panel canvas)
        //{
        //    Font baseFont = Resources.GetFont(Resources.FontResources.NinaB);
        //    Text text = new Text(baseFont, "Hello World!");
        //    text.ForeColor = Colors.Black;
        //    text.HorizontalAlignment = HorizontalAlignment.Left;
        //    text.VerticalAlignment = VerticalAlignment.Top;
        //    text.SetMargin(10, 10, 0, 0);
        //    text.Height = 20;
        //    text.Visibility = Visibility.Visible;
        //    canvas.Children.Add(text);
        //}

        //private Text CreateText(string textContent)
        //{
        //    Font baseFont = Resources.GetFont(Resources.FontResources.NinaB);
        //    var text = new Text(baseFont, textContent);
        //    text.ForeColor = Colors.Black;
        //    text.HorizontalAlignment = HorizontalAlignment.Left;
        //    text.VerticalAlignment = VerticalAlignment.Top;
        //    text.SetMargin(10, 10, 0, 0);
        //    text.Height = 20;

        //    return text;
        //}
    }
}
