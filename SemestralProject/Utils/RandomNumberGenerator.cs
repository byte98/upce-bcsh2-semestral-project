using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemestralProject.Utils
{
    /// <summary>
    /// Class which represents random number generator.
    /// </summary>
    public class RandomNumberGenerator: IEnumerable<int>
    {
        /// <summary>
        /// Minimum of generated numbers.
        /// </summary>
        private int minimum;

        /// <summary>
        /// Maximum of generated numbers.
        /// </summary>
        private int maximum;

        /// <summary>
        /// Limit of generated numbers.
        /// </summary>
        private int limit;

        /// <summary>
        /// Object with ability to generate random numbers.
        /// </summary>
        private Random random;

        /// <summary>
        /// Creates new random number generator.
        /// </summary>
        /// <param name="minimum">Minimum of generated numbers.</param>
        /// <param name="maximum">Maximum of generated numbers.</param>
        /// <param name="limit">Limit of generated numbers.</param>
        public RandomNumberGenerator(int minimum, int maximum, int limit)
        {
            this.random = new Random();
            this.minimum = minimum;
            this.maximum = maximum;
            this.limit = limit;
        }

        public IEnumerator<int> GetEnumerator()
        {
            for(int i = 0; i < limit; i++)
            {
                yield return this.random.Next(this.minimum, this.maximum + 1);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
