using System;
using System.Collections.Generic;
using System.Linq;

namespace Mandatory_Assignment.Randomizers
{

    /// <summary>Class RandomizedFactory.
    /// Implements the <see cref="T:Mandatory_Assignment.IFactory`1" /></summary>
    /// <typeparam name="T"> En valgfri klasse</typeparam>
    public class RandomizedFactory<T> : IFactory<T>
    {
        #region Instance
        private Random random;
        private List<Tuple<int, Func<T>>> _factory;
        #endregion
        #region Constructor
        /// <summary>Initializes a new instance of the <see cref="T:Mandatory_Assignment.Randomizers.RandomizedFactory`1" /> class.</summary>
        public RandomizedFactory()
        {
            random = new Random();
            _factory = new List<Tuple<int, Func<T>>>();
        }
        #endregion
        #region Methods

        /// <summary>Adds the factory.</summary>
        /// <param name="prob">Is the probability. The probability indicate how many factories should be created.</param>
        /// <param name="fac">The object that will be put in the factory.</param>
        public void AddFactory(int prob, Func<T> fac)
        {
            for (int i = 0; i < prob; i++)
            {
                _factory.Add(new Tuple<int, Func<T>>(prob, fac));

            }
        }

        /// <summary>Consistencies the check.</summary>
        /// <returns>
        ///   <c>true</c> if it can return a _factory and if the count of _factory is 100, <c>false</c> otherwise.</returns>
        private bool ConsistencyCheck()
        {
            return (_factory.Select(e => e.Item1).Count() == 100);
        }

        /// <summary>Gets the Object.</summary>
        /// <returns>It return the factories Item2, which is the object part of Turple.</returns>
        /// <exception cref="ArgumentException">Inconsistent factory percentages</exception>
        public T GetQuality()
        {
            if (ConsistencyCheck())
            {
                int index = PercentageToIndex(RandomUtil.Percentage());
                index = random.Next(1, 100);
                return _factory[index].Item2();
            }
            else throw new ArgumentException("Inconsistent factory percentages");
        }

        /// <summary>Percentages to index.</summary>
        /// <param name="percentage">Is the percentage you want.</param>
        /// <returns>return the index, which is a int.</returns>
        private int PercentageToIndex(int percentage)
        {
            int accPercentage = 0;
            int index = 0;

            while(accPercentage< percentage && index < _factory.Count)
            {
                accPercentage += _factory[index].Item1;
                index++;
            }
            return index;
        }
        #endregion
    }
}