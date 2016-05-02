using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sagaru.Models;
using Xunit;


namespace Sagaru.Tests
{
    public class ProjectTest
    {
        [Fact]
        public void GetDescriptionTest()
        {
            //Arrange
            var project = new Project();
            project.Description = "Wash the dog";

            //Act
            var result = project.Description;

            //Assert
            Assert.Equal("Wash the dog", result);
        }
    }
}
