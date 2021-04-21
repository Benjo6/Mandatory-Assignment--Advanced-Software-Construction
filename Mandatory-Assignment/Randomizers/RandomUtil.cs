using System;

namespace Mandatory_Assignment.Randomizers
{
    public class RandomUtil
    {
        #region Instance
        private static Random _rng = new Random(Guid.NewGuid().GetHashCode());
        #endregion
        #region Method

        /// <summary>Percentages this instance.</summary>
        /// <returns>It return a random number between 1,100</returns>
        public static int Percentage()
        {
            return _rng.Next(1,100);
        }
        #endregion
    }
}