using Codejam;
using System;
using Xunit;

namespace CodeJam.Tests
{
    public class TriFibonacciTest
    {
        [Fact]
        public void IndexToBeFixedIsZero()
        {
            TriFibonacci obj = new TriFibonacci();
            int[] arr = { -1, 7, 7, 17, 32, 57, 107, 196, 360, 663, 1219, 2242, 4124, 7585, 13951, 25660, 47196, 86807 };
           int value =  obj.Complete(arr);

            Assert.Equal(3, value);


        }
    }
}
