using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DemoApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly string appName = "SampleAppDemo";
        public MainWindow()
        {
            InitializeComponent();
        }

        // Current User
        private void btn_check_Click(object sender, RoutedEventArgs e)
        {
            if (NovaKittySoftware.Wpf.StartupManager.CurrentUser.IsStartup(appName))
            {
                lbl_info.Content = "FOUND!";
            }
            else
            {
                lbl_info.Content = "NOT FOUND!";
            }
        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            if (!NovaKittySoftware.Wpf.StartupManager.CurrentUser.IsStartup(appName))
            {
                if (NovaKittySoftware.Wpf.StartupManager.CurrentUser.AddApplicationToStartup(appName))
                {
                    lbl_info.Content = "Added OK!";
                }
                else
                {
                    lbl_info.Content = "Not added..";
                }
            }
            else
            {
                lbl_info.Content = "Already exists!";
            }
        }

        private void btn_remove_Click(object sender, RoutedEventArgs e)
        {
            if (NovaKittySoftware.Wpf.StartupManager.CurrentUser.IsStartup(appName))
            {
                if (!NovaKittySoftware.Wpf.StartupManager.CurrentUser.RemoveApplicationFromStartup(appName))
                {
                    lbl_info.Content = "Removed OK!";
                }
                else
                {
                    lbl_info.Content = "Not removed!";
                }
            }
            else
            {
                lbl_info.Content = "Was never added!";
            }
        }

        // All Users
        private void btn_check_Admin_Click(object sender, RoutedEventArgs e)
        {
            if (NovaKittySoftware.Wpf.StartupManager.AllUsers.IsStartup(appName))
            {
                lbl_info.Content = "FOUND!";
            }
            else
            {
                lbl_info.Content = "NOT FOUND!";
            }
        }

        private void btn_add_Admin_Click(object sender, RoutedEventArgs e)
        {
            if (!NovaKittySoftware.Wpf.StartupManager.AllUsers.IsStartup(appName))
            {
                if (NovaKittySoftware.Wpf.StartupManager.AllUsers.AddApplicationToStartup(appName))
                {
                    lbl_info.Content = "Added OK!";
                }
                else
                {
                    lbl_info.Content = "Not added..";
                }
            }
            else
            {
                lbl_info.Content = "Already exist!";
            }
        }

        private void btn_remove_Admin_Click(object sender, RoutedEventArgs e)
        {
            if (NovaKittySoftware.Wpf.StartupManager.AllUsers.IsStartup(appName))
            {
                if (!NovaKittySoftware.Wpf.StartupManager.AllUsers.RemoveApplicationFromStartup(appName))
                {
                    lbl_info.Content = "Removed OK!";
                }
                else
                {
                    lbl_info.Content = "Not removed!";
                }
            }
            else
            {
                lbl_info.Content = "Was never added!";
            }
        }

        // Is Admin
        private void button_isAdmin_Click(object sender, RoutedEventArgs e)
        {
            if (NovaKittySoftware.Wpf.StartupManager.Admin.IsUserAdministrator())
            {
                lbl_info.Content = "Yes you are :-)";
            }
            else
            {
                lbl_info.Content = "Nope :-(";
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Cleanup after usage!
            NovaKittySoftware.Wpf.StartupManager.CurrentUser.RemoveApplicationFromStartup(appName);
            NovaKittySoftware.Wpf.StartupManager.AllUsers.RemoveApplicationFromStartup(appName);
        }
    }
}
