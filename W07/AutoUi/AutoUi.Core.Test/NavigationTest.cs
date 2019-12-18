using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoUi.Core.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AutoUi.Core.Test
{
    [TestClass]
    public class NavigationTest
    {
        [TestMethod]
        public void TopWindowIsCorrectlySet()
        {
            // 1. Arrange
            var navService = new TestMockNavigationService();
            var vm = new AutoListVm();

            // 2. Act
            navService.Show<AutoListVm>(vm);
            var windowOnTopAfter = navService.ViewStack.Last();

            // 3. Assert
            Assert.AreEqual("AutoListVm", windowOnTopAfter);
        }
    }
}
