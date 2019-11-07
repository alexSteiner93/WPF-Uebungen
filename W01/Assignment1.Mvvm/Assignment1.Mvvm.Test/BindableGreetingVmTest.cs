using System;
using Assignment1.Mvvm.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment1.Mvvm.Test
{

    // Die Tests schlagen zu Beginn fehl ("rot"). Bitte den 
    // Code in den C# Klassen GreetingVm und BindableGreetingVm
    // so anpassen, dass die Tests "grün" werden.
    //
    // (und nicht etwa die Tests anpassen, das wäre "mogeln" ;-))

    [TestClass]
    public class BindableGreetingVmTest
    {
        [TestMethod]
        public void InitialGreetingIsCorrect()
        {
            // arrange
            var vm = new BindableGreetingVm();

            // act
            // (nothing to do, here)

            // assert
            Assert.AreEqual("Hello, world!", vm.Greeting);
        }

        [TestMethod]
        public void GreetingChangesIfNameIsChanged()
        {
            // arrange
            var vm = new BindableGreetingVm();

            // act
            vm.Name = "Jack";

            // assert
            Assert.AreEqual("Hello, Jack!", vm.Greeting);
        }
    }
}
