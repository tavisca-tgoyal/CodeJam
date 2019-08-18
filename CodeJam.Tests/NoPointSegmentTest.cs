using Codejam;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CodeJam.Tests
{
    public class NoPointSegmentTest
    {
        [Fact]
        public void ModifyingTheArray()
        {
            temp obj = new temp();
            int[] seg1 = { 10, 0, -10, 0};
            int[] seg2 = { 5, 0, -5, 0 };

            string output = obj.Intersection(seg1, seg2);

            Assert.Equal("-1010 -55", output);

        }
    }
}
