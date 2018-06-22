using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EugenePopov.Services
{
    public interface ICounter
    {
        int Value { get; }
    }

    public class RandomCounter: ICounter
    {
        int value;

        static Random rnd = new Random();

        public RandomCounter()
        {
            value = rnd.Next(0, 1000000);
        }

        #region ICounter members

            public int Value { get { return value; } }

        #endregion
    }

    public class CounterService
    {
        public ICounter Counter { get; }

        public CounterService(ICounter counter)
        {
            Counter = counter;
        }
    }
}
