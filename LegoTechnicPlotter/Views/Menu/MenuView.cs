

using LegoTechnicPlotter.Controls;
using LegoTechnicPlotter.Views.Base;
using Microsoft.SPOT.Presentation.Controls;

namespace LegoTechnicPlotter.Views.Menu
{
    /// <summary>
    /// Start menu of the program.
    /// Show Button option:
    /// - Create photo  => create a photo and show the result on new view.
    ///                    Open the photo result view. If the pictured finshed captured
    /// - Load photo    => show a list of pictures.
    ///                    Open the list view with a list of saved pitured from the sd card
    /// - Preview print => convert the picture to the print picture and show a preview.
    ///                    Open the preview view and show the convert result.
    /// - Print         => if not create by preview, it convert the picture and control the plotter.
    ///                    Open the status view with update every steps of the plotter process.
    /// </summary>
    public class MenuView : BaseView
    {
        private SquareButton _buttonCreatePhoto;
        private SquareButton _buttonLoadPhoto;
        private SquareButton _buttonPreviewPrint;
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

            this._buttonCreatePhoto = new SquareButton(this, SquareButtonPosition.Line_1, "Create photo");
            this._buttonLoadPhoto = new SquareButton(this, SquareButtonPosition.Line_2, "Load photo");
            this._buttonPreviewPrint = new SquareButton(this, SquareButtonPosition.Line_3, "Preview print");
            this._buttonPrint = new SquareButton(this, SquareButtonPosition.Line_4, "Print");

            this._infobar = new InfoBar(this);
        }

        public SquareButton CreatePhoto { get { return this._buttonCreatePhoto; } }

        public SquareButton LoadPhoto { get { return this._buttonLoadPhoto; } }

        public SquareButton PreviewPrint { get { return this._buttonPreviewPrint; } }

        public SquareButton Print { get { return this._buttonPrint; } }


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
