using System;

namespace NET.S._2018.Haiduk._09
{
    public class FilterFunction : IPredicate
    {
        private int filterInteger;

        public FilterFunction(int filter)
        {
            FilterInteger = filter;
        }

        public int FilterInteger
        {
            get => filterInteger; set
            {
                if (value < 0 || value > 9)
                {
                    throw new ArgumentOutOfRangeException(nameof(filterInteger));
                }

                filterInteger = value;
            }
        }

        public bool Match(int item)
        {
            int temp = item;
            for (int i = 0; i < item.ToString().Length; i++)
            {
                var divisionResult = temp / 10;
                int remainder = temp % 10;
                temp = divisionResult;
                if (Math.Abs(remainder) == FilterInteger)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
