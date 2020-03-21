using System;
using System.Collections;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Presentation;
using Microsoft.SPOT.Presentation.Controls;
using Microsoft.SPOT.Presentation.Media;
using Microsoft.SPOT.Presentation.Shapes;
using Microsoft.SPOT.Touch;

using Gadgeteer.Networking;
using GT = Gadgeteer;
using GTM = Gadgeteer.Modules;
using Gadgeteer.Modules.GHIElectronics;
using Microsoft.SPOT.Hardware;

namespace LegoTechnicPlotter
{
    public partial class Program
    {
        Text text;

        void ProgramStarted()
        {
            CreateButton();
        }

        private void CreateButton()
        {
            var main = this.Display_T35.WPFWindow;
            var canvas = new Panel();
            canvas.HorizontalAlignment = HorizontalAlignment.Left;
            canvas.SetMargin(4);
            canvas.SetMargin(5, 5, 0, 0);

            Rectangle rec = new Rectangle(200, 100);
            rec.HorizontalAlignment = HorizontalAlignment.Left;
            rec.VerticalAlignment = VerticalAlignment.Top;
            rec.Fill = new SolidColorBrush(Colors.Green);
            canvas.Children.Add(rec);

            Font baseFont = Resources.GetFont(Resources.FontResources.NinaB);
            text = new Text(baseFont, "Hello World!");
            text.ForeColor = Colors.Black;
            text.HorizontalAlignment = HorizontalAlignment.Left;
            text.VerticalAlignment = VerticalAlignment.Top;
            text.SetMargin(10, 10, 0, 0);
            text.Height = 20;
            text.Visibility = Visibility.Collapsed;
            canvas.Children.Add(text);

            main.Child = canvas;

            main.TouchDown += new Microsoft.SPOT.Input.TouchEventHandler(main_TouchDown);
        }

        void main_TouchDown(object sender, Microsoft.SPOT.Input.TouchEventArgs e)
        {
            text.Visibility = Visibility.Visible;
        }
    }
}
