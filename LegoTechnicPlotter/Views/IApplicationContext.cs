using System;
using System.Text;

namespace LegoTechnicPlotter.Views
{
    public interface IApplicationContext
    {
        void Show(AppView view, AppView from);
    }
}
