using Blueprinter.Core.Services;
using Blueprinter.Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Blueprinter
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var context = new JsonContext(Application.StartupPath);

            var appController = new ApplicationController(context);
            var view = new ViewMain();
            var presenter = new ViewMainPresenter(view, appController);
            presenter.Run();
        }
    }
}
