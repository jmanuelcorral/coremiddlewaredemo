namespace Sample01.Tests
{
    using FluentAssertions;
    using Xunit;

    public class UnitTests
    {
        private readonly INumberChecker _calculator;
        public UnitTests()
        {
            _calculator = new PrimeChecker();
        }

        [Theory]
        [InlineData(1,false)]
        [InlineData(2, true)]
        [InlineData(3, true)]
        [InlineData(4, false)]
        [InlineData(5, true)]
        [InlineData(6, false)]
        [InlineData(7, true)]
        [InlineData(11, true)]
        [InlineData(13, true)]
        [InlineData(19, true)]
        [InlineData(991, true)]
        public void Prime(int number,bool expectedResult)
        {
            _calculator.CheckNumber(number).Should().Be(expectedResult);
        }
    }
}