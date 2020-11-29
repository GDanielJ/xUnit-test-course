using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace Calculations.Test
{
    public class CalculatorFixture
    {
        public Calculator Calc => new Calculator();
    }

    public class CalculatorTests : IClassFixture<CalculatorFixture>
    {
        private readonly CalculatorFixture _calculatorFixture;
        private readonly ITestOutputHelper _testOutputHelper;

        public CalculatorTests(CalculatorFixture CalculatorFixture, ITestOutputHelper TestOutputHelper)
        {
            _calculatorFixture = CalculatorFixture;
            _testOutputHelper = TestOutputHelper;

            _testOutputHelper.WriteLine("Constructor");
        }

        [Fact]
        public void Add_GivenTwoIntValues_ReturnsInt()
        {
            var calc = new Calculator();
            var result = calc.Add(1, 2);
            Assert.Equal(3, result);
        }

        [Fact]
        public void AddDouble_GivenTwoDoubleValues_ReturnsDouble()
        {
            var calc = _calculatorFixture.Calc;
            var result = calc.AddDouble(1.2, 3.5);
            Assert.Equal(4.7, result);
        }

        [Fact]
        public void FiboDoesNotIncludeZero()
        {
            _testOutputHelper.WriteLine("FiboDoesNotIncludeZero");

            var calc = _calculatorFixture.Calc;

            Assert.All(calc.FiboNumbers, n => Assert.NotEqual(0, n));
        }

        [Fact]
        public void FiboIncludesThirteen()
        {
            _testOutputHelper.WriteLine("FiboIncludesThirteen");

            var calc = _calculatorFixture.Calc;

            Assert.Contains(13, calc.FiboNumbers);
        }

        [Fact]
        public void FiboDoesNotContainFour()
        {
            var calc = _calculatorFixture.Calc;

            Assert.DoesNotContain(4, calc.FiboNumbers);
        }

        [Fact]
        public void CheckCollection()
        {
            _testOutputHelper.WriteLine("CheckCollection. Test starting at {0} ", DateTime.Now);

            var expectedCollection = new List<int>() { 1, 1, 2, 3, 5, 8, 13 };

            var calc = _calculatorFixture.Calc;

            Assert.Equal(expectedCollection, calc.FiboNumbers);
        }

        [Fact]
        public void IsOdd_GivenOddValue_RetrunsTrue()
        {
            var calc = _calculatorFixture.Calc;
            var result = calc.IsOdd(1);
            Assert.True(result);
        }

        [Fact]
        public void IsOdd_GivenEvenValue_RetrunsFalse()
        {
            var calc = _calculatorFixture.Calc;
            var result = calc.IsOdd(2);
            Assert.False(result);
        }

        [Theory]
        [MemberData(nameof(TestDataShare.IsOddOrEvenData), MemberType = typeof(TestDataShare))]
        public void IsOdd_TestOddAndEven(int value, bool expected)
        {
            var calc = _calculatorFixture.Calc;
            var result = calc.IsOdd(value);
            Assert.Equal(expected, result);
        }

        [Theory]
        [MemberData(nameof(TestDataShare.IsOddOrEvenExternalData), MemberType = typeof(TestDataShare))]
        public void IsOdd_TestOddAndEvenWithExternalData(int value, bool expected)
        {
            var calc = _calculatorFixture.Calc;
            var result = calc.IsOdd(value);
            Assert.Equal(expected, result);
        }

        [Theory]
        [IsOddOrEvenData] // Detta är renare än metoden ovan om man har många test
        public void IsOdd_TestOddAndEvenUsingOwnAttribute(int value, bool expected)
        {
            var calc = _calculatorFixture.Calc;
            var result = calc.IsOdd(value);
            Assert.Equal(expected, result);
        }
    }
}
