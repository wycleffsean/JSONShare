using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JSONShare.Models;
using System.ComponentModel.DataAnnotations;

namespace JSONShare.Tests.Models
{
    [TestClass]
    public class JsonItemTests
    {        
        [TestMethod]
        public void TitleIsOptional()
        {
            //Arrange
            var jsonItem = new JsonItem() { Id = 1, Json = "{ name: 'john' }", Title = String.Empty };            
            
            //Act
            var context = new ValidationContext(jsonItem, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(jsonItem, context, results);

            //Assert
            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void TitleHasMaxLength()
        {
            ////Arrange
            //var jsonItem = new JsonItem() { Id = 1, Json = "{ name: 'john' }", Title = "string".PadLeft(51, '*') };            

            ////Act
            //var context = new ValidationContext(jsonItem, serviceProvider: null, items: null);
            //var results = new List<ValidationResult>();
            //var isValid = Validator.TryValidateObject(jsonItem, context, results);

            ////Assert
            //Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void JsonIsRequired()
        {
            //Arrange
            var jsonItem = new JsonItem() { Id = 1, Json = string.Empty };            

            //Act
            var context = new ValidationContext(jsonItem, serviceProvider: null, items: null);
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(jsonItem, context, results);

            //Assert
            Assert.IsFalse(isValid);
        }
    }
}
