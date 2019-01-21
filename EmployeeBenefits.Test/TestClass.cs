using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Unit.Test
{
    public class TestClass
    {
        [Theory]
        [InlineData(2, 3)]
        [InlineData(1, 4)]
        [InlineData(0, 5)]
        public void Somma(int x, int y)
        {
            var somma = x + y;
            
            //Assert
            Assert.Equal(5, somma);
        }
    }
}
