using ReseauSocial.Wpf.Models;

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Tools.Patterns.Mediator;

namespace ReseauSocial.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private ResourceLocator ResourceLocator
        {
            get { return (ResourceLocator)Resources["Locator"]; }
        }


        public App()
        {
            Messenger<WindowTypes>.Default.OnMessage += OnWindowsMessage;
        }

        private void OnWindowsMessage(WindowTypes message)
        {
            switch (message)
            {
                case WindowTypes.Login:
                   /* LoginWindow login = new LoginWindow();
                    login.Show();
                    Application.Current.MainWindow.Close();*/
                    break;

                case WindowTypes.Main:
                    MainWindow main = new MainWindow();
                    main.Show();                
                    Application.Current.MainWindow.Close();
                    break;

                default:
                    break;
            }
        }
    }
}
