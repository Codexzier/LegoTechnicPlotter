using System;
using Microsoft.SPOT;
using LegoTechnicPlotter.Views.Base;
using Microsoft.SPOT.Presentation.Controls;

namespace LegoTechnicPlotter.Views.PreviewPrint
{
    public class PreviewPrintView : BaseView
    {
        public PreviewPrintView(IApplicationContext context, AppView fromApplicationView)
            : base(context, AppView.PreviewForPrint, fromApplicationView, "Preview for print")
        {

        }
    }
}
