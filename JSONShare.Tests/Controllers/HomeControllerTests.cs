using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JSONShare.Models;
using JSONShare.Controllers;
using System.Web.Mvc;

namespace JSONShare.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTests
    {
        private JsonItem validJsonItem;
        private JsonItem invalidJsonItem;

        [TestInitialize]
        public void TestInit()
        {
            validJsonItem = new JsonItem() { Id = 1, Json = "{ name: 'john' }" };
            invalidJsonItem = new JsonItem();
        }

        [TestMethod]
        public void CreateIfJsonIsValid()
        {
            //Arrange
            //Act
            //Assert
        }

        [TestMethod]
        public void RedirectToEditIfJsonIsValid()
        {
            //Arrange
            //Act
            //Assert
        }

        [TestMethod]
        public void RedirectBackToCreateFormIfJsonIsInvalid()
        {            
            //var controller = new HomeController();
            //var result = controller.Create(invalidJsonItem) as ViewResult;
            
            //Assert.AreSame("Create", result.View.ToString());
        }

        [TestMethod]
        public void IdGetsCorrectlyDecodedFromBase64StringToInteger()
        {
            //Arrange
            //Act
            //Assert
        }
    }
}
