namespace Sample01
{
    using System;

    public interface INumberChecker
    {
        bool CheckNumber(int number);
    }

    public class PrimeChecker:INumberChecker
    {
        public bool CheckNumber(int number)
        {
            if (number == 1) return false;
            if (number == 2) return true;

            var boundary = (int)Math.Floor(Math.Sqrt(number));

            for (int i = 2; i <= boundary; ++i)
            {
                if (number % i == 0) return false;
            }

            return true;
        }
    }
}