using ReaderCommon.ViewInterfaces;
using ReaderPresenters.Framework;
using System;
using System.Windows.Forms;

namespace InjectionManager
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Initializer init = new Initializer();
            init.Init();
            var _loginView = IOC.Container.GetInstance<ILoginView>();
            Application.EnableVisualStyles();
            Application.Run((Form)_loginView);
        }
    }
}
