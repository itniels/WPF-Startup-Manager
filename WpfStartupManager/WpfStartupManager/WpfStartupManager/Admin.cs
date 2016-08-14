// ================================================================================================
// Created by Niels Schmidt - it.niels@gmail.com
// Find this on GitHub: https://github.com/itniels/WPF-Startup-Manager
// For documentation please see: https://github.com/itniels/WPF-Startup-Manager
// For license please see: https://github.com/itniels/WPF-Startup-Manager/blob/master/License.md
// ================================================================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace NovaKittySoftware.Wpf.StartupManager
{
    public static class Admin
    {
        /// <summary>
        /// Check weather the user has administrator privileges or not.
        /// </summary>
        /// <returns></returns>
        public static bool IsUserAdministrator()
        {
            bool isAdministrator;
            try
            {
                WindowsIdentity identity = WindowsIdentity.GetCurrent();
                WindowsPrincipal principal = new WindowsPrincipal(identity);
                isAdministrator = principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
            catch (UnauthorizedAccessException)
            {
                isAdministrator = false;
            }
            catch (Exception)
            {
                isAdministrator = false;
            }
            return isAdministrator;
        }
    }
}