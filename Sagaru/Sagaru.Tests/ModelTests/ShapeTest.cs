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
        public void GetDescriptionTest()
        {
            //Arrange
            var shape = new Shape();
            shape.X = 100;

            //Act
            var result = shape.X;

            //Assert
            Assert.Equal(100, result);
        }
    }
}
