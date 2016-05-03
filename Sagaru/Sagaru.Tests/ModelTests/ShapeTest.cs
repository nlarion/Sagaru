using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Sagaru.Models;
using Xunit;

namespace Sagaru.Tests.ModelTests
{
    public class ShapeTest
    {
        [Fact]
        public void GetXTest()
        {
            //Arrange
            var shape = new Shape();
            shape.X = 100;

            //Act
            var result = shape.X;

            //Assert
            Assert.Equal(100, result);
        }
        [Fact]
        public void GetYTest()
        {
            //Arrange
            var shape = new Shape();
            shape.Y = 200;

            //Act
            var result = shape.Y;

            //Assert
            Assert.Equal(200, result);
        }
        public void GetTypeTest()
        {
            //Arrange
            var shape = new Shape();
            shape.Type = "Square";

            //Act
            var result = shape.Type;

            //Assert
            Assert.Equal("Square", result);
        }
    }
}
