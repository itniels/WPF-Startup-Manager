// ================================================================================================
// Created by Niels Schmidt - it.niels@gmail.com
// Find this on GitHub: https://github.com/itniels/WPF-Startup-Manager
// For documentation please see: https://github.com/itniels/WPF-Startup-Manager
// For license please see: https://github.com/itniels/WPF-Startup-Manager/blob/master/License.md
// ================================================================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace NovaKittySoftware.Wpf.StartupManager
{
    /// <summary>
    /// Adds or removed the application from windows startup for the all users.
    /// This REQUIRES administrator privileges.
    /// </summary>
    public static class AllUsers
    {

        /// <summary>
        /// Adds a registry key to startup the program with 'applicationName' as the display name. Then returns boolean value if application exists in registry.
        /// </summary>
        /// <param name="applicationName">The exact name of the application to be added to the registry</param>
        /// <returns></returns>
        public static bool AddApplicationToStartup(string applicationName)
        {
            if (Admin.IsUserAdministrator())
            {
                if (!IsStartup(applicationName))
                {
                    using (
                        RegistryKey key =
                            Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
                    {
                        string path = System.Reflection.Assembly.GetCallingAssembly().Location;
                        key.SetValue(applicationName, path);
                    }
                }
            }
            return IsStartup(applicationName);
        }

        

        /// <summary>
        /// Removes the application with 'applicationName' from the registry. Then returns boolean value if application exists in registry.
        /// </summary>
        /// <param name="applicationName">The exact name of the application to be removed from the registry</param>
        /// <returns></returns>
        public static bool RemoveApplicationFromStartup(string applicationName)
        {
            if (Admin.IsUserAdministrator())
            {
                if (IsStartup(applicationName))
                {
                    using (
                        RegistryKey key =
                            Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true))
                    {
                        key.DeleteValue(applicationName, false);
                    }
                }
            }
            return IsStartup(applicationName);
        }

        /// <summary>
        /// Checks if the application is set as startup. The return value indicates if it is present in the registry for startup.
        /// </summary>
        /// <param name="applicationName">The exact name of the application as added to the registry</param>
        /// <returns></returns>
        public static bool IsStartup(string applicationName)
        {
            using (RegistryKey key = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", false))
            {
                var found = key?.GetValue(applicationName);
                return found != null;
            }
        }
    }
}
