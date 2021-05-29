using System;
using Microsoft.SPOT;

namespace LegoTechnicPlotter.Views
{
    public enum AppView
    {
        Nothing,
        NotSet,
        Menu,
        Calibrate,
        CreatePhoto,
        LoadPhoto,
        PhotoResult,
        PreviewForPrint,
        Print,
        RunningPrint,
        Wait,
        WaitCameraShot,
        LoadPrintForm
    }
}
