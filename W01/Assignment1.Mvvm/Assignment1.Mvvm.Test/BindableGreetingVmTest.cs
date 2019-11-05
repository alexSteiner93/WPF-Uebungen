﻿using System;
using Assignment1.Mvvm.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment1.Mvvm.Test
{
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