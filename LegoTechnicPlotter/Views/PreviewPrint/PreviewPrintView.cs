using System;
using Microsoft.SPOT;
using LegoTechnicPlotter.Views.Base;
using Microsoft.SPOT.Presentation.Controls;
using LegoTechnicPlotter.Components.ImageToGraph;
using LegoTechnicPlotter.Views.CreatePhoto;
using LegoTechnicPlotter.Controls;
using LegoTechnicPlotter.Views.Wait;

namespace LegoTechnicPlotter.Views.PreviewPrint
{
    public class PreviewPrintView : BaseView
    {
        private ImageToGraphState _state = new ImageToGraphState();

        public PreviewPrintView(IApplicationContext context, AppView fromApplicationView)
            : base(context, AppView.PreviewForPrint, fromApplicationView, "Preview for print")
        {

        }

        public override void InitializeComponent()
        {
            base.InitializeComponent();


            var converter = new ImageToGraphConverter();
            //var sequenz = converter.Convert(WaitPhotoShotView.ActualPicture.MakeBitmap(), 5, 5, this._state);

            // TODO: Sequenz in der Vorschau aufbauen
            PathPlotterBuilder pathPlotterBuilder = new PathPlotterBuilder();

            var dict = new DictionaryDrawPoints();
            var result = pathPlotterBuilder.CreatePathLine(dict);

            this.Add(result);
        }
    }
}
