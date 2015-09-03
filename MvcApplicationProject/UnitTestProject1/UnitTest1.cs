using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcApplication2.Controllers;
using MvcApplication2.Models;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Report()
        {
            var controller = new HomeController();
            var result = controller.Report() as ViewResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Create()
        {
            var controller = new HomeController();
            var result = controller.Create() as ViewResult;
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void Edit()
        {
            var controller = new HomeController();
       
            var result = controller.Edit(2) as ViewResult;
            Assert.IsNotNull(result.Model);
        }
    }
}
