using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NovaKittySoftware
{
    [TestClass]
    public class UnitTestsCurrentUser
    {
        private static readonly string appName = "unitTestExample";

        // Testing 'CurrentUser'
        [TestMethod]
        public void IsStartup()
        {
            WpfStartupManager.CurrentUser.RemoveApplicationFromStartup(appName);
            bool value = WpfStartupManager.CurrentUser.IsStartup(appName);
            Assert.AreEqual(false, value);
        }

        [TestMethod]
        public void Add()
        {
            bool value = WpfStartupManager.CurrentUser.AddApplicationToStartup(appName);
            WpfStartupManager.CurrentUser.RemoveApplicationFromStartup(appName);
            Assert.AreEqual(true, value);
        }

        [TestMethod]
        public void Remove()
        {
            bool value = WpfStartupManager.CurrentUser.RemoveApplicationFromStartup(appName);
            Assert.AreEqual(false, value);
        }
    }

    [TestClass]
    public class UnitTestsAllUsers
    {
        private static readonly string appName = "unitTestExample";

        // Testing 'CurrentUser'
        [TestMethod]
        public void IsStartup()
        {
            NovaKittySoftware
            bool value = WpfStartupManager.AllUsers.IsStartup(appName);
            Assert.AreEqual(false, value);
        }

        [TestMethod]
        public void Add()
        {
            bool value = WpfStartupManager.AllUsers.AddApplicationToStartup(appName);
            Assert.AreEqual(true, value);
        }

        [TestMethod]
        public void Remove()
        {
            bool value = WpfStartupManager.AllUsers.RemoveApplicationFromStartup(appName);
            Assert.AreEqual(false, value);
        }
    }

    [TestClass]
    public class UnitTestsAdmin
    {
        // Testing 'CurrentUser'
        [TestMethod]
        public void IsAdmin()
        {
            bool value = WpfStartupManager.Admin.IsUserAdministrator();
            Assert.AreEqual(true, value);
        }

        
    }
}
