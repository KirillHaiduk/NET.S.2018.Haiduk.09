namespace NET.S._2018.Haiduk._09
{
    public class FilterFunction : IPredicate
    {
        private int filterInteger;

        public FilterFunction(int filter)
        {
            filterInteger = filter;
        }

        public bool Match(int digit)
        {
            if (filterInteger == digit)
            {
                return true;
            }

            return false;
        }
    }
}
